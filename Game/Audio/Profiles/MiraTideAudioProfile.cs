using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Mira Tide (Tideblade).
    /// </summary>
    public static class MiraTideAudioProfile
    {
        public static readonly string VoiceIntro = "mira_tide_voice_intro";
        public static readonly string VoiceVictory = "mira_tide_voice_victory";
        public static readonly string VoiceDefeat = "mira_tide_voice_defeat";
        public static readonly string VoiceAwakening = "mira_tide_voice_awakening";
        public static readonly string VoiceUltimate = "mira_tide_voice_ultimate";

        public static readonly string SfxLightAttack = "mira_tide_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "mira_tide_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "mira_tide_sfx_special1";
        public static readonly string SfxSpecial2 = "mira_tide_sfx_special2";
        public static readonly string SfxSpecial3 = "mira_tide_sfx_special3";
        public static readonly string SfxUltimateClimax = "mira_tide_sfx_ultimate_climax";

        public static readonly string ElementalHum = "tidal_ambient_hum";

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
