using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeCombatVoiceTriggers
    {
        public string FighterId { get; } = "seren_vale";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "seren_vale_light_grunt";
        public string GetHeavyAttackShout() => "seren_vale_heavy_shout";
        public string GetAwakeningChant() => "seren_vale_awakening_chant";
        public string GetKnockdownGroan() => "seren_vale_knockdown_groan";
    }
}
