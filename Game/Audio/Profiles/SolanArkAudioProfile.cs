using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Solan Ark (Sunforged).
    /// </summary>
    public static class SolanArkAudioProfile
    {
        public static readonly string VoiceIntro = "solan_ark_voice_intro";
        public static readonly string VoiceVictory = "solan_ark_voice_victory";
        public static readonly string VoiceDefeat = "solan_ark_voice_defeat";
        public static readonly string VoiceAwakening = "solan_ark_voice_awakening";
        public static readonly string VoiceUltimate = "solan_ark_voice_ultimate";

        public static readonly string SfxLightAttack = "solan_ark_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "solan_ark_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "solan_ark_sfx_special1";
        public static readonly string SfxSpecial2 = "solan_ark_sfx_special2";
        public static readonly string SfxSpecial3 = "solan_ark_sfx_special3";
        public static readonly string SfxUltimateClimax = "solan_ark_sfx_ultimate_climax";

        public static readonly string ElementalHum = "solar_ambient_hum";

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
