using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for FrostveilSanctuary.
    /// Primary Theme: Glacial Waltz
    /// </summary>
    public class FrostveilSanctuaryMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Glacial Waltz";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
