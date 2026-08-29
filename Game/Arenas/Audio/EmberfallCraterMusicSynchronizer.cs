using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for EmberfallCrater.
    /// Primary Theme: Volcano Fury
    /// </summary>
    public class EmberfallCraterMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Volcano Fury";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
