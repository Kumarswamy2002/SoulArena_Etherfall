using System;
using SoulArena.Core;

namespace SoulArena.Networking.Rollback
{
    /// <summary>
    /// RollbackFrameHistory: Ring buffer preserving state snapshots for frame rewind and fast-forward simulation
    /// </summary>
    public class RollbackFrameHistory
    {
        public int NetworkSequenceNumber { get; set; } = 0;
        public long TargetSimulationFrame { get; set; } = 0;

        public void ProcessNetworkTick(long currentFrame)
        {
            TargetSimulationFrame = currentFrame;
            NetworkSequenceNumber++;
        }
    }
}
