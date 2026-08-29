using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Ambience Audio Layer & Reverb Zone Controller for GraveCathedral.
    /// Landscape Profile: Haunting Organ Echoes & Phantom Whispers
    /// </summary>
    public class GraveCathedralAmbienceModulator
    {
        public string ProfileDescription { get; } = "Haunting Organ Echoes & Phantom Whispers";
        public float AmbienceVolume { get; set; } = 0.85f;
        public float ReverbDecayTime { get; set; } = 2.4f;

        public void ModulateForCombatPhase(int phase)
        {
            if (phase == 2) AmbienceVolume = 0.95f;
            else if (phase == 3) AmbienceVolume = 1.10f;
        }
    }
}
