using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Nyla Verd (Wild Caller).
    /// </summary>
    public class NylaVerdCombatVoiceTriggers
    {
        public string FighterId { get; } = "nyla_verd";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "nyla_verd_light_grunt";
        public string GetHeavyAttackShout() => "nyla_verd_heavy_shout";
        public string GetAwakeningChant() => "nyla_verd_awakening_chant";
        public string GetKnockdownGroan() => "nyla_verd_knockdown_groan";
    }
}
