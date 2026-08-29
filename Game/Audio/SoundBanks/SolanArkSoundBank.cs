using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkSoundBank
    {
        public string FighterId { get; } = "solan_ark";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "solan_ark_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "solan_ark_hit_heavy" : "solan_ark_hit_light";
        }
    }
}
