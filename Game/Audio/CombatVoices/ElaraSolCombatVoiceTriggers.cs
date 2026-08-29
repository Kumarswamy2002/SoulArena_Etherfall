using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolCombatVoiceTriggers
    {
        public string FighterId { get; } = "elara_sol";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "elara_sol_light_grunt";
        public string GetHeavyAttackShout() => "elara_sol_heavy_shout";
        public string GetAwakeningChant() => "elara_sol_awakening_chant";
        public string GetKnockdownGroan() => "elara_sol_knockdown_groan";
    }
}
