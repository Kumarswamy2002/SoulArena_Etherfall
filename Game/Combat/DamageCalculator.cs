using System;
using SoulArena.Core;

namespace SoulArena.Combat
{
    public struct DamageContext
    {
        public float BaseDamage;
        public float AttackerPower;
        public float DefenderArmor;
        public int ComboHitCount;
        public bool IsCounterHit;
        public bool IsCriticalHit;
        public bool AttackerAwakened;
        public bool DefenderAwakened;
        public bool ArmorBroken;
        public float WeaknessDebuffMultiplier; // 0.7 if weakened, 1.0 otherwise
        public DefenseType DefenseResult;
    }

    /// <summary>
    /// Pure mathematical damage calculation engine implementing combo scaling, counter bonuses, and defenses.
    /// </summary>
    public static class DamageCalculator
    {
        public static float CalculateDamage(DamageContext ctx)
        {
            if (ctx.DefenseResult == DefenseType.Invulnerable || ctx.DefenseResult == DefenseType.PerfectDodge)
            {
                return 0.0f;
            }

            // 1. Base damage scaled with attacker power
            float damage = ctx.BaseDamage * (ctx.AttackerPower / 100.0f);

            // 2. Counter-hit bonus (+25% damage)
            if (ctx.IsCounterHit)
            {
                damage *= GameConstants.COUNTER_DAMAGE_BONUS_MULTIPLIER;
            }

            // 3. Critical hit multiplier (1.5x)
            if (ctx.IsCriticalHit)
            {
                damage *= 1.5f;
            }

            // 4. Attacker Awakening bonus
            if (ctx.AttackerAwakened)
            {
                damage *= GameConstants.AWAKENING_DAMAGE_MODIFIER;
            }

            // 5. Attacker Weakness debuff
            if (ctx.WeaknessDebuffMultiplier > 0.0f)
            {
                damage *= ctx.WeaknessDebuffMultiplier;
            }

            // 6. Combo Scaling Decay
            // Each subsequent hit in a combo scales down by 8%, floored at 15%
            float scalingFactor = 1.0f - (ctx.ComboHitCount * GameConstants.DAMAGE_SCALING_PER_HIT);
            scalingFactor = MathUtility.Clamp(scalingFactor, GameConstants.MIN_DAMAGE_SCALING, 1.0f);
            damage *= scalingFactor;

            // 7. Defender Armor & Awakening Defense
            if (!ctx.ArmorBroken)
            {
                float armorMitigation = 100.0f / (100.0f + ctx.DefenderArmor);
                damage *= armorMitigation;
            }

            if (ctx.DefenderAwakened)
            {
                damage *= GameConstants.AWAKENING_DEFENSE_MODIFIER;
            }

            // 8. Blocking Mitigation
            if (ctx.DefenseResult == DefenseType.StandardBlock)
            {
                // Standard block blocks 80% of damage, dealing 20% chip damage
                damage *= 0.20f;
            }
            else if (ctx.DefenseResult == DefenseType.PerfectGuard)
            {
                // Perfect guard blocks 100% of damage (0 chip damage)
                damage = 0.0f;
            }

            return Math.Max(1.0f, damage); // Minimum 1 damage on connecting hits
        }

        public static float CalculateResonanceGain(float damageDealt, bool isCounter, bool isPerfectDefense, bool isAwakened)
        {
            if (isAwakened) return 0.0f; // Resonance does not generate while Awakening is already active

            float resonance = damageDealt * 0.12f;
            if (isCounter) resonance *= 1.5f;
            if (isPerfectDefense) resonance += 15.0f;

            return resonance;
        }

        public static float CalculateEtherGain(float damageDealt, bool isAttacker)
        {
            if (isAttacker)
            {
                return damageDealt * GameConstants.ETHER_OFFENSIVE_GEN_MULTIPLIER;
            }
            else
            {
                // Defender builds slight Ether from taking damage (comeback mechanic)
                return damageDealt * 0.05f;
            }
        }
    }
}
