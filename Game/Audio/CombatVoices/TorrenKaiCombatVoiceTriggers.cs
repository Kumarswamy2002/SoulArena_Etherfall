using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiCombatVoiceTriggers
    {
        public string FighterId { get; } = "torren_kai";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "torren_kai_light_grunt";
        public string GetHeavyAttackShout() => "torren_kai_heavy_shout";
        public string GetAwakeningChant() => "torren_kai_awakening_chant";
        public string GetKnockdownGroan() => "torren_kai_knockdown_groan";
    }
}
