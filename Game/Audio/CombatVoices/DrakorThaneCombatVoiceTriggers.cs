using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Drakor Thane (Iron Colossus).
    /// </summary>
    public class DrakorThaneCombatVoiceTriggers
    {
        public string FighterId { get; } = "drakor_thane";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "drakor_thane_light_grunt";
        public string GetHeavyAttackShout() => "drakor_thane_heavy_shout";
        public string GetAwakeningChant() => "drakor_thane_awakening_chant";
        public string GetKnockdownGroan() => "drakor_thane_knockdown_groan";
    }
}
