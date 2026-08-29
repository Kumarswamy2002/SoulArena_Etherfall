using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossSoundBank
    {
        public string FighterId { get; } = "ryka_voss";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "ryka_voss_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "ryka_voss_hit_heavy" : "ryka_voss_hit_light";
        }
    }
}
