using System;
using SoulArena.Core;

namespace SoulArena.AI.Difficulties
{
    /// <summary>
    /// Granular Reaction Latency & Whiff Punish Scaling for Seren Vale (Frozen Blade).
    /// </summary>
    public static class SerenValeDifficultyProfile
    {
        public static float GetWhiffPunishRate(AIDifficulty difficulty)
        {
            switch (difficulty)
            {
                case AIDifficulty.Beginner: return 0.15f;
                case AIDifficulty.Normal: return 0.40f;
                case AIDifficulty.Advanced: return 0.65f;
                case AIDifficulty.Expert: return 0.85f;
                case AIDifficulty.Master: return 0.95f;
                case AIDifficulty.Grandmaster: return 0.99f;
                default: return 0.50f;
            }
        }
    }
}
