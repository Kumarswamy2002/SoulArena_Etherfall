using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Characters.Definitions
{
    /// <summary>
    /// Frame Data & Move Definition Catalog for Raven Drake (Blood Knight).
    /// Element: Crimson | Role: HighRiskReward | Weapon: Greatsword | Difficulty: Medium
    /// </summary>
    public static class RavenDrakeDefinition
    {
        public static readonly string FighterId = "raven_drake";
        public static readonly string DisplayName = "Raven Drake";
        public static readonly string Title = "Blood Knight";
        public static readonly EtherElement Element = EtherElement.Crimson;
        public static readonly FighterRole Role = FighterRole.HighRiskReward;
        public static readonly string Weapon = "Greatsword";

        public static FighterStats CreateBaseStats()
        {
            return new FighterStats
            {
                MaxHealth = 1000.0f,
                AttackPower = 105.0f,
                DefenseArmor = 22.0f,
                MoveSpeed = 6.4f,
                DashSpeed = 15.0f,
                JumpForce = 12.5f,
                Weight = 1.0f,
                CriticalChance = 0.08f
            };
        }

        public static List<ComboMoveData> GetMoveCatalog(int ownerId)
        {
            var catalog = new List<ComboMoveData>();

            // Basic Chain 1: Light Jab
            catalog.Add(new ComboMoveData
            {
                MoveId = "raven_drake_light_jab",
                AnimationStateName = "RavenDrake_Light_Jab",
                AttackType = AttackType.Light,
                Property = AttackProperty.High,
                StartupFrames = 4,
                ActiveFrames = 3,
                RecoveryFrames = 7,
                CancelWindowStartFrame = 5,
                CancelWindowEndFrame = 12,
                AllowedCancelType = CancelWindowType.OnHitOnly,
                EtherCost = 0.0f,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "raven_drake_hb_jab",
                    OwnerFighterId = ownerId,
                    Radius = 0.70f,
                    BaseDamage = 25.0f,
                    GuardDamage = 10.0f,
                    HitstunSeconds = 0.30f,
                    BlockstunSeconds = 0.18f,
                    HitstopFrames = 3,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { "raven_drake_light_cross", "raven_drake_heavy_strike" }
            });

            // Basic Chain 2: Light Cross
            catalog.Add(new ComboMoveData
            {
                MoveId = "raven_drake_light_cross",
                AnimationStateName = "RavenDrake_Light_Cross",
                AttackType = AttackType.Light,
                Property = AttackProperty.Mid,
                StartupFrames = 5,
                ActiveFrames = 3,
                RecoveryFrames = 8,
                CancelWindowStartFrame = 6,
                CancelWindowEndFrame = 14,
                AllowedCancelType = CancelWindowType.OnHitOnly,
                EtherCost = 0.0f,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "raven_drake_hb_cross",
                    OwnerFighterId = ownerId,
                    Radius = 0.80f,
                    BaseDamage = 35.0f,
                    GuardDamage = 12.0f,
                    HitstunSeconds = 0.35f,
                    BlockstunSeconds = 0.20f,
                    HitstopFrames = 4,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { "raven_drake_light_finisher", "raven_drake_launcher_kick" }
            });

            // Basic Chain 3: Light Finisher
            catalog.Add(new ComboMoveData
            {
                MoveId = "raven_drake_light_finisher",
                AnimationStateName = "RavenDrake_Light_Finisher",
                AttackType = AttackType.Light,
                Property = AttackProperty.Mid,
                StartupFrames = 6,
                ActiveFrames = 4,
                RecoveryFrames = 11,
                CancelWindowStartFrame = 7,
                CancelWindowEndFrame = 16,
                AllowedCancelType = CancelWindowType.SpecialCancelable,
                EtherCost = 0.0f,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "raven_drake_hb_finisher",
                    OwnerFighterId = ownerId,
                    Radius = 0.90f,
                    BaseDamage = 50.0f,
                    GuardDamage = 18.0f,
                    HitstunSeconds = 0.45f,
                    BlockstunSeconds = 0.22f,
                    HitstopFrames = 5,
                    HitReaction = HitReactionType.HeavyStagger,
                    KnockbackTrajectory = new Vector3D(5.0f, 1.5f, 0.0f)
                },
                FollowupMoveIds = new List<string> { "raven_drake_special_surge", "raven_drake_special_burst" }
            });

            // Heavy Strike (Wall Splat)
            catalog.Add(new ComboMoveData
            {
                MoveId = "raven_drake_heavy_strike",
                AnimationStateName = "RavenDrake_Heavy_Strike",
                AttackType = AttackType.Heavy,
                Property = AttackProperty.Mid,
                StartupFrames = 12,
                ActiveFrames = 5,
                RecoveryFrames = 18,
                CancelWindowStartFrame = 14,
                CancelWindowEndFrame = 22,
                AllowedCancelType = CancelWindowType.SpecialCancelable,
                EtherCost = 0.0f,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "raven_drake_hb_heavy",
                    OwnerFighterId = ownerId,
                    Radius = 1.20f,
                    BaseDamage = 85.0f,
                    GuardDamage = 40.0f,
                    HitstunSeconds = 0.60f,
                    BlockstunSeconds = 0.32f,
                    HitstopFrames = GameConstants.HITSTOP_HEAVY_FRAMES,
                    HitReaction = HitReactionType.Crumple,
                    KnockbackTrajectory = new Vector3D(8.0f, 2.0f, 0.0f),
                    WallSplatTrigger = true
                },
                FollowupMoveIds = new List<string> { "raven_drake_special_surge" }
            });

            // Launcher
            catalog.Add(new ComboMoveData
            {
                MoveId = "raven_drake_launcher_kick",
                AnimationStateName = "RavenDrake_Launcher",
                AttackType = AttackType.Launcher,
                Property = AttackProperty.Low,
                StartupFrames = 9,
                ActiveFrames = 4,
                RecoveryFrames = 15,
                CancelWindowStartFrame = 11,
                CancelWindowEndFrame = 18,
                AllowedCancelType = CancelWindowType.JumpCancelable,
                EtherCost = 0.0f,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "raven_drake_hb_launcher",
                    OwnerFighterId = ownerId,
                    Radius = 1.0f,
                    BaseDamage = 60.0f,
                    GuardDamage = 22.0f,
                    HitstunSeconds = 0.70f,
                    BlockstunSeconds = 0.20f,
                    HitstopFrames = 5,
                    HitReaction = HitReactionType.LaunchUp,
                    KnockbackTrajectory = new Vector3D(1.5f, 11.0f, 0.0f)
                },
                FollowupMoveIds = new List<string> { "raven_drake_aerial_strike" }
            });

            // Aerial Strike
            catalog.Add(new ComboMoveData
            {
                MoveId = "raven_drake_aerial_strike",
                AnimationStateName = "RavenDrake_Air_Strike",
                AttackType = AttackType.AirAttack,
                Property = AttackProperty.High,
                StartupFrames = 5,
                ActiveFrames = 4,
                RecoveryFrames = 9,
                CancelWindowStartFrame = 6,
                CancelWindowEndFrame = 12,
                AllowedCancelType = CancelWindowType.FreeCancel,
                EtherCost = 0.0f,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "raven_drake_hb_air",
                    OwnerFighterId = ownerId,
                    Radius = 0.90f,
                    BaseDamage = 45.0f,
                    GuardDamage = 15.0f,
                    HitstunSeconds = 0.40f,
                    BlockstunSeconds = 0.18f,
                    HitstopFrames = 4,
                    HitReaction = HitReactionType.Knockback,
                    KnockbackTrajectory = new Vector3D(3.0f, -4.0f, 0.0f),
                    GroundBounceTrigger = true
                }
            });

            return catalog;
        }
    }
}
