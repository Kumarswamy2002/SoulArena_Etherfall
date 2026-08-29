using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideCombatVoiceTriggers
    {
        public string FighterId { get; } = "mira_tide";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "mira_tide_light_grunt";
        public string GetHeavyAttackShout() => "mira_tide_heavy_shout";
        public string GetAwakeningChant() => "mira_tide_awakening_chant";
        public string GetKnockdownGroan() => "mira_tide_knockdown_groan";
    }
}
