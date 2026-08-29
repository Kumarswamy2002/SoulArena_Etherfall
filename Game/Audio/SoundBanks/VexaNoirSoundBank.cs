using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Vexa Noir (Void Walker).
    /// </summary>
    public class VexaNoirSoundBank
    {
        public string FighterId { get; } = "vexa_noir";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "vexa_noir_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "vexa_noir_hit_heavy" : "vexa_noir_hit_light";
        }
    }
}
