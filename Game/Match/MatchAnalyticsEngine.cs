using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Match
{
    /// <summary>
    /// MatchAnalyticsEngine: Records heatmaps of player movement, damage dealt distributions, and combo frequency metrics
    /// </summary>
    public class MatchAnalyticsEngine
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
