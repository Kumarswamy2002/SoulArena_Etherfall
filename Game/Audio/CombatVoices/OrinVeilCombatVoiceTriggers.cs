using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilCombatVoiceTriggers
    {
        public string FighterId { get; } = "orin_veil";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "orin_veil_light_grunt";
        public string GetHeavyAttackShout() => "orin_veil_heavy_shout";
        public string GetAwakeningChant() => "orin_veil_awakening_chant";
        public string GetKnockdownGroan() => "orin_veil_knockdown_groan";
    }
}
