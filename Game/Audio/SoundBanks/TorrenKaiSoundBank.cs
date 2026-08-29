using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiSoundBank
    {
        public string FighterId { get; } = "torren_kai";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "torren_kai_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "torren_kai_hit_heavy" : "torren_kai_hit_light";
        }
    }
}
