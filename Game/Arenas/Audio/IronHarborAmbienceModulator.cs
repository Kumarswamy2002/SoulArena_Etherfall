using System;

namespace SoulArena.Arenas.Audio
{
    /// <summary>
    /// Ambience Audio Layer & Reverb Zone Controller for IronHarbor.
    /// Landscape Profile: Heavy Steam Piston Clanks & Foghorns
    /// </summary>
    public class IronHarborAmbienceModulator
    {
        public string ProfileDescription { get; } = "Heavy Steam Piston Clanks & Foghorns";
        public float AmbienceVolume { get; set; } = 0.85f;
        public float ReverbDecayTime { get; set; } = 2.4f;

        public void ModulateForCombatPhase(int phase)
        {
            if (phase == 2) AmbienceVolume = 0.95f;
            else if (phase == 3) AmbienceVolume = 1.10f;
        }
    }
}
