using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeCombatVoiceTriggers
    {
        public string FighterId { get; } = "raven_drake";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "raven_drake_light_grunt";
        public string GetHeavyAttackShout() => "raven_drake_heavy_shout";
        public string GetAwakeningChant() => "raven_drake_awakening_chant";
        public string GetKnockdownGroan() => "raven_drake_knockdown_groan";
    }
}
