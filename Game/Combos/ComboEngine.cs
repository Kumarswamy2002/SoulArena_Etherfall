using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combos
{
    /// <summary>
    /// Real-time combo tracking engine managing hit streaks, damage scaling decay, juggle states, and combo breakers.
    /// </summary>
    public class ComboEngine
    {
        public int AttackerId { get; private set; }
        public int CurrentComboHits { get; private set; } = 0;
        public float CurrentComboDamage { get; private set; } = 0.0f;
        public float CurrentDamageScaling { get; private set; } = 1.0f;
        
        public int CurrentJuggleHits { get; private set; } = 0;
        public bool IsOpponentAirborne { get; set; } = false;
        public bool IsOpponentWallSplatted { get; set; } = false;
        
        public float ComboResetTimer { get; private set; } = 0.0f;
        public const float COMBO_DROP_TIMEOUT = 1.10f; // Seconds before combo resets on drop

        public event Action<int, float, float> OnComboUpdated;
        public event Action<int, float> OnComboDropped;
        public event Action<int> OnComboBreakerTriggered;

        public ComboEngine(int attackerId)
        {
            AttackerId = attackerId;
        }

        public void RegisterHit(HitResult hit)
        {
            if (!hit.HitConnected) return;

            CurrentComboHits++;
            CurrentComboDamage += hit.FinalDamage;
            ComboResetTimer = COMBO_DROP_TIMEOUT;

            // Recalculate scaling
            CurrentDamageScaling = Math.Max(GameConstants.MIN_DAMAGE_SCALING, 1.0f - (CurrentComboHits * GameConstants.DAMAGE_SCALING_PER_HIT));

            if (IsOpponentAirborne)
            {
                CurrentJuggleHits++;
            }

            OnComboUpdated?.Invoke(CurrentComboHits, CurrentComboDamage, CurrentDamageScaling);
            EventManager.Publish(new ComboCountUpdatedEvent
            {
                AttackerId = AttackerId,
                HitCount = CurrentComboHits,
                TotalDamage = CurrentComboDamage,
                CurrentDamageScaling = CurrentDamageScaling
            });
        }

        public bool TryExecuteComboBreaker(float currentEther, float currentResonance, out float etherCost, out float resonanceCost)
        {
            etherCost = GameConstants.COMBO_BREAKER_ETHER_COST;
            resonanceCost = GameConstants.COMBO_BREAKER_RESONANCE_COST;

            if (currentEther >= etherCost && currentResonance >= resonanceCost)
            {
                ResetCombo();
                OnComboBreakerTriggered?.Invoke(AttackerId);
                return true;
            }

            return false;
        }

        public void Update(float deltaTime)
        {
            if (CurrentComboHits > 0)
            {
                ComboResetTimer -= deltaTime;
                if (ComboResetTimer <= 0.0f)
                {
                    ResetCombo();
                }
            }
        }

        public void ResetCombo()
        {
            if (CurrentComboHits > 0)
            {
                OnComboDropped?.Invoke(CurrentComboHits, CurrentComboDamage);
            }

            CurrentComboHits = 0;
            CurrentComboDamage = 0.0f;
            CurrentDamageScaling = 1.0f;
            CurrentJuggleHits = 0;
            IsOpponentAirborne = false;
            IsOpponentWallSplatted = false;
            ComboResetTimer = 0.0f;
        }
    }
}
