using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Characters.Telemetry
{
    /// <summary>
    /// Frame Telemetry Stream Buffer for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolTelemetryBuffer
    {
        public struct FrameRecord
        {
            public long FrameNumber;
            public float Health;
            public float Ether;
            public float Guard;
            public float Resonance;
            public Vector3D Position;
            public string CurrentAction;
        }

        private readonly List<FrameRecord> _history = new List<FrameRecord>(600);

        public void RecordFrame(long frame, float hp, float ether, float guard, float res, Vector3D pos, string action)
        {
            _history.Add(new FrameRecord
            {
                FrameNumber = frame,
                Health = hp,
                Ether = ether,
                Guard = guard,
                Resonance = res,
                Position = pos,
                CurrentAction = action
            });

            if (_history.Count > 1800)
            {
                _history.RemoveAt(0);
            }
        }

        public IReadOnlyList<FrameRecord> GetHistory() => _history;
    }
}
