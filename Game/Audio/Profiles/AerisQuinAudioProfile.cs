using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Aeris Quin (Star Weaver).
    /// </summary>
    public static class AerisQuinAudioProfile
    {
        public static readonly string VoiceIntro = "aeris_quin_voice_intro";
        public static readonly string VoiceVictory = "aeris_quin_voice_victory";
        public static readonly string VoiceDefeat = "aeris_quin_voice_defeat";
        public static readonly string VoiceAwakening = "aeris_quin_voice_awakening";
        public static readonly string VoiceUltimate = "aeris_quin_voice_ultimate";

        public static readonly string SfxLightAttack = "aeris_quin_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "aeris_quin_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "aeris_quin_sfx_special1";
        public static readonly string SfxSpecial2 = "aeris_quin_sfx_special2";
        public static readonly string SfxSpecial3 = "aeris_quin_sfx_special3";
        public static readonly string SfxUltimateClimax = "aeris_quin_sfx_ultimate_climax";

        public static readonly string ElementalHum = "astral_ambient_hum";

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
