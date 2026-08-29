using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideSoundBank
    {
        public string FighterId { get; } = "mira_tide";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "mira_tide_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "mira_tide_hit_heavy" : "mira_tide_hit_light";
        }
    }
}
