using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelCombatVoiceTriggers
    {
        public string FighterId { get; } = "morvan_kreel";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "morvan_kreel_light_grunt";
        public string GetHeavyAttackShout() => "morvan_kreel_heavy_shout";
        public string GetAwakeningChant() => "morvan_kreel_awakening_chant";
        public string GetKnockdownGroan() => "morvan_kreel_knockdown_groan";
    }
}
