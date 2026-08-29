using System;
using SoulArena.Core;

namespace SoulArena.Networking.Sync
{
    /// <summary>
    /// LagCompensator: Clock synchronization protocol adjusting simulation lead/lag frames to match network latency
    /// </summary>
    public class LagCompensator
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
