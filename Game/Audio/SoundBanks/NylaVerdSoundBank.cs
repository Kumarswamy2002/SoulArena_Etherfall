using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Nyla Verd (Wild Caller).
    /// </summary>
    public class NylaVerdSoundBank
    {
        public string FighterId { get; } = "nyla_verd";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "nyla_verd_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "nyla_verd_hit_heavy" : "nyla_verd_hit_light";
        }
    }
}
