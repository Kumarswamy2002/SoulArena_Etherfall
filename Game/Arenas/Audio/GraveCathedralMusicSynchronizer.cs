using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for GraveCathedral.
    /// Primary Theme: Danse Macabre
    /// </summary>
    public class GraveCathedralMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Danse Macabre";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
