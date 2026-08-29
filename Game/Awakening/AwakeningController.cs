using System;
using SoulArena.Core;
using SoulArena.Resonance;
using SoulArena.Ether;

namespace SoulArena.Awakening
{
    public class AwakeningModifiers
    {
        public float DamageMultiplier = GameConstants.AWAKENING_DAMAGE_MODIFIER;
        public float DefenseMultiplier = GameConstants.AWAKENING_DEFENSE_MODIFIER;
        public float SpeedMultiplier = GameConstants.AWAKENING_SPEED_MODIFIER;
        public float CooldownReduction = GameConstants.AWAKENING_COOLDOWN_REDUCTION;
        public bool InfiniteEther = false;
        public string TransformationVFX = string.Empty;
    }

    /// <summary>
    /// Controls Awakening transformation states, duration countdown, buff modifiers, and Ultimate execution conditions.
    /// </summary>
    public class AwakeningController
    {
        public int FighterId { get; private set; }
        public EtherElement Element { get; private set; }
        public bool IsAwakened { get; private set; }
        public float DurationRemaining { get; private set; }
        public float TotalDuration { get; private set; } = GameConstants.AWAKENING_DURATION;
        public AwakeningModifiers Modifiers { get; private set; } = new AwakeningModifiers();

        public event Action<int, float> OnAwakeningStarted;
        public event Action<int> OnAwakeningEnded;

        public AwakeningController(int fighterId, EtherElement element)
        {
            FighterId = fighterId;
            Element = element;
            IsAwakened = false;
            DurationRemaining = 0.0f;
        }

        public bool TryActivateAwakening(ResonanceSystem resonance)
        {
            if (IsAwakened) return false;
            if (resonance == null || !resonance.IsAwakeningReady) return false;

            resonance.Reset(); // Consume full resonance meter
            IsAwakened = true;
            DurationRemaining = TotalDuration;

            EventManager.Publish(new AwakeningActivatedEvent
            {
                FighterId = FighterId,
                Duration = TotalDuration,
                Element = Element
            });

            OnAwakeningStarted?.Invoke(FighterId, TotalDuration);
            return true;
        }

        public void Update(float deltaTime)
        {
            if (!IsAwakened) return;

            DurationRemaining -= deltaTime;
            if (DurationRemaining <= 0.0f)
            {
                DeactivateAwakening();
            }
        }

        public void DeactivateAwakening()
        {
            if (!IsAwakened) return;

            IsAwakened = false;
            DurationRemaining = 0.0f;

            EventManager.Publish(new AwakeningEndedEvent { FighterId = FighterId });
            OnAwakeningEnded?.Invoke(FighterId);
        }

        public bool CanExecuteUltimate(EtherResource ether)
        {
            // Ultimates require being in Awakening mode and having at least 30 Ether
            return IsAwakened && ether != null && ether.CurrentEther >= 30.0f;
        }
    }
}
