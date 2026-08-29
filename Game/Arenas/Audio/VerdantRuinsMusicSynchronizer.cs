using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for VerdantRuins.
    /// Primary Theme: Primeval Whispers
    /// </summary>
    public class VerdantRuinsMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Primeval Whispers";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
