using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Combat;

namespace SoulArena.AI.Personalities
{
    /// <summary>
    /// Utility AI Decision Engine for CounterFighter Personality.
    /// Aggressiveness: 0.4 | Guard Weight: 0.7 | Parry Risk: 0.8 | Preferred Distance: 3.2m
    /// </summary>
    public class CounterFighterDecisionEngine
    {
        public float AggressivenessScore { get; private set; } = 0.4f;
        public float DefensiveScore { get; private set; } = 0.7f;
        public float ParryTendency { get; private set; } = 0.8f;
        public float AbilityHunger { get; private set; } = 0.65f;
        public float IdealSpacingDistance { get; private set; } = 3.2f;
        public float ComboBreakerUrgency { get; private set; } = 0.8f;

        private readonly Random _rng = new Random();

        public float EvaluateOffensiveUtility(FighterBase self, FighterBase opponent, float distance)
        {
            float score = AggressivenessScore * 100.0f;

            // Bonus if opponent is in recovery frames
            if (opponent.ActiveMove != null && opponent.CurrentMoveFrame > opponent.ActiveMove.HitboxDefinition.ActiveEndFrame)
            {
                score += 40.0f;
            }

            // Bonus if opponent guard is broken
            if (opponent.Defense.IsGuardBroken)
            {
                score += 80.0f;
            }

            // Range penalty
            float distDelta = Math.Abs(distance - IdealSpacingDistance);
            score -= distDelta * 10.0f;

            return Math.Max(0.0f, score);
        }

        public float EvaluateDefensiveUtility(FighterBase self, FighterBase opponent, float distance)
        {
            float score = DefensiveScore * 100.0f;

            // High priority when opponent is attacking within striking range
            if (opponent.ActiveMove != null && distance <= 3.5f)
            {
                score += 60.0f;
            }

            // Risk of guard break lowers block utility
            if (self.Defense.CurrentGuard < 30.0f)
            {
                score -= 40.0f; // Prefer dodge over block
            }

            return Math.Max(0.0f, score);
        }

        public bool ShouldAttemptParry(FighterBase opponent)
        {
            if (opponent.ActiveMove == null) return false;
            return _rng.NextDouble() < ParryTendency;
        }

        public bool ShouldTriggerComboBreaker(FighterBase self, FighterBase opponent)
        {
            if (opponent.ComboTracker.CurrentComboHits < 3) return false;
            if (self.Ether.CurrentEther < GameConstants.COMBO_BREAKER_ETHER_COST) return false;
            return _rng.NextDouble() < ComboBreakerUrgency;
        }
    }
}
