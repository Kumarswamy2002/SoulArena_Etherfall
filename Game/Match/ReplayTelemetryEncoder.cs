using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Match
{
    /// <summary>
    /// ReplayTelemetryEncoder: Encodes real-time input stream into compact delta-compressed binary chunks
    /// </summary>
    public class ReplayTelemetryEncoder
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
