using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Abilities;

namespace SoulArena.Abilities.Spells
{
    /// <summary>
    /// Elemental Spell & Buff Execution Engine for Aeris Quin (Star Weaver).
    /// Handles cast animations, channel ticks, cooldown adjustments, and elemental procs.
    /// </summary>
    public class AerisQuinSpellPipeline
    {
        public string FighterId { get; } = "aeris_quin";
        public EtherElement Element { get; } = EtherElement.Astral;
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
                    OnBuffExpired?.Invoke("aeris_quin_stance_buff");
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
                OnSpellCastComplete?.Invoke("aeris_quin_spell_" + slotIndex, consumedEther);
                return true;
            }
            return false;
        }
    }
}
