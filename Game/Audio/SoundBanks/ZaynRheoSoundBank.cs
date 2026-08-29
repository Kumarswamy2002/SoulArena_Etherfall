using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoSoundBank
    {
        public string FighterId { get; } = "zayn_rheo";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "zayn_rheo_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "zayn_rheo_hit_heavy" : "zayn_rheo_hit_light";
        }
    }
}
