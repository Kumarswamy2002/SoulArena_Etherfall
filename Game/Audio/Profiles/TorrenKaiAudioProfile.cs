using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Torren Kai (Wind Dancer).
    /// </summary>
    public static class TorrenKaiAudioProfile
    {
        public static readonly string VoiceIntro = "torren_kai_voice_intro";
        public static readonly string VoiceVictory = "torren_kai_voice_victory";
        public static readonly string VoiceDefeat = "torren_kai_voice_defeat";
        public static readonly string VoiceAwakening = "torren_kai_voice_awakening";
        public static readonly string VoiceUltimate = "torren_kai_voice_ultimate";

        public static readonly string SfxLightAttack = "torren_kai_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "torren_kai_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "torren_kai_sfx_special1";
        public static readonly string SfxSpecial2 = "torren_kai_sfx_special2";
        public static readonly string SfxSpecial3 = "torren_kai_sfx_special3";
        public static readonly string SfxUltimateClimax = "torren_kai_sfx_ultimate_climax";

        public static readonly string ElementalHum = "gale_ambient_hum";

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
