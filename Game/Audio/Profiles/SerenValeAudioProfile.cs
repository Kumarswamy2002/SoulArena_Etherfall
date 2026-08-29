using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Seren Vale (Frozen Blade).
    /// </summary>
    public static class SerenValeAudioProfile
    {
        public static readonly string VoiceIntro = "seren_vale_voice_intro";
        public static readonly string VoiceVictory = "seren_vale_voice_victory";
        public static readonly string VoiceDefeat = "seren_vale_voice_defeat";
        public static readonly string VoiceAwakening = "seren_vale_voice_awakening";
        public static readonly string VoiceUltimate = "seren_vale_voice_ultimate";

        public static readonly string SfxLightAttack = "seren_vale_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "seren_vale_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "seren_vale_sfx_special1";
        public static readonly string SfxSpecial2 = "seren_vale_sfx_special2";
        public static readonly string SfxSpecial3 = "seren_vale_sfx_special3";
        public static readonly string SfxUltimateClimax = "seren_vale_sfx_ultimate_climax";

        public static readonly string ElementalHum = "frost_ambient_hum";

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
