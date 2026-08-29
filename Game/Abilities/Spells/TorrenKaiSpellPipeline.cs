using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Abilities;

namespace SoulArena.Abilities.Spells
{
    /// <summary>
    /// Elemental Spell & Buff Execution Engine for Torren Kai (Wind Dancer).
    /// Handles cast animations, channel ticks, cooldown adjustments, and elemental procs.
    /// </summary>
    public class TorrenKaiSpellPipeline
    {
        public string FighterId { get; } = "torren_kai";
        public EtherElement Element { get; } = EtherElement.Gale;
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
                    OnBuffExpired?.Invoke("torren_kai_stance_buff");
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
                OnSpellCastComplete?.Invoke("torren_kai_spell_" + slotIndex, consumedEther);
                return true;
            }
            return false;
        }
    }
}
