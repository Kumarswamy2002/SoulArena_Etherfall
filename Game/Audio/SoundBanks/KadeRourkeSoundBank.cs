using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeSoundBank
    {
        public string FighterId { get; } = "kade_rourke";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "kade_rourke_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "kade_rourke_hit_heavy" : "kade_rourke_hit_light";
        }
    }
}
