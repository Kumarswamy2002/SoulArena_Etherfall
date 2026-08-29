using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Match
{
    /// <summary>
    /// VictoryCelebrationDirector: Controls post-match camera transitions, victory emotes, and results sequence
    /// </summary>
    public class VictoryCelebrationDirector
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
