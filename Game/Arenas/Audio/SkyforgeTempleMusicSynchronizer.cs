using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for SkyforgeTemple.
    /// Primary Theme: Cloudspire Anthem
    /// </summary>
    public class SkyforgeTempleMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Cloudspire Anthem";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
