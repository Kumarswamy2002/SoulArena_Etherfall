using System;
using SoulArena.Core;

namespace SoulArena.AI
{
    public class AIPersonalityProfile
    {
        public AIPersonality Personality;
        public float AggressivenessWeight = 0.5f;   // Preference for advancing and attacking
        public float DefensiveGuardWeight = 0.5f;   // Frequency of blocking vs dodging
        public float ParryAttemptWeight = 0.2f;     // Risk appetite for high-reward parries
        public float AbilityUsageWeight = 0.6f;     // Eagerness to spend Ether on specials
        public float AwakeningUrgencyWeight = 0.8f; // Triggers Awakening as soon as ready
        public float SpacingPreferredDistance = 3.0f; // Neutral spacing distance in meters
        public float ComboBreakerReadiness = 0.7f;  // Tendency to burst escape out of long combos
    }

    public class AIDifficultyProfile
    {
        public AIDifficulty Difficulty;
        public int ReactionLatencyFrames = 12; // 12 frames (~200ms) for beginner, 1 frame for Grandmaster
        public float ComboExecutionAccuracy = 0.70f;
        public float DefenseSuccessRate = 0.60f;
        public float CounterHitAnticipation = 0.40f;
        public bool CanExecuteOptimalCancels = false;
        public bool CanPerformPerfectParries = false;
    }

    public static class AIProfileDatabase
    {
        public static AIPersonalityProfile GetPersonality(AIPersonality personality)
        {
            switch (personality)
            {
                case AIPersonality.Aggressive:
                    return new AIPersonalityProfile
                    {
                        Personality = personality,
                        AggressivenessWeight = 0.90f,
                        DefensiveGuardWeight = 0.25f,
                        ParryAttemptWeight = 0.15f,
                        AbilityUsageWeight = 0.85f,
                        SpacingPreferredDistance = 1.2f,
                        ComboBreakerReadiness = 0.50f
                    };

                case AIPersonality.Defensive:
                    return new AIPersonalityProfile
                    {
                        Personality = personality,
                        AggressivenessWeight = 0.20f,
                        DefensiveGuardWeight = 0.90f,
                        ParryAttemptWeight = 0.45f,
                        AbilityUsageWeight = 0.40f,
                        SpacingPreferredDistance = 5.5f,
                        ComboBreakerReadiness = 0.90f
                    };

                case AIPersonality.CounterFighter:
                    return new AIPersonalityProfile
                    {
                        Personality = personality,
                        AggressivenessWeight = 0.40f,
                        DefensiveGuardWeight = 0.70f,
                        ParryAttemptWeight = 0.80f,
                        AbilityUsageWeight = 0.65f,
                        SpacingPreferredDistance = 3.2f,
                        ComboBreakerReadiness = 0.80f
                    };

                case AIPersonality.ComboFighter:
                    return new AIPersonalityProfile
                    {
                        Personality = personality,
                        AggressivenessWeight = 0.80f,
                        DefensiveGuardWeight = 0.40f,
                        ParryAttemptWeight = 0.30f,
                        AbilityUsageWeight = 0.90f,
                        SpacingPreferredDistance = 1.8f,
                        ComboBreakerReadiness = 0.85f
                    };

                case AIPersonality.Evasive:
                    return new AIPersonalityProfile
                    {
                        Personality = personality,
                        AggressivenessWeight = 0.30f,
                        DefensiveGuardWeight = 0.35f,
                        ParryAttemptWeight = 0.20f,
                        AbilityUsageWeight = 0.50f,
                        SpacingPreferredDistance = 6.5f,
                        ComboBreakerReadiness = 0.95f
                    };

                case AIPersonality.Tactical:
                default:
                    return new AIPersonalityProfile
                    {
                        Personality = AIPersonality.Tactical,
                        AggressivenessWeight = 0.55f,
                        DefensiveGuardWeight = 0.60f,
                        ParryAttemptWeight = 0.50f,
                        AbilityUsageWeight = 0.70f,
                        SpacingPreferredDistance = 3.5f,
                        ComboBreakerReadiness = 0.75f
                    };
            }
        }

        public static AIDifficultyProfile GetDifficulty(AIDifficulty difficulty)
        {
            switch (difficulty)
            {
                case AIDifficulty.Beginner:
                    return new AIDifficultyProfile
                    {
                        Difficulty = difficulty,
                        ReactionLatencyFrames = 18,
                        ComboExecutionAccuracy = 0.45f,
                        DefenseSuccessRate = 0.35f,
                        CounterHitAnticipation = 0.10f,
                        CanExecuteOptimalCancels = false,
                        CanPerformPerfectParries = false
                    };

                case AIDifficulty.Normal:
                    return new AIDifficultyProfile
                    {
                        Difficulty = difficulty,
                        ReactionLatencyFrames = 12,
                        ComboExecutionAccuracy = 0.65f,
                        DefenseSuccessRate = 0.55f,
                        CounterHitAnticipation = 0.30f,
                        CanExecuteOptimalCancels = false,
                        CanPerformPerfectParries = false
                    };

                case AIDifficulty.Advanced:
                    return new AIDifficultyProfile
                    {
                        Difficulty = difficulty,
                        ReactionLatencyFrames = 8,
                        ComboExecutionAccuracy = 0.80f,
                        DefenseSuccessRate = 0.70f,
                        CounterHitAnticipation = 0.55f,
                        CanExecuteOptimalCancels = true,
                        CanPerformPerfectParries = false
                    };

                case AIDifficulty.Expert:
                    return new AIDifficultyProfile
                    {
                        Difficulty = difficulty,
                        ReactionLatencyFrames = 5,
                        ComboExecutionAccuracy = 0.90f,
                        DefenseSuccessRate = 0.82f,
                        CounterHitAnticipation = 0.75f,
                        CanExecuteOptimalCancels = true,
                        CanPerformPerfectParries = true
                    };

                case AIDifficulty.Master:
                    return new AIDifficultyProfile
                    {
                        Difficulty = difficulty,
                        ReactionLatencyFrames = 3,
                        ComboExecutionAccuracy = 0.96f,
                        DefenseSuccessRate = 0.90f,
                        CounterHitAnticipation = 0.88f,
                        CanExecuteOptimalCancels = true,
                        CanPerformPerfectParries = true
                    };

                case AIDifficulty.Grandmaster:
                default:
                    return new AIDifficultyProfile
                    {
                        Difficulty = AIDifficulty.Grandmaster,
                        ReactionLatencyFrames = 1,
                        ComboExecutionAccuracy = 0.99f,
                        DefenseSuccessRate = 0.96f,
                        CounterHitAnticipation = 0.95f,
                        CanExecuteOptimalCancels = true,
                        CanPerformPerfectParries = true
                    };
            }
        }
    }
}
