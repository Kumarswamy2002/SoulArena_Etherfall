using System;
using SoulArena.Core;

namespace SoulArena.Networking.Packets
{
    /// <summary>
    /// InputPacket: Compressed binary input packet carrying 8 frames of redundant input history
    /// </summary>
    public class InputPacket
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
