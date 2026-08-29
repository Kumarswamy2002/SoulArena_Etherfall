using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Vexa Noir (Void Walker).
    /// </summary>
    public class VexaNoirCombatVoiceTriggers
    {
        public string FighterId { get; } = "vexa_noir";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "vexa_noir_light_grunt";
        public string GetHeavyAttackShout() => "vexa_noir_heavy_shout";
        public string GetAwakeningChant() => "vexa_noir_awakening_chant";
        public string GetKnockdownGroan() => "vexa_noir_knockdown_groan";
    }
}
