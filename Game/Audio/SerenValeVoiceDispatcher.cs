using System;

namespace SoulArena.Audio
{
    /// <summary>
    /// Voice Line Timing & Frequency Dispatcher for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeVoiceDispatcher
    {
        public string FighterId { get; } = "seren_vale";
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
