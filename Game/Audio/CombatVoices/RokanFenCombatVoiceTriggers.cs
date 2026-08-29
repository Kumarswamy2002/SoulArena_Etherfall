using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenCombatVoiceTriggers
    {
        public string FighterId { get; } = "rokan_fen";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "rokan_fen_light_grunt";
        public string GetHeavyAttackShout() => "rokan_fen_heavy_shout";
        public string GetAwakeningChant() => "rokan_fen_awakening_chant";
        public string GetKnockdownGroan() => "rokan_fen_knockdown_groan";
    }
}
