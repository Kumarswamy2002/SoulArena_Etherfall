using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethSoundBank
    {
        public string FighterId { get; } = "auren_zeth";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "auren_zeth_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "auren_zeth_hit_heavy" : "auren_zeth_hit_light";
        }
    }
}
