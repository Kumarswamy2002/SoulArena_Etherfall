using System;
using SoulArena.Core;

namespace SoulArena.Resonance
{
    /// <summary>
    /// Resonance represents combat synergy and mastery gained through successful attacks, perfect defense, and counters.
    /// Unlocks Awakening state when reaching 100%.
    /// </summary>
    public class ResonanceSystem
    {
        public int FighterId { get; private set; }
        public float CurrentResonance { get; private set; }
        public float MaxResonance { get; private set; }
        public bool IsAwakeningReady => CurrentResonance >= GameConstants.AWAKENING_THRESHOLD;

        public event Action<float, float> OnResonanceChanged;
        public event Action OnAwakeningReady;

        public ResonanceSystem(int fighterId, float maxResonance = GameConstants.DEFAULT_MAX_RESONANCE)
        {
            FighterId = fighterId;
            MaxResonance = maxResonance;
            CurrentResonance = 0.0f;
        }

        public void AddResonance(float amount)
        {
            if (amount <= 0.0f) return;

            bool wasReady = IsAwakeningReady;
            CurrentResonance = Math.Min(MaxResonance, CurrentResonance + amount);
            OnResonanceChanged?.Invoke(CurrentResonance, MaxResonance);

            if (!wasReady && IsAwakeningReady)
            {
                OnAwakeningReady?.Invoke();
            }
        }

        public bool TryConsumeResonance(float amount)
        {
            if (CurrentResonance >= amount)
            {
                CurrentResonance -= amount;
                OnResonanceChanged?.Invoke(CurrentResonance, MaxResonance);
                return true;
            }
            return false;
        }

        public void Reset()
        {
            CurrentResonance = 0.0f;
            OnResonanceChanged?.Invoke(CurrentResonance, MaxResonance);
        }
    }
}
