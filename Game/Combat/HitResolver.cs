using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Combat
{
    public struct HitResult
    {
        public bool HitConnected;
        public int AttackerId;
        public int DefenderId;
        public float FinalDamage;
        public float ResonanceGainedAttacker;
        public float EtherGainedAttacker;
        public float EtherGainedDefender;
        public DefenseType DefenseResult;
        public HitReactionType Reaction;
        public Vector3D Knockback;
        public float HitstunDuration;
        public float BlockstunDuration;
        public int HitstopFrames;
        public StatusEffectType InflictedStatus;
        public bool CausedGuardBreak;
        public bool CausedWallSplat;
        public bool CausedGroundBounce;
    }

    /// <summary>
    /// Frame-accurate collision detection and combat transaction resolution pipeline.
    /// Connects hitboxes, hurtboxes, defense evaluation, damage calculation, and event publishing.
    /// </summary>
    public static class HitResolver
    {
        public static bool CheckHitboxIntersection(Hitbox hitbox, Hurtbox hurtbox, Vector3D defenderPosition, bool defenderFacingRight)
        {
            if (hitbox == null || hurtbox == null) return false;
            if (hurtbox.IsIntangible) return false;

            var (bottom, top) = hurtbox.GetCapsuleEndpoints(defenderPosition, defenderFacingRight);
            return MathUtility.CheckCapsuleSphereIntersection(bottom, top, hurtbox.Radius, hitbox.WorldPosition, hitbox.Data.Radius);
        }

        public static HitResult ResolveHit(
            Hitbox hitbox,
            Hurtbox hurtbox,
            DefenseSystem defenderDefense,
            StatusEffectSystem attackerStatus,
            StatusEffectSystem defenderStatus,
            float attackerPower,
            float defenderArmor,
            int currentComboHits,
            bool isDefenderCounterState,
            bool isAttackerAwakened,
            bool isDefenderAwakened)
        {
            var result = new HitResult
            {
                HitConnected = false,
                AttackerId = hitbox.Data.OwnerFighterId,
                DefenderId = hurtbox.OwnerFighterId
            };

            // 1. Blind check (40% whiff chance)
            if (attackerStatus != null && attackerStatus.IsBlind())
            {
                var rng = new Random();
                if (rng.NextDouble() < 0.40)
                {
                    return result; // Attack missed due to blindness
                }
            }

            // 2. Defense evaluation
            DefenseType defense = defenderDefense != null 
                ? defenderDefense.EvaluateDefense(hitbox.Data) 
                : DefenseType.None;

            result.DefenseResult = defense;

            if (defense == DefenseType.Invulnerable || defense == DefenseType.PerfectDodge)
            {
                return result; // Zero impact
            }

            if (defense == DefenseType.ParrySuccess)
            {
                // Parry interrupts attacker: attacker receives stagger, defender gains massive frame advantage
                EventManager.Publish(new ParrySuccessEvent
                {
                    DefenderId = result.DefenderId,
                    AttackerId = result.AttackerId,
                    StaggerDuration = GameConstants.PARRY_STAGGER_DURATION
                });
                return result;
            }

            // 3. Damage Calculation
            var dmgContext = new DamageContext
            {
                BaseDamage = hitbox.Data.BaseDamage,
                AttackerPower = attackerPower,
                DefenderArmor = defenderArmor,
                ComboHitCount = currentComboHits,
                IsCounterHit = isDefenderCounterState,
                IsCriticalHit = false,
                AttackerAwakened = isAttackerAwakened,
                DefenderAwakened = isDefenderAwakened,
                ArmorBroken = defenderStatus != null && defenderStatus.IsArmorBroken(),
                WeaknessDebuffMultiplier = attackerStatus != null ? attackerStatus.GetOutgoingDamageModifier() : 1.0f,
                DefenseResult = defense
            };

            float finalDamage = DamageCalculator.CalculateDamage(dmgContext);
            result.FinalDamage = finalDamage;
            result.HitConnected = true;

            // 4. Hitstop, Stun & Reaction
            result.HitstopFrames = hitbox.Data.HitstopFrames;
            result.HitstunDuration = hitbox.Data.HitstunSeconds;
            result.BlockstunDuration = hitbox.Data.BlockstunSeconds;
            result.Reaction = hitbox.Data.HitReaction;
            result.Knockback = hitbox.Data.KnockbackTrajectory;
            result.CausedWallSplat = hitbox.Data.WallSplatTrigger;
            result.CausedGroundBounce = hitbox.Data.GroundBounceTrigger;

            // 5. Resource Gains
            result.ResonanceGainedAttacker = DamageCalculator.CalculateResonanceGain(finalDamage, isDefenderCounterState, defense == DefenseType.PerfectGuard, isAttackerAwakened);
            result.EtherGainedAttacker = DamageCalculator.CalculateEtherGain(finalDamage, isAttacker: true);
            result.EtherGainedDefender = DamageCalculator.CalculateEtherGain(finalDamage, isAttacker: false);

            // 6. Status Effect Application
            if (hitbox.Data.InflictedStatus != StatusEffectType.None && defense != DefenseType.PerfectGuard)
            {
                defenderStatus?.ApplyStatus(hitbox.Data.InflictedStatus, hitbox.Data.StatusDuration, hitbox.Data.StatusPotency, result.AttackerId);
                result.InflictedStatus = hitbox.Data.InflictedStatus;
            }

            // 7. Perfect Guard Event Trigger
            if (defense == DefenseType.PerfectGuard)
            {
                EventManager.Publish(new PerfectGuardEvent
                {
                    DefenderId = result.DefenderId,
                    AttackerId = result.AttackerId,
                    CounterFrameAdvantage = 0.25f // +15 frames advantage
                });
            }

            // 8. Publish Damage Event
            EventManager.Publish(new CharacterDamageEvent
            {
                AttackerId = result.AttackerId,
                TargetId = result.DefenderId,
                RawDamage = hitbox.Data.BaseDamage,
                FinalDamage = finalDamage,
                IsCritical = dmgContext.IsCriticalHit,
                IsCounter = isDefenderCounterState,
                DefenseResult = defense,
                AttackType = hitbox.Data.AttackType,
                AppliedStatus = result.InflictedStatus
            });

            return result;
        }
    }
}
