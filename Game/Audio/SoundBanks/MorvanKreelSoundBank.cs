using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelSoundBank
    {
        public string FighterId { get; } = "morvan_kreel";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "morvan_kreel_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "morvan_kreel_hit_heavy" : "morvan_kreel_hit_light";
        }
    }
}
