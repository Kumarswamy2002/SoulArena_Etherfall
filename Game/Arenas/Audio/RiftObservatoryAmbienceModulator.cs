using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Ambience Audio Layer & Reverb Zone Controller for RiftObservatory.
    /// Landscape Profile: Singularity Gravitational Drone & Phase Hum
    /// </summary>
    public class RiftObservatoryAmbienceModulator
    {
        public string ProfileDescription { get; } = "Singularity Gravitational Drone & Phase Hum";
        public float AmbienceVolume { get; set; } = 0.85f;
        public float ReverbDecayTime { get; set; } = 2.4f;

        public void ModulateForCombatPhase(int phase)
        {
            if (phase == 2) AmbienceVolume = 0.95f;
            else if (phase == 3) AmbienceVolume = 1.10f;
        }
    }
}
