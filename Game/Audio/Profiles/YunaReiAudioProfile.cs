using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Yuna Rei (Spirit Dancer).
    /// </summary>
    public static class YunaReiAudioProfile
    {
        public static readonly string VoiceIntro = "yuna_rei_voice_intro";
        public static readonly string VoiceVictory = "yuna_rei_voice_victory";
        public static readonly string VoiceDefeat = "yuna_rei_voice_defeat";
        public static readonly string VoiceAwakening = "yuna_rei_voice_awakening";
        public static readonly string VoiceUltimate = "yuna_rei_voice_ultimate";

        public static readonly string SfxLightAttack = "yuna_rei_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "yuna_rei_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "yuna_rei_sfx_special1";
        public static readonly string SfxSpecial2 = "yuna_rei_sfx_special2";
        public static readonly string SfxSpecial3 = "yuna_rei_sfx_special3";
        public static readonly string SfxUltimateClimax = "yuna_rei_sfx_ultimate_climax";

        public static readonly string ElementalHum = "spirit_ambient_hum";

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
