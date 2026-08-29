using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Interactive Music Track & BPM Synchronizer for RiftObservatory.
    /// Primary Theme: Cosmic Singularity
    /// </summary>
    public class RiftObservatoryMusicSynchronizer
    {
        public string ActiveThemeTrack { get; } = "Cosmic Singularity";
        public float BaseBPM { get; set; } = 135.0f;
        public float IntensityLevel { get; private set; } = 1.0f;

        public void SetCombatIntensity(float intensity)
        {
            IntensityLevel = intensity;
        }
    }
}
