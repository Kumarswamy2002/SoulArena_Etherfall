using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiCombatVoiceTriggers
    {
        public string FighterId { get; } = "yuna_rei";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "yuna_rei_light_grunt";
        public string GetHeavyAttackShout() => "yuna_rei_heavy_shout";
        public string GetAwakeningChant() => "yuna_rei_awakening_chant";
        public string GetKnockdownGroan() => "yuna_rei_knockdown_groan";
    }
}
