using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Ambience Audio Layer & Reverb Zone Controller for VerdantRuins.
    /// Landscape Profile: Primeval Fauna Chants & Rustling Canopy
    /// </summary>
    public class VerdantRuinsAmbienceModulator
    {
        public string ProfileDescription { get; } = "Primeval Fauna Chants & Rustling Canopy";
        public float AmbienceVolume { get; set; } = 0.85f;
        public float ReverbDecayTime { get; set; } = 2.4f;

        public void ModulateForCombatPhase(int phase)
        {
            if (phase == 2) AmbienceVolume = 0.95f;
            else if (phase == 3) AmbienceVolume = 1.10f;
        }
    }
}
