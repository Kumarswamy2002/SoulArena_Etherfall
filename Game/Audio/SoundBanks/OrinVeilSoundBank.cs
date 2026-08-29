using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilSoundBank
    {
        public string FighterId { get; } = "orin_veil";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "orin_veil_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "orin_veil_hit_heavy" : "orin_veil_hit_light";
        }
    }
}
