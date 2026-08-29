using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossCombatVoiceTriggers
    {
        public string FighterId { get; } = "ryka_voss";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "ryka_voss_light_grunt";
        public string GetHeavyAttackShout() => "ryka_voss_heavy_shout";
        public string GetAwakeningChant() => "ryka_voss_awakening_chant";
        public string GetKnockdownGroan() => "ryka_voss_knockdown_groan";
    }
}
