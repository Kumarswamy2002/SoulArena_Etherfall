using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Match
{
    /// <summary>
    /// FrameAdvantageCalculator: Calculates instantaneous frame delta on block, hit, and counter stagger in real-time
    /// </summary>
    public class FrameAdvantageCalculator
    {
        public bool IsTracking { get; set; } = true;
        public int TotalEventsCaptured { get; private set; } = 0;

        public void LogEvent(string eventType, float value)
        {
            if (!IsTracking) return;
            TotalEventsCaptured++;
        }
    }
}
