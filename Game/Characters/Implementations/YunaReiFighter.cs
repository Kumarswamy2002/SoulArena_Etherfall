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
    /// Fighter Implementation: Yuna Rei (Spirit Dancer)
    /// Element: Spirit | Role: Technical Fighter | Weapon: Ribbon Blades
    /// Unique Mechanic: SpiritRhythm
    /// </summary>
    public class YunaReiFighter : FighterBase
    {
        // Unique Fighter State Fields
        public float SpiritRhythmMeter { get; private set; } = 0.0f;
        public const float MAX_SPIRITRHYTHM_METER = 100.0f;
        public int ConsecutiveChainStreak { get; private set; } = 0;
        public bool IsInUniqueStance { get; private set; } = false;
        public float StanceDurationRemaining { get; private set; } = 0.0f;

        public event Action<float> OnSpiritRhythmChanged;
        public event Action<string, int> OnElementalSurge;

        public YunaReiFighter(int runtimeId, FighterDefinition definition) : base(runtimeId, definition)
        {
            InitializeYunaReiCustomMoveTree();
            InitializeYunaReiHurtboxOffsets();
        }

        private void InitializeYunaReiCustomMoveTree()
        {
            // Custom attack chain configurations
            var light1 = new ComboMoveData
            {
                MoveId = "yuna_rei_light1",
                AnimationStateName = "YunaRei_Attack_Light1",
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
                    HitboxId = "yuna_rei_hb_l1",
                    OwnerFighterId = FighterId,
                    Radius = 0.75f,
                    BaseDamage = 26.0f,
                    GuardDamage = 11.0f,
                    HitstunSeconds = 0.32f,
                    BlockstunSeconds = 0.18f,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { "yuna_rei_light2", "yuna_rei_heavy" }
            };

            var light2 = new ComboMoveData
            {
                MoveId = "yuna_rei_light2",
                AnimationStateName = "YunaRei_Attack_Light2",
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
                    HitboxId = "yuna_rei_hb_l2",
                    OwnerFighterId = FighterId,
                    Radius = 0.80f,
                    BaseDamage = 36.0f,
                    GuardDamage = 14.0f,
                    HitstunSeconds = 0.36f,
                    BlockstunSeconds = 0.20f,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { "yuna_rei_light3", "yuna_rei_launcher", "yuna_rei_ability1" }
            };

            var light3 = new ComboMoveData
            {
                MoveId = "yuna_rei_light3",
                AnimationStateName = "YunaRei_Attack_Light3",
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
                    HitboxId = "yuna_rei_hb_l3",
                    OwnerFighterId = FighterId,
                    Radius = 0.90f,
                    BaseDamage = 48.0f,
                    GuardDamage = 18.0f,
                    HitstunSeconds = 0.42f,
                    BlockstunSeconds = 0.24f,
                    HitReaction = HitReactionType.HeavyStagger,
                    KnockbackTrajectory = new Vector3D(4.5f, 1.2f, 0.0f)
                },
                FollowupMoveIds = new List<string> { "yuna_rei_ability1", "yuna_rei_ability2", "yuna_rei_ability3", "yuna_rei_ultimate" }
            };

            var heavy = new ComboMoveData
            {
                MoveId = "yuna_rei_heavy",
                AnimationStateName = "YunaRei_Attack_Heavy",
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
                    HitboxId = "yuna_rei_hb_heavy",
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
                FollowupMoveIds = new List<string> { "yuna_rei_ability1", "yuna_rei_ability2" }
            };

            var launcher = new ComboMoveData
            {
                MoveId = "yuna_rei_launcher",
                AnimationStateName = "YunaRei_Attack_Launcher",
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
                    HitboxId = "yuna_rei_hb_launcher",
                    OwnerFighterId = FighterId,
                    Radius = 0.95f,
                    BaseDamage = 58.0f,
                    GuardDamage = 20.0f,
                    HitstunSeconds = 0.65f,
                    BlockstunSeconds = 0.22f,
                    HitReaction = HitReactionType.LaunchUp,
                    KnockbackTrajectory = new Vector3D(1.2f, 10.5f, 0.0f)
                },
                FollowupMoveIds = new List<string> { "yuna_rei_air_strike" }
            };

            Moves.RegisterMove(light1);
            Moves.RegisterMove(light2);
            Moves.RegisterMove(light3);
            Moves.RegisterMove(heavy);
            Moves.RegisterMove(launcher);
        }

        private void InitializeYunaReiHurtboxOffsets()
        {
            Hurtboxes.Clear();
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.Head, RelativeOffset = new Vector3D(0, 1.65f, 0), Radius = 0.34f, Height = 0.40f, DamageMultiplier = 1.25f });
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.Torso, RelativeOffset = new Vector3D(0, 1.05f, 0), Radius = 0.52f, Height = 0.85f, DamageMultiplier = 1.0f });
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.LowerLimbs, RelativeOffset = new Vector3D(0, 0.42f, 0), Radius = 0.42f, Height = 0.85f, DamageMultiplier = 0.85f });
        }

        public void AddSpiritRhythmMeter(float amount)
        {
            SpiritRhythmMeter = MathUtility.Clamp(SpiritRhythmMeter + amount, 0.0f, MAX_SPIRITRHYTHM_METER);
            OnSpiritRhythmChanged?.Invoke(SpiritRhythmMeter);
        }

        public void EnterSpiritRhythmStance(float duration)
        {
            IsInUniqueStance = true;
            StanceDurationRemaining = duration;
        }

        public void ExitSpiritRhythmStance()
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
                    ExitSpiritRhythmStance();
                }
            }
        }

        private void ApplyAwakenedSpiritSurge()
        {
            AddSpiritRhythmMeter(25.0f);
            Ether.AddEther(10.0f);
        }

        private void OnSpiritAbilityTriggered(string abilityName, int index)
        {
            OnElementalSurge?.Invoke(abilityName, index);
        }

        
        /// <summary>
        /// Ability 1: Blossom Pirouette
        /// Spinning ribbon slash circle
        /// Cost: 20 Ether | Cooldown: 4.0s
        /// </summary>
        public virtual void ExecuteAbility1()
        {
            if (!Abilities.IsAbilityReady("yuna_rei_ability1", Ether, Status)) return;
            if (!Abilities.TryCastAbility("yuna_rei_ability1", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Blossom Pirouette
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("yuna_rei_ability1");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedSpiritSurge();
            }

            OnSpiritAbilityTriggered("Blossom Pirouette", 1);
        }

        /// <summary>
        /// Ability 2: Ribbon Entangle
        /// Disarms and roots enemy limbs
        /// Cost: 30 Ether | Cooldown: 7.0s
        /// </summary>
        public virtual void ExecuteAbility2()
        {
            if (!Abilities.IsAbilityReady("yuna_rei_ability2", Ether, Status)) return;
            if (!Abilities.TryCastAbility("yuna_rei_ability2", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Ribbon Entangle
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("yuna_rei_ability2");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedSpiritSurge();
            }

            OnSpiritAbilityTriggered("Ribbon Entangle", 2);
        }

        /// <summary>
        /// Ability 3: Sacred Flow
        /// Cleanses status and grants speed
        /// Cost: 25 Ether | Cooldown: 6.0s
        /// </summary>
        public virtual void ExecuteAbility3()
        {
            if (!Abilities.IsAbilityReady("yuna_rei_ability3", Ether, Status)) return;
            if (!Abilities.TryCastAbility("yuna_rei_ability3", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Sacred Flow
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("yuna_rei_ability3");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedSpiritSurge();
            }

            OnSpiritAbilityTriggered("Sacred Flow", 3);
        }

        /// <summary>
        /// Ability 4: Dance of Thousand Souls
        /// Flurry of spirit blossoms
        /// Cost: 35 Ether | Cooldown: 9.0s
        /// </summary>
        public virtual void ExecuteAbility4()
        {
            if (!Abilities.IsAbilityReady("yuna_rei_ability4", Ether, Status)) return;
            if (!Abilities.TryCastAbility("yuna_rei_ability4", Ether, Awakening, Status, out var abilityData)) return;

            // Execute Dance of Thousand Souls
            FSM.ChangeState<FighterAbilityState>();
            CurrentMoveFrame = 0;
            ActiveMove = Moves.GetMove("yuna_rei_ability4");

            // Apply unique elemental combat traits
            if (Awakening.IsAwakened)
            {
                ApplyAwakenedSpiritSurge();
            }

            OnSpiritAbilityTriggered("Dance of Thousand Souls", 4);
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
            ActiveMove = Moves.GetMove("yuna_rei_ultimate");

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
