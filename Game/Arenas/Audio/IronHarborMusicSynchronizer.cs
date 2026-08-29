using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for IronHarbor.
    /// Primary Theme: Steel Foundry
    /// </summary>
    public class IronHarborMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Steel Foundry";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
