using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.AI.Sensors
{
    /// <summary>
    /// Fuzzy Logic Evaluation Engine for Vexa Noir (Void Walker).
    /// Outputs fuzzy probability curves for offensive commitment, defensive turtling, and risky counters.
    /// </summary>
    public class VexaNoirFuzzyEvaluator
    {
        public float CalculateAttackDesirability(float healthPercent, float enemyHealthPercent, float distance, float ether)
        {
            // Fuzzy curve: High attack desirability when enemy is low or distance is within striking zone
            float distanceFactor = Math.Max(0.0f, 1.0f - (distance / 6.0f));
            float etherFactor = ether / 100.0f;
            float advantageFactor = (healthPercent - enemyHealthPercent) * 0.5f;

            float score = (distanceFactor * 0.5f) + (etherFactor * 0.3f) + (advantageFactor * 0.2f);
            return MathUtility.Clamp01(score);
        }

        public float CalculateDefenseDesirability(float healthPercent, float guardMeter, bool enemyAttacking)
        {
            if (!enemyAttacking) return 0.1f;
            float guardFactor = guardMeter / 100.0f;
            float survivalUrgency = 1.0f - healthPercent;

            float score = (guardFactor * 0.6f) + (survivalUrgency * 0.4f);
            return MathUtility.Clamp01(score);
        }

        public float CalculateAwakeningDesirability(float healthPercent, bool resonanceMaxed)
        {
            if (!resonanceMaxed) return 0.0f;
            // Higher urgency if health is low or for closing out matches
            return healthPercent < 0.40f ? 0.95f : 0.70f;
        }
    }
}
