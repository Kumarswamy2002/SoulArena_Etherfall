using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Kael Varyn (Stormbound).
    /// </summary>
    public class KaelVarynSoundBank
    {
        public string FighterId { get; } = "kael_varyn";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "kael_varyn_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "kael_varyn_hit_heavy" : "kael_varyn_hit_light";
        }
    }
}
