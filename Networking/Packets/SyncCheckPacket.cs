using System;
using SoulArena.Core;

namespace SoulArena.Networking.Packets
{
    /// <summary>
    /// SyncCheckPacket: Periodic world checksum packet detecting simulation desyncs between peers
    /// </summary>
    public class SyncCheckPacket
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
