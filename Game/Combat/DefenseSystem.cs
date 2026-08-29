using System;
using SoulArena.Core;

namespace SoulArena.Combat
{
    /// <summary>
    /// Manages Guard Meter, Perfect Guard window detection, Perfect Dodge, Parry windows, and Guard Breaks.
    /// </summary>
    public class DefenseSystem
    {
        public int FighterId { get; private set; }
        public float CurrentGuard { get; private set; } = GameConstants.DEFAULT_MAX_GUARD;
        public float MaxGuard { get; private set; } = GameConstants.DEFAULT_MAX_GUARD;
        public bool IsGuardBroken { get; private set; } = false;
        public float GuardBreakTimer { get; private set; } = 0.0f;

        // Timers & Active Windows
        public float BlockHoldDuration { get; private set; } = 0.0f;
        public bool IsBlocking { get; private set; } = false;
        
        public float DodgeDuration { get; private set; } = 0.0f;
        public bool IsDodging { get; private set; } = false;
        
        public float ParryDuration { get; private set; } = 0.0f;
        public bool IsParrying { get; private set; } = false;

        private float _timeSinceLastBlockHit = 0.0f;

        public DefenseSystem(int fighterId, float maxGuard = GameConstants.DEFAULT_MAX_GUARD)
        {
            FighterId = fighterId;
            MaxGuard = maxGuard;
            CurrentGuard = maxGuard;
        }

        public void StartBlocking()
        {
            if (IsGuardBroken || IsDodging) return;
            IsBlocking = true;
            BlockHoldDuration = 0.0f;
        }

        public void StopBlocking()
        {
            IsBlocking = false;
            BlockHoldDuration = 0.0f;
        }

        public void StartDodge()
        {
            if (IsGuardBroken) return;
            IsDodging = true;
            DodgeDuration = 0.0f;
            IsBlocking = false;
        }

        public void StartParry()
        {
            if (IsGuardBroken || IsDodging) return;
            IsParrying = true;
            ParryDuration = 0.0f;
            IsBlocking = false;
        }

        public void Update(float deltaTime)
        {
            if (IsGuardBroken)
            {
                GuardBreakTimer -= deltaTime;
                if (GuardBreakTimer <= 0.0f)
                {
                    IsGuardBroken = false;
                    CurrentGuard = MaxGuard * 0.5f; // Recover to 50% guard after break
                }
                return;
            }

            if (IsBlocking)
            {
                BlockHoldDuration += deltaTime;
            }
            else
            {
                _timeSinceLastBlockHit += deltaTime;
                if (_timeSinceLastBlockHit >= GameConstants.GUARD_REGEN_DELAY && CurrentGuard < MaxGuard)
                {
                    CurrentGuard = Math.Min(MaxGuard, CurrentGuard + (GameConstants.GUARD_REGEN_RATE * deltaTime));
                }
            }

            if (IsDodging)
            {
                DodgeDuration += deltaTime;
                if (DodgeDuration > 0.40f) // Total dodge animation time
                {
                    IsDodging = false;
                }
            }

            if (IsParrying)
            {
                ParryDuration += deltaTime;
                if (ParryDuration > (GameConstants.PARRY_ACTIVE_WINDOW_SECONDS + GameConstants.PARRY_RECOVERY_SECONDS))
                {
                    IsParrying = false;
                }
            }
        }

        public DefenseType EvaluateDefense(HitboxData incomingHit)
        {
            if (IsGuardBroken) return DefenseType.None;

            // 1. Parry Evaluation (must be active and attack must be parryable)
            if (IsParrying && ParryDuration <= GameConstants.PARRY_ACTIVE_WINDOW_SECONDS)
            {
                if (incomingHit.CanBeParried && incomingHit.Property != AttackProperty.Unblockable && incomingHit.Property != AttackProperty.Grab)
                {
                    return DefenseType.ParrySuccess;
                }
            }

            // 2. Dodge Evaluation
            if (IsDodging)
            {
                if (DodgeDuration <= GameConstants.PERFECT_DODGE_WINDOW_SECONDS)
                {
                    return DefenseType.PerfectDodge;
                }
                else if (DodgeDuration <= 0.25f) // Normal i-frames window
                {
                    return DefenseType.Dodge;
                }
            }

            // 3. Block Evaluation
            if (IsBlocking && incomingHit.Property != AttackProperty.Unblockable && incomingHit.Property != AttackProperty.Grab)
            {
                _timeSinceLastBlockHit = 0.0f;

                // Perfect Guard check: within 4 frames of raising guard
                if (BlockHoldDuration <= GameConstants.PERFECT_GUARD_WINDOW_SECONDS)
                {
                    return DefenseType.PerfectGuard;
                }

                // Standard Guard: drains guard meter
                CurrentGuard -= incomingHit.GuardDamage;
                if (CurrentGuard <= 0.0f)
                {
                    CurrentGuard = 0.0f;
                    IsGuardBroken = true;
                    IsBlocking = false;
                    GuardBreakTimer = GameConstants.GUARD_BREAK_STUN_DURATION;
                    EventManager.Publish(new GuardBreakEvent { FighterId = FighterId, StunDuration = GuardBreakTimer });
                }

                return DefenseType.StandardBlock;
            }

            return DefenseType.None;
        }

        public void ResetGuard()
        {
            CurrentGuard = MaxGuard;
            IsGuardBroken = false;
            GuardBreakTimer = 0.0f;
            IsBlocking = false;
            IsDodging = false;
            IsParrying = false;
        }
    }
}
