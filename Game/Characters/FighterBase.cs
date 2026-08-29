using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;
using SoulArena.Ether;
using SoulArena.Resonance;
using SoulArena.Awakening;
using SoulArena.Abilities;

namespace SoulArena.Characters
{
    /// <summary>
    /// Master abstract Fighter controller connecting all core game systems, inputs, physics, and state transitions.
    /// </summary>
    public class FighterBase
    {
        public int FighterId { get; private set; }
        public FighterDefinition Definition { get; private set; }
        public FighterStats CurrentStats { get; private set; }

        // Core Subsystems
        public StateMachine<FighterBase> FSM { get; private set; }
        public InputBuffer Input { get; private set; }
        public DefenseSystem Defense { get; private set; }
        public StatusEffectSystem Status { get; private set; }
        public EtherResource Ether { get; private set; }
        public ResonanceSystem Resonance { get; private set; }
        public AwakeningController Awakening { get; private set; }
        public ComboEngine ComboTracker { get; private set; }
        public ComboTree Moves { get; private set; }
        public AbilityController Abilities { get; private set; }

        // Transforms & Physics
        public Vector3D Position { get; set; }
        public Vector3D Velocity { get; set; }
        public bool FacingRight { get; set; } = true;
        public bool IsGrounded { get; set; } = true;

        // Health & Vitals
        public float CurrentHealth { get; private set; }
        public bool IsDead => CurrentHealth <= 0.0f;

        // Hitboxes & Hurtboxes
        public List<Hurtbox> Hurtboxes { get; private set; } = new List<Hurtbox>();
        public List<Hitbox> ActiveHitboxes { get; private set; } = new List<Hitbox>();

        // Current Action Frame State
        public ComboMoveData ActiveMove { get; private set; }
        public int CurrentMoveFrame { get; private set; }
        public float HitstunDurationRemaining { get; private set; }
        public float BlockstunDurationRemaining { get; private set; }

        // Events
        public event Action<float, float> OnHealthChanged;
        public event Action OnDefeated;

        public FighterBase(int fighterId, FighterDefinition definition)
        {
            FighterId = fighterId;
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
            CurrentStats = definition.BaseStats.Clone();
            CurrentHealth = CurrentStats.MaxHealth;

            // Instantiate Subsystems
            FSM = new StateMachine<FighterBase>(this);
            Input = new InputBuffer();
            Defense = new DefenseSystem(fighterId);
            Status = new StatusEffectSystem(fighterId);
            Ether = new EtherResource(fighterId);
            Resonance = new ResonanceSystem(fighterId);
            Awakening = new AwakeningController(fighterId, definition.Element);
            ComboTracker = new ComboEngine(fighterId);
            Moves = new ComboTree();
            Abilities = new AbilityController(fighterId);

            SetupDefaultHurtboxes();
            SubscribeStatusEvents();
        }

        private void SetupDefaultHurtboxes()
        {
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.Head, RelativeOffset = new Vector3D(0, 1.6f, 0), Radius = 0.35f, Height = 0.4f, DamageMultiplier = 1.25f });
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.Torso, RelativeOffset = new Vector3D(0, 1.0f, 0), Radius = 0.50f, Height = 0.8f, DamageMultiplier = 1.0f });
            Hurtboxes.Add(new Hurtbox { OwnerFighterId = FighterId, Region = BodyPart.LowerLimbs, RelativeOffset = new Vector3D(0, 0.4f, 0), Radius = 0.40f, Height = 0.8f, DamageMultiplier = 0.85f });
        }

        private void SubscribeStatusEvents()
        {
            Status.OnStatusDamageTick += (dmg, type, inflictor) => TakeDirectDamage(dmg, type.ToString());
            Status.OnEtherDrained += (amount, inflictor) => Ether.TryConsume(amount);
        }

        public void TakeDirectDamage(float damage, string source)
        {
            if (IsDead) return;
            CurrentHealth = Math.Max(0.0f, CurrentHealth - damage);
            OnHealthChanged?.Invoke(CurrentHealth, CurrentStats.MaxHealth);

            if (CurrentHealth <= 0.0f)
            {
                CurrentHealth = 0.0f;
                OnDefeated?.Invoke();
            }
        }

        public void ApplyDamage(HitResult hit)
        {
            if (IsDead) return;
            TakeDirectDamage(hit.FinalDamage, "CombatHit");

            // Build Ether for defender as comeback mechanic
            Ether.AddEther(hit.EtherGainedDefender);

            if (hit.DefenseResult == DefenseType.StandardBlock)
            {
                BlockstunDurationRemaining = hit.BlockstunDuration;
            }
            else
            {
                HitstunDurationRemaining = hit.HitstunDuration;
                // Apply knockback
                float dir = FacingRight ? -1.0f : 1.0f;
                Velocity = new Vector3D(hit.Knockback.X * dir, hit.Knockback.Y, hit.Knockback.Z);
                if (hit.Knockback.Y > 2.0f)
                {
                    IsGrounded = false;
                }
            }
        }

        public void StartMove(ComboMoveData move)
        {
            if (move == null) return;
            ActiveMove = move;
            CurrentMoveFrame = 0;
            ActiveHitboxes.Clear();
        }

        public void Update(float deltaTime)
        {
            if (IsDead) return;

            bool isMoving = Math.Abs(Velocity.X) > 0.1f || Math.Abs(Velocity.Z) > 0.1f;
            Status.Update(deltaTime, isMoving);
            Defense.Update(deltaTime);
            Ether.Update(deltaTime, Status.HasStatus(StatusEffectType.Burn));
            Awakening.Update(deltaTime);
            ComboTracker.Update(deltaTime);
            Abilities.Update(deltaTime);

            // Update frame counts for active attacks
            if (ActiveMove != null)
            {
                CurrentMoveFrame++;
                if (CurrentMoveFrame >= ActiveMove.TotalFrames)
                {
                    ActiveMove = null;
                    CurrentMoveFrame = 0;
                    ActiveHitboxes.Clear();
                }
            }

            // Simple physics integration
            Position += Velocity * deltaTime;
            if (!IsGrounded)
            {
                Velocity = new Vector3D(Velocity.X * 0.95f, Velocity.Y - (25.0f * CurrentStats.Weight * deltaTime), Velocity.Z * 0.95f);
                if (Position.Y <= 0.0f)
                {
                    Position = new Vector3D(Position.X, 0.0f, Position.Z);
                    Velocity = new Vector3D(Velocity.X * 0.5f, 0.0f, Velocity.Z * 0.5f);
                    IsGrounded = true;
                }
            }
            else
            {
                // Ground friction
                Velocity = new Vector3D(Velocity.X * 0.85f, 0.0f, Velocity.Z * 0.85f);
            }
        }

        public void ResetFighterForNewRound(Vector3D spawnPos, bool facingRight)
        {
            Position = spawnPos;
            Velocity = Vector3D.Zero;
            FacingRight = facingRight;
            IsGrounded = true;
            CurrentHealth = CurrentStats.MaxHealth;
            ActiveMove = null;
            CurrentMoveFrame = 0;
            ActiveHitboxes.Clear();
            HitstunDurationRemaining = 0.0f;
            BlockstunDurationRemaining = 0.0f;

            Defense.ResetGuard();
            Status.ClearAllStatuses();
            Ether.Reset();
            Resonance.Reset();
            Awakening.DeactivateAwakening();
            ComboTracker.ResetCombo();
            Abilities.ResetCooldowns();
            Input.Clear();

            OnHealthChanged?.Invoke(CurrentHealth, CurrentStats.MaxHealth);
        }
    }
}
