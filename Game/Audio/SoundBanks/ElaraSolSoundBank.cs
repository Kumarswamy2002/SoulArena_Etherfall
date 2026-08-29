using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolSoundBank
    {
        public string FighterId { get; } = "elara_sol";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "elara_sol_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "elara_sol_hit_heavy" : "elara_sol_hit_light";
        }
    }
}
