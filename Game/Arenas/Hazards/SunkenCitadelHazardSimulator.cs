using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Arenas.Hazards
{
    /// <summary>
    /// Dynamic Stage Hazard Simulator: SunkenCitadel
    /// Mechanics: Tidal Current Water Drag & Surging Floods
    /// </summary>
    public class SunkenCitadelHazardSimulator
    {
        public bool IsHazardActive { get; set; } = true;
        public float HazardCycleTimer { get; private set; } = 0.0f;
        public float HazardCycleInterval { get; set; } = 15.0f;
        public int SurgeLevel { get; private set; } = 1;

        public event Action<string, float> OnHazardEruption;

        public void UpdateSimulation(float deltaTime)
        {
            if (!IsHazardActive) return;

            HazardCycleTimer += deltaTime;
            if (HazardCycleTimer >= HazardCycleInterval)
            {
                HazardCycleTimer = 0.0f;
                SurgeLevel = (SurgeLevel % 3) + 1;
                TriggerHazardCycle();
            }
        }

        private void TriggerHazardCycle()
        {
            float damage = SurgeLevel * 25.0f;
            OnHazardEruption?.Invoke("SunkenCitadel Hazard Cycle Erupted: Tidal Current Water Drag & Surging Floods", damage);
        }
    }
}
