using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenSoundBank
    {
        public string FighterId { get; } = "nox_arden";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "nox_arden_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "nox_arden_hit_heavy" : "nox_arden_hit_light";
        }
    }
}
