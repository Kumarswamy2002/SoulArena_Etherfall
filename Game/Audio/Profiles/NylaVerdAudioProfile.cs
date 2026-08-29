using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Nyla Verd (Wild Caller).
    /// </summary>
    public static class NylaVerdAudioProfile
    {
        public static readonly string VoiceIntro = "nyla_verd_voice_intro";
        public static readonly string VoiceVictory = "nyla_verd_voice_victory";
        public static readonly string VoiceDefeat = "nyla_verd_voice_defeat";
        public static readonly string VoiceAwakening = "nyla_verd_voice_awakening";
        public static readonly string VoiceUltimate = "nyla_verd_voice_ultimate";

        public static readonly string SfxLightAttack = "nyla_verd_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "nyla_verd_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "nyla_verd_sfx_special1";
        public static readonly string SfxSpecial2 = "nyla_verd_sfx_special2";
        public static readonly string SfxSpecial3 = "nyla_verd_sfx_special3";
        public static readonly string SfxUltimateClimax = "nyla_verd_sfx_ultimate_climax";

        public static readonly string ElementalHum = "nature_ambient_hum";

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
