using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combos
{
    [Serializable]
    public class ComboMoveData
    {
        public string MoveId;
        public string AnimationStateName;
        public AttackType AttackType;
        public AttackProperty Property;

        // Frame Data (at 60 FPS)
        public int StartupFrames;
        public int ActiveFrames;
        public int RecoveryFrames;
        public int TotalFrames => StartupFrames + ActiveFrames + RecoveryFrames;

        // Cancel Windows
        public int CancelWindowStartFrame;
        public int CancelWindowEndFrame;
        public CancelWindowType AllowedCancelType;

        // Resource Cost
        public float EtherCost;
        public float ResonanceCost;

        // Hitbox Configuration
        public HitboxData HitboxDefinition;

        // Transitions / Valid Followup Move IDs
        public List<string> FollowupMoveIds = new List<string>();

        public bool IsWithinCancelWindow(int currentMoveFrame)
        {
            return currentMoveFrame >= CancelWindowStartFrame && currentMoveFrame <= CancelWindowEndFrame;
        }
    }

    public class ComboTree
    {
        private readonly Dictionary<string, ComboMoveData> _moves = new Dictionary<string, ComboMoveData>();
        public string DefaultStarterMoveId { get; set; }

        public void RegisterMove(ComboMoveData move)
        {
            if (move == null || string.IsNullOrEmpty(move.MoveId)) return;
            _moves[move.MoveId] = move;
            if (string.IsNullOrEmpty(DefaultStarterMoveId))
            {
                DefaultStarterMoveId = move.MoveId;
            }
        }

        public ComboMoveData GetMove(string moveId)
        {
            _moves.TryGetValue(moveId, out var move);
            return move;
        }

        public bool CanTransition(string currentMoveId, string nextMoveId, int currentFrame, bool hitConnected)
        {
            if (!_moves.TryGetValue(currentMoveId, out var currentMove)) return false;
            if (!_moves.TryGetValue(nextMoveId, out var nextMove)) return false;

            if (!currentMove.FollowupMoveIds.Contains(nextMoveId)) return false;
            if (!currentMove.IsWithinCancelWindow(currentFrame)) return false;

            switch (currentMove.AllowedCancelType)
            {
                case CancelWindowType.OnHitOnly:
                    return hitConnected;
                case CancelWindowType.SpecialCancelable:
                    return hitConnected && (nextMove.AttackType == AttackType.Special1 || nextMove.AttackType == AttackType.Special2 || nextMove.AttackType == AttackType.Special3);
                case CancelWindowType.SuperCancelable:
                    return hitConnected && nextMove.AttackType == AttackType.Ultimate;
                case CancelWindowType.FreeCancel:
                    return true;
                default:
                    return hitConnected;
            }
        }
    }
}
