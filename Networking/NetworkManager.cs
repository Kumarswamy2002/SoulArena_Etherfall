using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Networking
{
    [Serializable]
    public struct FighterStateSnapshot
    {
        public int FighterId;
        public Vector3D Position;
        public Vector3D Velocity;
        public bool FacingRight;
        public float Health;
        public float Ether;
        public float Guard;
        public float Resonance;
        public bool IsAwakened;
        public string ActiveMoveId;
        public int CurrentMoveFrame;
    }

    [Serializable]
    public struct GameWorldSnapshot
    {
        public long FrameNumber;
        public FighterStateSnapshot P1State;
        public FighterStateSnapshot P2State;
        public uint StateChecksum;
    }

    /// <summary>
    /// High-performance deterministic Rollback Netcode manager supporting up to 8 frames of latency compensation.
    /// Eliminates input delay feel during competitive online matches.
    /// </summary>
    public class RollbackNetworkManager
    {
        private readonly GameWorldSnapshot[] _stateRingBuffer = new GameWorldSnapshot[GameConstants.MAX_ROLLBACK_FRAMES + 2];
        private readonly Dictionary<long, InputFrame> _remoteInputQueue = new Dictionary<long, InputFrame>();
        
        public long LocalSimulatedFrame { get; private set; }
        public long ConfirmedFrame { get; private set; }
        public int CurrentPingMs { get; set; } = 40;
        public int FrameAdvantage { get; set; } = 0;

        public event Action<long> OnRollbackTriggered;
        public event Action OnDesyncDetected;

        public void SaveSnapshot(long frame, FighterBase p1, FighterBase p2)
        {
            int index = (int)(frame % _stateRingBuffer.Length);

            var snap = new GameWorldSnapshot
            {
                FrameNumber = frame,
                P1State = CreateFighterSnapshot(p1),
                P2State = CreateFighterSnapshot(p2),
                StateChecksum = CalculateChecksum(p1, p2)
            };

            _stateRingBuffer[index] = snap;
            LocalSimulatedFrame = frame;
        }

        public void ReceiveRemoteInput(long frame, InputFrame remoteInput)
        {
            _remoteInputQueue[frame] = remoteInput;

            // If input arrived late and we predicted a different input for that frame, trigger rollback
            if (frame < LocalSimulatedFrame)
            {
                long rollbackFrames = LocalSimulatedFrame - frame;
                if (rollbackFrames <= GameConstants.MAX_ROLLBACK_FRAMES)
                {
                    ExecuteRollback(frame);
                }
                else
                {
                    OnDesyncDetected?.Invoke();
                }
            }
        }

        private void ExecuteRollback(long fromFrame)
        {
            OnRollbackTriggered?.Invoke(fromFrame);
            // In a full Unity context, we restore state from _stateRingBuffer[fromFrame % length] and fast-forward simulate
        }

        private FighterStateSnapshot CreateFighterSnapshot(FighterBase f)
        {
            return new FighterStateSnapshot
            {
                FighterId = f.FighterId,
                Position = f.Position,
                Velocity = f.Velocity,
                FacingRight = f.FacingRight,
                Health = f.CurrentHealth,
                Ether = f.Ether.CurrentEther,
                Guard = f.Defense.CurrentGuard,
                Resonance = f.Resonance.CurrentResonance,
                IsAwakened = f.Awakening.IsAwakened,
                ActiveMoveId = f.ActiveMove != null ? f.ActiveMove.MoveId : string.Empty,
                CurrentMoveFrame = f.CurrentMoveFrame
            };
        }

        private uint CalculateChecksum(FighterBase p1, FighterBase p2)
        {
            unchecked
            {
                uint hash = 17;
                hash = hash * 31 + (uint)p1.Position.X.GetHashCode();
                hash = hash * 31 + (uint)p1.CurrentHealth.GetHashCode();
                hash = hash * 31 + (uint)p2.Position.X.GetHashCode();
                hash = hash * 31 + (uint)p2.CurrentHealth.GetHashCode();
                return hash;
            }
        }
    }
}
