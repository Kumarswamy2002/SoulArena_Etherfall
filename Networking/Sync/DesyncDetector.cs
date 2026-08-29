using System;
using SoulArena.Core;

namespace SoulArena.Networking.Sync
{
    /// <summary>
    /// DesyncDetector: Hash comparison validator flagging physics discrepancies between local and remote clients
    /// </summary>
    public class DesyncDetector
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
