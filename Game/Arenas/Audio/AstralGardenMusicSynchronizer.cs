using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for AstralGarden.
    /// Primary Theme: Celestial Harmonies
    /// </summary>
    public class AstralGardenMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Celestial Harmonies";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
