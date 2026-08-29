using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for SunkenCitadel.
    /// Primary Theme: Tidal Requiem
    /// </summary>
    public class SunkenCitadelMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Tidal Requiem";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
