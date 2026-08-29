using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenCombatVoiceTriggers
    {
        public string FighterId { get; } = "nox_arden";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "nox_arden_light_grunt";
        public string GetHeavyAttackShout() => "nox_arden_heavy_shout";
        public string GetAwakeningChant() => "nox_arden_awakening_chant";
        public string GetKnockdownGroan() => "nox_arden_knockdown_groan";
    }
}
