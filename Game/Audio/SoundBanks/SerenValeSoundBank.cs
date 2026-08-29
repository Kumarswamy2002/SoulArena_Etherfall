using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeSoundBank
    {
        public string FighterId { get; } = "seren_vale";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "seren_vale_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "seren_vale_hit_heavy" : "seren_vale_hit_light";
        }
    }
}
