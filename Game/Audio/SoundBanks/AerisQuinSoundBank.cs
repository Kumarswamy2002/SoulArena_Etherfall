using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Aeris Quin (Star Weaver).
    /// </summary>
    public class AerisQuinSoundBank
    {
        public string FighterId { get; } = "aeris_quin";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "aeris_quin_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "aeris_quin_hit_heavy" : "aeris_quin_hit_light";
        }
    }
}
