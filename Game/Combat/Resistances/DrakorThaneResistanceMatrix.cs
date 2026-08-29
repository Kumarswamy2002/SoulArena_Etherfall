using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Resistances
{
    /// <summary>
    /// Status Effect Vulnerability & Resistance Matrix for Drakor Thane (Iron Colossus).
    /// </summary>
    public class DrakorThaneResistanceMatrix
    {
        public float BurnResistance { get; set; } = 1.0f;
        public float FreezeResistance { get; set; } = 1.0f;
        public float ShockResistance { get; set; } = 1.0f;
        public float StunResistance { get; set; } = 1.0f;

        public float CalculateModifiedDuration(StatusEffectType statusType, float baseDuration)
        {
            switch (statusType)
            {
                case StatusEffectType.Burn: return baseDuration / BurnResistance;
                case StatusEffectType.Freeze: return baseDuration / FreezeResistance;
                case StatusEffectType.Shock: return baseDuration / ShockResistance;
                case StatusEffectType.Stun: return baseDuration / StunResistance;
                default: return baseDuration;
            }
        }
    }
}
