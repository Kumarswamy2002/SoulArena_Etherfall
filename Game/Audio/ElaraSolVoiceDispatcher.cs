using System;

namespace SoulArena.Audio
{
    /// <summary>
    /// Voice Line Timing & Frequency Dispatcher for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolVoiceDispatcher
    {
        public string FighterId { get; } = "elara_sol";
        public float VoiceCooldown { get; private set; } = 0.0f;

        public void PlayHitGrunt()
        {
            if (VoiceCooldown <= 0.0f)
            {
                VoiceCooldown = 1.2f;
            }
        }

        public void Update(float deltaTime)
        {
            if (VoiceCooldown > 0.0f)
            {
                VoiceCooldown -= deltaTime;
            }
        }
    }
}
