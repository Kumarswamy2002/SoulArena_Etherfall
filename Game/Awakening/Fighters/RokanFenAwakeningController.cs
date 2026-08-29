using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Awakening;

namespace SoulArena.Awakening.Fighters
{
    /// <summary>
    /// Awakening State Controller for Rokan Fen (Beast Soul).
    /// Element: Beast | Buffs attack power, movement speed, and unlocks enhanced cancel chains.
    /// </summary>
    public class RokanFenAwakeningController : AwakeningController
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
            OnAwakeningFormActivated?.Invoke("rokan_fen_awakened_sovereign");
        }

        public void TerminateFighterAwakening(FighterBase fighter)
        {
            DeactivateAwakening();
            OnAwakeningFormEnded?.Invoke("rokan_fen_awakened_sovereign");
        }
    }
}
