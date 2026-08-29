using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Kael Varyn (Stormbound).
    /// </summary>
    public class KaelVarynCombatVoiceTriggers
    {
        public string FighterId { get; } = "kael_varyn";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "kael_varyn_light_grunt";
        public string GetHeavyAttackShout() => "kael_varyn_heavy_shout";
        public string GetAwakeningChant() => "kael_varyn_awakening_chant";
        public string GetKnockdownGroan() => "kael_varyn_knockdown_groan";
    }
}
