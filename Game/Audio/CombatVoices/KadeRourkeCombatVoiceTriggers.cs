using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeCombatVoiceTriggers
    {
        public string FighterId { get; } = "kade_rourke";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "kade_rourke_light_grunt";
        public string GetHeavyAttackShout() => "kade_rourke_heavy_shout";
        public string GetAwakeningChant() => "kade_rourke_awakening_chant";
        public string GetKnockdownGroan() => "kade_rourke_knockdown_groan";
    }
}
