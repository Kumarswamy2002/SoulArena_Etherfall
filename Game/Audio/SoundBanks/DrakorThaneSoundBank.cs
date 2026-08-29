using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Drakor Thane (Iron Colossus).
    /// </summary>
    public class DrakorThaneSoundBank
    {
        public string FighterId { get; } = "drakor_thane";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "drakor_thane_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "drakor_thane_hit_heavy" : "drakor_thane_hit_light";
        }
    }
}
