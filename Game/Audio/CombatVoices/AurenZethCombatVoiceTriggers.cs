using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethCombatVoiceTriggers
    {
        public string FighterId { get; } = "auren_zeth";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "auren_zeth_light_grunt";
        public string GetHeavyAttackShout() => "auren_zeth_heavy_shout";
        public string GetAwakeningChant() => "auren_zeth_awakening_chant";
        public string GetKnockdownGroan() => "auren_zeth_knockdown_groan";
    }
}
