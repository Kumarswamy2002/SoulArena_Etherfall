using System;

namespace SoulArena.Audio.SoundBanks
{
    /// <summary>
    /// Sound Cue Bank & Audio Asset Mapping for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenSoundBank
    {
        public string FighterId { get; } = "rokan_fen";
        public float PitchVariationRange { get; set; } = 0.05f;
        public float VolumeScale { get; set; } = 1.0f;

        public string GetSwingSound(int attackChainIndex)
        {
            return "rokan_fen_swing_" + attackChainIndex;
        }

        public string GetHitSound(bool isHeavy)
        {
            return isHeavy ? "rokan_fen_hit_heavy" : "rokan_fen_hit_light";
        }
    }
}
