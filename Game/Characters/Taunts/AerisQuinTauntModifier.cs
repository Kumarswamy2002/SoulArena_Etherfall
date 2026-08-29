using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Taunts
{
    /// <summary>
    /// Tactical Combat Taunt & Resonance Surge for Aeris Quin (Star Weaver).
    /// </summary>
    public class AerisQuinTauntModifier
    {
        public float TauntResonanceReward { get; set; } = 15.0f;
        public float TauntEtherBonus { get; set; } = 10.0f;
        public int TotalTauntsExecuted { get; private set; } = 0;

        public event Action<string> OnTauntCompleted;

        public void ExecuteTaunt(FighterBase fighter)
        {
            if (fighter == null) return;
            TotalTauntsExecuted++;
            fighter.Resonance.AddResonance(TauntResonanceReward);
            fighter.Ether.AddEther(TauntEtherBonus);
            OnTauntCompleted?.Invoke("aeris_quin_taunt_buff");
        }
    }
}
