using System;

namespace SoulArena.Core
{
    /// <summary>
    /// Global constants defining simulation parameters, frame timings, and balance boundaries.
    /// </summary>
    public static class GameConstants
    {
        // Engine & Frame Timings
        public const int TARGET_FRAME_RATE = 60;
        public const float FIXED_DELTA_TIME = 1.0f / TARGET_FRAME_RATE;
        public const int INPUT_BUFFER_MAX_FRAMES = 12;
        public const int HITSTOP_DEFAULT_FRAMES = 4;
        public const int HITSTOP_HEAVY_FRAMES = 8;
        public const int HITSTOP_ULTIMATE_FRAMES = 24;

        // Resource Boundaries
        public const float DEFAULT_MAX_HEALTH = 1000.0f;
        public const float DEFAULT_MAX_ETHER = 100.0f;
        public const float DEFAULT_MAX_GUARD = 100.0f;
        public const float DEFAULT_MAX_RESONANCE = 100.0f;
        public const float DEFAULT_MAX_MOMENTUM = 100.0f;

        // Resource Regen & Decay Rates (per second)
        public const float ETHER_PASSIVE_REGEN = 3.5f;
        public const float ETHER_OFFENSIVE_GEN_MULTIPLIER = 0.15f;
        public const float GUARD_REGEN_DELAY = 1.5f; // Seconds after blocking before regen starts
        public const float GUARD_REGEN_RATE = 20.0f;
        public const float MOMENTUM_DECAY_RATE = 5.0f;

        // Defensive Timing Windows (in seconds / frames)
        public const float PERFECT_GUARD_WINDOW_SECONDS = 0.0667f; // ~4 frames at 60 FPS
        public const float PERFECT_DODGE_WINDOW_SECONDS = 0.0833f; // ~5 frames at 60 FPS
        public const float PARRY_ACTIVE_WINDOW_SECONDS = 0.1000f;  // ~6 frames
        public const float PARRY_RECOVERY_SECONDS = 0.35f;

        // Guard Break & Stagger
        public const float GUARD_BREAK_STUN_DURATION = 2.2f;
        public const float PARRY_STAGGER_DURATION = 1.6f;
        public const float COUNTER_DAMAGE_BONUS_MULTIPLIER = 1.25f;

        // Combo & Juggle Constants
        public const int MAX_JUGGLE_HITS = 8;
        public const float MIN_DAMAGE_SCALING = 0.15f; // Minimum 15% damage at high combos
        public const float DAMAGE_SCALING_PER_HIT = 0.08f; // Drops 8% per hit in combo
        public const float COMBO_BREAKER_ETHER_COST = 50.0f;
        public const float COMBO_BREAKER_RESONANCE_COST = 25.0f;

        // Awakening Mechanics
        public const float AWAKENING_THRESHOLD = 100.0f;
        public const float AWAKENING_DURATION = 20.0f; // 20 seconds base duration
        public const float AWAKENING_DAMAGE_MODIFIER = 1.15f;
        public const float AWAKENING_DEFENSE_MODIFIER = 0.85f;
        public const float AWAKENING_SPEED_MODIFIER = 1.20f;
        public const float AWAKENING_COOLDOWN_REDUCTION = 0.30f;

        // Arena & Boundary Physics
        public const float RING_OUT_DAMAGE_PERCENT = 0.35f;
        public const float WALL_SPLAT_THRESHOLD_VELOCITY = 12.0f;
        public const float WALL_SPLAT_STUN_DURATION = 1.2f;
        public const float GROUND_BOUNCE_MIN_VELOCITY = 8.0f;

        // Networking & Sync
        public const int NETWORK_TICK_RATE = 60;
        public const int MAX_ROLLBACK_FRAMES = 8;
        public const float SNAPSHOT_INTERPOLATION_OFFSET = 0.033f;
    }
}
