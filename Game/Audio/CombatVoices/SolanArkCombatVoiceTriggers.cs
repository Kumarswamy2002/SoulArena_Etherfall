using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkCombatVoiceTriggers
    {
        public string FighterId { get; } = "solan_ark";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "solan_ark_light_grunt";
        public string GetHeavyAttackShout() => "solan_ark_heavy_shout";
        public string GetAwakeningChant() => "solan_ark_awakening_chant";
        public string GetKnockdownGroan() => "solan_ark_knockdown_groan";
    }
}
