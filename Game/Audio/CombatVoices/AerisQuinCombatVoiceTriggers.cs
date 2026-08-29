using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Aeris Quin (Star Weaver).
    /// </summary>
    public class AerisQuinCombatVoiceTriggers
    {
        public string FighterId { get; } = "aeris_quin";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "aeris_quin_light_grunt";
        public string GetHeavyAttackShout() => "aeris_quin_heavy_shout";
        public string GetAwakeningChant() => "aeris_quin_awakening_chant";
        public string GetKnockdownGroan() => "aeris_quin_knockdown_groan";
    }
}
