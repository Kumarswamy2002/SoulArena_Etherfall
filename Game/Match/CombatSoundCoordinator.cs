using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Match
{
    /// <summary>
    /// CombatSoundCoordinator: Coordinates audio ducking, slow-motion pitch bending, and hitstop audio queues
    /// </summary>
    public class CombatSoundCoordinator
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
