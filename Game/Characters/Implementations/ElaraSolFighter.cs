using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;
using SoulArena.Ether;
using SoulArena.Resonance;
using SoulArena.Awakening;
using SoulArena.Abilities;

namespace SoulArena.Characters.Implementations
{
    /// <summary>
    /// Fighter Implementation: Elara Sol (Dawn Saint)
    /// Element: Radiance | Role: Support Fighter | Weapon: Light Spear
    /// Unique Mechanic: SolarGrace
    /// </summary>
    public class ElaraSolFighter : FighterBase
    {
        // Unique Fighter State Fields
        public float SolarGraceMeter { get; private set; } = 0.0f;
        public const float MAX_SOLARGRACE_METER = 100.0f;
        public int ConsecutiveChainStreak { get; private set; } = 0;
        public bool IsInUniqueStance { get; private set; } = false;
        public float StanceDurationRemaining { get; private set; } = 0.0f;

        public event Action<float> OnSolarGraceChanged;
        public event Action<string, int> OnElementalSurge;

        public ElaraSolFighter(int runtimeId, FighterDefinition definition) : base(runtimeId, definition)
        {
            InitializeElaraSolCustomMoveTree();
            InitializeElaraSolHurtboxOffsets();
        }

        private void InitializeElaraSolCustomMoveTree()
        {
            // Custom attack chain configurations
            var light1 = new ComboMoveData
            {
                MoveId = "elara_sol_light1",
                AnimationStateName = "ElaraSol_Attack_Light1",
                AttackType = AttackType.Light,
                Property = AttackProperty.High,
                StartupFrames = 4,
                ActiveFrames = 3,
                RecoveryFrames = 7,
                CancelWindowStartFrame = 5,
                CancelWindowEndFrame = 12,
                AllowedCancelType = CancelWindowType.OnHitOnly,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "elara_sol_hb_l1",
                    OwnerFighterId = FighterId,
                    Radius = 0.75f,
                    BaseDamage = 26.0f,
                    GuardDamage = 11.0f,
                    HitstunSeconds = 0.32f,
                    BlockstunSeconds = 0.18f,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { "elara_sol_light2", "elara_sol_heavy" }
            };

            var light2 = new ComboMoveData
            {
                MoveId = "elara_sol_light2",
                AnimationStateName = "ElaraSol_Attack_Light2",
                AttackType = AttackType.Light,
                Property = AttackProperty.Mid,
                StartupFrames = 5,
                ActiveFrames = 3,
                RecoveryFrames = 8,
                CancelWindowStartFrame = 6,
                CancelWindowEndFrame = 13,
                AllowedCancelType = CancelWindowType.OnHitOnly,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "elara_sol_hb_l2",
                    OwnerFighterId = FighterId,
                    Radius = 0.80f,
                    BaseDamage = 36.0f,
                    GuardDamage = 14.0f,
                    HitstunSeconds = 0.36f,
                    BlockstunSeconds = 0.20f,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { "elara_sol_light3", "elara_sol_launcher", "elara_sol_ability1" }
            };

            var light3 = new ComboMoveData
            {
                MoveId = "elara_sol_light3",
                AnimationStateName = "ElaraSol_Attack_Light3",
                AttackType = AttackType.Light,
                Property = AttackProperty.Mid,
                StartupFrames = 6,
                ActiveFrames = 4,
                RecoveryFrames = 10,
                CancelWindowStartFrame = 7,
                CancelWindowEndFrame = 15,
                AllowedCancelType = CancelWindowType.SpecialCancelable,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "elara_sol_hb_l3",
                    OwnerFighterId = FighterId,
                    Radius = 0.90f,
                    BaseDamage = 48.0f,
                    GuardDamage = 18.0f,
                    HitstunSeconds = 0.42f,
                    BlockstunSeconds = 0.24f,
                    HitReaction = HitReactionType.HeavyStagger,
                    KnockbackTrajectory = new Vector3D(4.5f, 1.2f, 0.0f)
                },
                FollowupMoveIds = new List<string> { "elara_sol_ability1", "elara_sol_ability2", "elara_sol_ability3", "elara_sol_ultimate" }
            };

            var heavy = new ComboMoveData
            {
                MoveId = "elara_sol_heavy",
                AnimationStateName = "ElaraSol_Attack_Heavy",
                AttackType = AttackType.Heavy,
                Property = AttackProperty.Mid,
                StartupFrames = 11,
                ActiveFrames = 5,
                RecoveryFrames = 16,
                CancelWindowStartFrame = 13,
                CancelWindowEndFrame = 20,
                AllowedCancelType = CancelWindowType.SpecialCancelable,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "elara_sol_hb_heavy",
                    OwnerFighterId = FighterId,
                    Radius = 1.15f,
                    BaseDamage = 82.0f,
                    GuardDamage = 38.0f,
                    HitstunSeconds = 0.55f,
                    BlockstunSeconds = 0.30f,
                    HitstopFrames = GameConstants.HITSTOP_HEAVY_FRAMES,
                    HitReaction = HitReactionType.Crumple,
                    KnockbackTrajectory = new Vector3D(7.0f, 2.5f, 0.0f),
                    WallSplatTrigger = true
                },
                FollowupMoveIds = new List<string> { "elara_sol_ability1", "elara_sol_ability2" }
            };

            var launcher = new ComboMoveData
            {
                MoveId = "elara_sol_launcher",
                AnimationStateName = "ElaraSol_Attack_Launcher",
                AttackType = AttackType.Launcher,
                Property = AttackProperty.Low,
                StartupFrames = 8,
                ActiveFrames = 4,
                RecoveryFrames = 14,
                CancelWindowStartFrame = 10,
                CancelWindowEndFrame = 17,
                AllowedCancelType = CancelWindowType.JumpCancelable,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = "elara_sol_hb_launcher",
                    OwnerFighterId = FighterId,
                    Radius = 0.95f,
                    BaseDamage = 58.0f,
                    GuardDamage = 20.0f,
                    HitstunSeconds = 0.65f,
                    BlockstunSeconds = 0.22f,
                    HitReaction = HitReactionType.LaunchUp,
                    KnockbackTrajectory = new Vector3D(1.2f, 10.5f, 0.0f)
                },
                FollowupMoveIds = new List<string> { "elara_sol_air_strike" }
            };

            Moves.RegisterMove(light1);
            Moves.RegisterMove(light2);
            Moves.RegisterMove(light3);
            Moves.RegisterMove(heavy);
            Moves.RegisterMove(launcher);
        }

        private void InitializeElaraSolHurtboxOffsets()
        {
            Hurtboxes.Clear();
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.Head, RelativeOffset = new Vector3D(0, 1.65f, 0), Radius = 0.34f, Height = 0.40f, DamageMultiplier = 1.25f });
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.Torso, RelativeOffset = new Vector3D(0, 1.05f, 0), Radius = 0.52f, Height = 0.85f, DamageMultiplier = 1.0f });
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.LowerLimbs, RelativeOffset = new Vector3D(0, 0.42f, 0), Radius = 0.42f, Height = 0.85f, DamageMultiplier = 0.85f });
        }

        public void AddSolarGraceMeter(float amount)
        {
            SolarGraceMeter = MathUtility.Clamp(SolarGraceMeter + amount, 0.0f, MAX_SOLARGRACE_METER);
            OnSolarGraceChanged?.Invoke(SolarGraceMeter);
        }

        public void EnterSolarGraceStance(float duration)
        {
            IsInUniqueStance = true;
            StanceDurationRemaining = duration;
        }

        public void ExitSolarGraceStance()
        {
            IsInUniqueStance = false;
            StanceDurationRemaining = 0.0f;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (IsInUniqueStance)
            {
                StanceDurationRemaining -= deltaTime;
                if (StanceDurationRemaining <= 0.0f)
                {
                    ExitSolarGraceStance();
                }
            }
        }

        private void ApplyAwakenedRadianceSurge()
        {
            AddSolarGraceMeter(25.0f);
            Ether.AddEther(10.0f);
        }

        private void OnRadianceAbilityTriggered(string abilityName, int index)
        {
            OnElementalSurge?.Invoke(abilityName, index);
        }

        
        /// <summary>
        /// Ability 1: Dawn Piercer
        /// Long-range piercing solar beam
        /// Cost: 20 Ether | Cooldown: 4.0s
        /// </summary>
        public virtual void ExecuteAbility1()
        {
            if (!Abilities.IsAbilityReady("elara_sol_ability1", Ether, Status)) return;
            if (!Abilities.TryCastAbility("elara_sol_ability1", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Dawn Piercer
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("elara_sol_ability1");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedRadianceSurge();
            }

            OnRadianceAbilityTriggered("Dawn Piercer", 1);
        }

        /// <summary>
        /// Ability 2: Blinding Sun
        /// Radial flash applying Blind
        /// Cost: 30 Ether | Cooldown: 7.0s
        /// </summary>
        public virtual void ExecuteAbility2()
        {
            if (!Abilities.IsAbilityReady("elara_sol_ability2", Ether, Status)) return;
            if (!Abilities.TryCastAbility("elara_sol_ability2", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Blinding Sun
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("elara_sol_ability2");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedRadianceSurge();
            }

            OnRadianceAbilityTriggered("Blinding Sun", 2);
        }

        /// <summary>
        /// Ability 3: Aegis of Dawn
        /// Cleanse debuffs and create shield
        /// Cost: 25 Ether | Cooldown: 6.0s
        /// </summary>
        public virtual void ExecuteAbility3()
        {
            if (!Abilities.IsAbilityReady("elara_sol_ability3", Ether, Status)) return;
            if (!Abilities.TryCastAbility("elara_sol_ability3", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Aegis of Dawn
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("elara_sol_ability3");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedRadianceSurge();
            }

            OnRadianceAbilityTriggered("Aegis of Dawn", 3);
        }

        /// <summary>
        /// Ability 4: Solar Judgment
        /// Incinerating pillar of holy light
        /// Cost: 35 Ether | Cooldown: 9.0s
        /// </summary>
        public virtual void ExecuteAbility4()
        {
            if (!Abilities.IsAbilityReady("elara_sol_ability4", Ether, Status)) return;
            if (!Abilities.TryCastAbility("elara_sol_ability4", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Solar Judgment
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("elara_sol_ability4");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedRadianceSurge();
            }

            OnRadianceAbilityTriggered("Solar Judgment", 4);
        }


        /// <summary>
        /// Ultimate Finisher Execution
        /// </summary>
        public virtual void ExecuteUltimateFinisher()
        {
            if (!Awakening.CanExecuteUltimate(Ether)) return;
            if (!Ether.TryConsume(30.0f)) return;

            FSM.ChangeState<FighterUltimateState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("elara_sol_ultimate");

            EventManager.Publish(new UltimateExecutedEvent
            {
                FighterId = FighterId,
                UltimateName = Definition.UltimateName
            });
        }
    }

    // State stubs for FSM integration
    public class FighterAbilityState : IState<FighterBase>
    {
        public void OnEnter(FighterBase entity) { }
        public void OnUpdate(FighterBase entity, float deltaTime) { }
        public void OnFixedUpdate(FighterBase entity, float fixedDeltaTime) { }
        public void OnExit(FighterBase entity) { }
    }

    public class FighterUltimateState : IState<FighterBase>
    {
        public void OnEnter(FighterBase entity) { }
        public void OnUpdate(FighterBase entity, float deltaTime) { }
        public void OnFixedUpdate(FighterBase entity, float fixedDeltaTime) { }
        public void OnExit(FighterBase entity) { }
    }
}
