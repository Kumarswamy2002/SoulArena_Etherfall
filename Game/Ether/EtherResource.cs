using System;
using SoulArena.Core;

namespace SoulArena.Ether
{
    /// <summary>
    /// Core internal energy system powering movement skills, special abilities, and defensive maneuvers.
    /// Features offensive momentum generation and burnout lockout.
    /// </summary>
    public class EtherResource
    {
        public int FighterId { get; private set; }
        public float CurrentEther { get; private set; }
        public float MaxEther { get; private set; }
        public float Momentum { get; private set; } // 0-100 gauge amplifying Ether regen
        public bool IsInBurnout { get; private set; }
        public float BurnoutTimer { get; private set; }

        public const float BURNOUT_DURATION = 3.0f;

        public event Action<float, float> OnEtherChanged;
        public event Action<float> OnMomentumChanged;
        public event Action OnBurnoutStarted;
        public event Action OnBurnoutEnded;

        public EtherResource(int fighterId, float maxEther = GameConstants.DEFAULT_MAX_ETHER)
        {
            FighterId = fighterId;
            MaxEther = maxEther;
            CurrentEther = maxEther * 0.5f; // Start matches with 50% Ether
            Momentum = 0.0f;
            IsInBurnout = false;
        }

        public bool TryConsume(float amount)
        {
            if (IsInBurnout) return false;
            if (CurrentEther >= amount)
            {
                CurrentEther -= amount;
                OnEtherChanged?.Invoke(CurrentEther, MaxEther);

                if (CurrentEther <= 0.0f)
                {
                    CurrentEther = 0.0f;
                    TriggerBurnout();
                }
                return true;
            }
            return false;
        }

        public void AddEther(float amount)
        {
            if (IsInBurnout) return;
            CurrentEther = Math.Min(MaxEther, CurrentEther + amount);
            OnEtherChanged?.Invoke(CurrentEther, MaxEther);
        }

        public void AddMomentum(float amount)
        {
            Momentum = Math.Min(GameConstants.DEFAULT_MAX_MOMENTUM, Momentum + amount);
            OnMomentumChanged?.Invoke(Momentum);
        }

        public void Update(float deltaTime, bool hasBurnStatus = false)
        {
            if (IsInBurnout)
            {
                BurnoutTimer -= deltaTime;
                if (BurnoutTimer <= 0.0f)
                {
                    IsInBurnout = false;
                    CurrentEther = MaxEther * 0.25f; // Recover to 25% upon burnout end
                    OnBurnoutEnded?.Invoke();
                    OnEtherChanged?.Invoke(CurrentEther, MaxEther);
                }
                return;
            }

            // Momentum naturally decays over time
            if (Momentum > 0.0f)
            {
                Momentum = Math.Max(0.0f, Momentum - (GameConstants.MOMENTUM_DECAY_RATE * deltaTime));
                OnMomentumChanged?.Invoke(Momentum);
            }

            // Passive Ether regeneration (halted if suffering from Burn status)
            if (!hasBurnStatus && CurrentEther < MaxEther)
            {
                float momentumMultiplier = 1.0f + (Momentum / 100.0f); // Up to 2x regen at max momentum
                float regenAmount = GameConstants.ETHER_PASSIVE_REGEN * momentumMultiplier * deltaTime;
                CurrentEther = Math.Min(MaxEther, CurrentEther + regenAmount);
                OnEtherChanged?.Invoke(CurrentEther, MaxEther);
            }
        }

        private void TriggerBurnout()
        {
            IsInBurnout = true;
            BurnoutTimer = BURNOUT_DURATION;
            Momentum = 0.0f;
            OnBurnoutStarted?.Invoke();
        }

        public void Reset()
        {
            CurrentEther = MaxEther * 0.5f;
            Momentum = 0.0f;
            IsInBurnout = false;
            BurnoutTimer = 0.0f;
        }
    }
}
