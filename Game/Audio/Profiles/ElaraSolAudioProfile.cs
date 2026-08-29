using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Elara Sol (Dawn Saint).
    /// </summary>
    public static class ElaraSolAudioProfile
    {
        public static readonly string VoiceIntro = "elara_sol_voice_intro";
        public static readonly string VoiceVictory = "elara_sol_voice_victory";
        public static readonly string VoiceDefeat = "elara_sol_voice_defeat";
        public static readonly string VoiceAwakening = "elara_sol_voice_awakening";
        public static readonly string VoiceUltimate = "elara_sol_voice_ultimate";

        public static readonly string SfxLightAttack = "elara_sol_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "elara_sol_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "elara_sol_sfx_special1";
        public static readonly string SfxSpecial2 = "elara_sol_sfx_special2";
        public static readonly string SfxSpecial3 = "elara_sol_sfx_special3";
        public static readonly string SfxUltimateClimax = "elara_sol_sfx_ultimate_climax";

        public static readonly string ElementalHum = "radiance_ambient_hum";

        public static List<string> GetAllAudioClips()
        {
            return new List<string>
            {
                VoiceIntro, VoiceVictory, VoiceDefeat, VoiceAwakening, VoiceUltimate,
                SfxLightAttack, SfxHeavyAttack, SfxSpecial1, SfxSpecial2, SfxSpecial3, SfxUltimateClimax,
                ElementalHum
            };
        }
    }
}
