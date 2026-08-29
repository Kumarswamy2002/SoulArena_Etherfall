using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Awakening;

namespace SoulArena.Awakening.Fighters
{
    /// <summary>
    /// Awakening State Controller for Nox Arden (Riftborn).
    /// Element: Rift | Buffs attack power, movement speed, and unlocks enhanced cancel chains.
    /// </summary>
    public class NoxArdenAwakeningController : AwakeningController
    {
        public float ElementalPowerMultiplier { get; private set; } = 1.35f;
        public float EtherRegenBoost { get; private set; } = 2.0f;
        public bool SuperArmorGranted { get; private set; } = true;

        public event Action<string> OnAwakeningFormActivated;
        public event Action<string> OnAwakeningFormEnded;

        public void TriggerFighterAwakening(FighterBase fighter)
        {
            if (fighter == null || !fighter.Resonance.IsAwakeningReady) return;

            ActivateAwakening();
            fighter.Ether.AddEther(40.0f);
            OnAwakeningFormActivated?.Invoke("nox_arden_awakened_sovereign");
        }

        public void TerminateFighterAwakening(FighterBase fighter)
        {
            DeactivateAwakening();
            OnAwakeningFormEnded?.Invoke("nox_arden_awakened_sovereign");
        }
    }
}
