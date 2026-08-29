using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeSoundBank
    {
        public string FighterId { get; } = "raven_drake";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "raven_drake_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "raven_drake_hit_heavy" : "raven_drake_hit_light";
        }
    }
}
