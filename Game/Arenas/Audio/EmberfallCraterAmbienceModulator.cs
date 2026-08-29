using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Ambience Audio Layer & Reverb Zone Controller for EmberfallCrater.
    /// Landscape Profile: Subterranean Magma Rumble & Steam Hiss
    /// </summary>
    public class EmberfallCraterAmbienceModulator
    {
        public string ProfileDescription { get; } = "Subterranean Magma Rumble & Steam Hiss";
        public float AmbienceVolume { get; set; } = 0.85f;
        public float ReverbDecayTime { get; set; } = 2.4f;

        public void ModulateForCombatPhase(int phase)
        {
            if (phase == 2) AmbienceVolume = 0.95f;
            else if (phase == 3) AmbienceVolume = 1.10f;
        }
    }
}
