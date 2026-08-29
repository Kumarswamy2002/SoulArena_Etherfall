using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiSoundBank
    {
        public string FighterId { get; } = "yuna_rei";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "yuna_rei_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "yuna_rei_hit_heavy" : "yuna_rei_hit_light";
        }
    }
}
