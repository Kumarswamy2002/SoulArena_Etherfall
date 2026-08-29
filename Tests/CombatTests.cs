using System;
using System.Diagnostics;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Characters;
using SoulArena.Combos;

namespace SoulArena.Tests
{
    /// <summary>
    /// Comprehensive test suite verifying combat damage pipelines, guard mechanics, parries, and combos.
    /// </summary>
    public static class CombatTests
    {
        public static void RunAllCombatTests()
        {
            TestStandardDamageCalculation();
            TestCounterHitBonus();
            TestComboScalingDecay();
            TestGuardBreakTrigger();
            TestPerfectGuardZeroDamage();
            TestParryInterruption();
            TestStatusEffectApplication();
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception($"CombatTest Assertion Failed: {message}");
            }
        }

        public static void TestStandardDamageCalculation()
        {
            var ctx = new DamageContext
            {
                BaseDamage = 100.0f,
                AttackerPower = 100.0f,
                DefenderArmor = 0.0f,
                ComboHitCount = 0,
                IsCounterHit = false,
                IsCriticalHit = false,
                DefenseResult = DefenseType.None
            };

            float damage = DamageCalculator.CalculateDamage(ctx);
            Assert(Math.Abs(damage - 100.0f) < 0.001f, $"Standard damage should be 100. Got: {damage}");
        }

        public static void TestCounterHitBonus()
        {
            var ctx = new DamageContext
            {
                BaseDamage = 100.0f,
                AttackerPower = 100.0f,
                DefenderArmor = 0.0f,
                ComboHitCount = 0,
                IsCounterHit = true, // +25% bonus
                IsCriticalHit = false,
                DefenseResult = DefenseType.None
            };

            float damage = DamageCalculator.CalculateDamage(ctx);
            Assert(Math.Abs(damage - 125.0f) < 0.001f, $"Counter damage should be 125. Got: {damage}");
        }

        public static void TestComboScalingDecay()
        {
            // At 5 hits: 1.0 - (5 * 0.08) = 0.60 (60% scaling)
            var ctx = new DamageContext
            {
                BaseDamage = 100.0f,
                AttackerPower = 100.0f,
                DefenderArmor = 0.0f,
                ComboHitCount = 5,
                IsCounterHit = false,
                DefenseResult = DefenseType.None
            };

            float damage = DamageCalculator.CalculateDamage(ctx);
            Assert(Math.Abs(damage - 60.0f) < 0.001f, $"Combo 5-hit damage should scale to 60. Got: {damage}");
        }

        public static void TestGuardBreakTrigger()
        {
            var defense = new DefenseSystem(1, maxGuard: 100.0f);
            defense.StartBlocking();

            var heavyHit = new HitboxData
            {
                BaseDamage = 100.0f,
                GuardDamage = 120.0f // Exceeds max guard
            };

            var defResult = defense.EvaluateDefense(heavyHit);
            Assert(defense.IsGuardBroken, "Defense should enter Guard Broken state after receiving fatal guard damage.");
        }

        public static void TestPerfectGuardZeroDamage()
        {
            var ctx = new DamageContext
            {
                BaseDamage = 100.0f,
                AttackerPower = 100.0f,
                DefenderArmor = 0.0f,
                ComboHitCount = 0,
                DefenseResult = DefenseType.PerfectGuard
            };

            float damage = DamageCalculator.CalculateDamage(ctx);
            Assert(damage == 0.0f, $"Perfect Guard must mitigate 100% of damage. Got: {damage}");
        }

        public static void TestParryInterruption()
        {
            var defense = new DefenseSystem(1);
            defense.StartParry();

            var hit = new HitboxData
            {
                BaseDamage = 50.0f,
                CanBeParried = true
            };

            var defResult = defense.EvaluateDefense(hit);
            Assert(defResult == DefenseType.ParrySuccess, $"Expected ParrySuccess, got: {defResult}");
        }

        public static void TestStatusEffectApplication()
        {
            var statusSys = new StatusEffectSystem(1);
            statusSys.ApplyStatus(StatusEffectType.Burn, duration: 4.0f, potency: 20.0f, inflictorId: 2);

            Assert(statusSys.HasStatus(StatusEffectType.Burn), "Status system should report active Burn.");
            var effect = statusSys.GetStatus(StatusEffectType.Burn);
            Assert(effect.DurationRemaining == 4.0f, "Duration should be 4.0s.");
        }
    }
}
