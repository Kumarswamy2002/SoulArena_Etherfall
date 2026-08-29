using System;
using SoulArena.Core;

namespace SoulArena.Networking.Rollback
{
    /// <summary>
    /// InputPredictor: Lag-hiding input extrapolation algorithm based on Markov chain transition probabilities
    /// </summary>
    public class InputPredictor
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
