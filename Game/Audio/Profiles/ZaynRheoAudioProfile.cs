using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public static class ZaynRheoAudioProfile
    {
        public static readonly string VoiceIntro = "zayn_rheo_voice_intro";
        public static readonly string VoiceVictory = "zayn_rheo_voice_victory";
        public static readonly string VoiceDefeat = "zayn_rheo_voice_defeat";
        public static readonly string VoiceAwakening = "zayn_rheo_voice_awakening";
        public static readonly string VoiceUltimate = "zayn_rheo_voice_ultimate";

        public static readonly string SfxLightAttack = "zayn_rheo_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "zayn_rheo_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "zayn_rheo_sfx_special1";
        public static readonly string SfxSpecial2 = "zayn_rheo_sfx_special2";
        public static readonly string SfxSpecial3 = "zayn_rheo_sfx_special3";
        public static readonly string SfxUltimateClimax = "zayn_rheo_sfx_ultimate_climax";

        public static readonly string ElementalHum = "volt_ambient_hum";

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
