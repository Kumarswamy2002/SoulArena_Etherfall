using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Abilities;

namespace SoulArena.Abilities.Spells
{
    /// <summary>
    /// Elemental Spell & Buff Execution Engine for Zayn Rheo (Lightning Phantom).
    /// Handles cast animations, channel ticks, cooldown adjustments, and elemental procs.
    /// </summary>
    public class ZaynRheoSpellPipeline
    {
        public string FighterId { get; } = "zayn_rheo";
        public EtherElement Element { get; } = EtherElement.Volt;
        public int TotalSpellsCast { get; private set; } = 0;
        public float ActiveBuffDuration { get; private set; } = 0.0f;
        public bool HasActiveStanceBuff { get; private set; } = false;

        public event Action<string, float> OnSpellCastComplete;
        public event Action<string> OnBuffExpired;

        public void ProcessSpellTick(float deltaTime)
        {
            if (HasActiveStanceBuff)
            {
                ActiveBuffDuration -= deltaTime;
                if (ActiveBuffDuration <= 0.0f)
                {
                    HasActiveStanceBuff = false;
                    ActiveBuffDuration = 0.0f;
                    OnBuffExpired?.Invoke("zayn_rheo_stance_buff");
                }
            }
        }

        public bool TryExecuteSpecialCast(int slotIndex, float currentEther, out float consumedEther)
        {
            consumedEther = 20.0f + (slotIndex * 5.0f);
            if (currentEther >= consumedEther)
            {
                TotalSpellsCast++;
                HasActiveStanceBuff = true;
                ActiveBuffDuration = 6.0f;
                OnSpellCastComplete?.Invoke("zayn_rheo_spell_" + slotIndex, consumedEther);
                return true;
            }
            return false;
        }
    }
}
