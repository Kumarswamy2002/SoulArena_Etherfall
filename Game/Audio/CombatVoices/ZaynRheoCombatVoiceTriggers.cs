using System;
using SoulArena.Core;

namespace SoulArena.Audio.CombatVoices
{
    /// <summary>
    /// Frame-accurate Combat Audio Voice Cue Triggers for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoCombatVoiceTriggers
    {
        public string FighterId { get; } = "zayn_rheo";
        public float GruntVolume { get; set; } = 0.90f;
        public float ShoutVolume { get; set; } = 1.0f;

        public string GetLightAttackGrunt() => "zayn_rheo_light_grunt";
        public string GetHeavyAttackShout() => "zayn_rheo_heavy_shout";
        public string GetAwakeningChant() => "zayn_rheo_awakening_chant";
        public string GetKnockdownGroan() => "zayn_rheo_knockdown_groan";
    }
}
