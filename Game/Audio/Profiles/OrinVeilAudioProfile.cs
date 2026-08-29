using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Orin Veil (Mind Weaver).
    /// </summary>
    public static class OrinVeilAudioProfile
    {
        public static readonly string VoiceIntro = "orin_veil_voice_intro";
        public static readonly string VoiceVictory = "orin_veil_voice_victory";
        public static readonly string VoiceDefeat = "orin_veil_voice_defeat";
        public static readonly string VoiceAwakening = "orin_veil_voice_awakening";
        public static readonly string VoiceUltimate = "orin_veil_voice_ultimate";

        public static readonly string SfxLightAttack = "orin_veil_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "orin_veil_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "orin_veil_sfx_special1";
        public static readonly string SfxSpecial2 = "orin_veil_sfx_special2";
        public static readonly string SfxSpecial3 = "orin_veil_sfx_special3";
        public static readonly string SfxUltimateClimax = "orin_veil_sfx_ultimate_climax";

        public static readonly string ElementalHum = "psionic_ambient_hum";

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
