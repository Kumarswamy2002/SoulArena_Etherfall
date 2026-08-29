using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Morvan Kreel (Grave King).
    /// </summary>
    public static class MorvanKreelAudioProfile
    {
        public static readonly string VoiceIntro = "morvan_kreel_voice_intro";
        public static readonly string VoiceVictory = "morvan_kreel_voice_victory";
        public static readonly string VoiceDefeat = "morvan_kreel_voice_defeat";
        public static readonly string VoiceAwakening = "morvan_kreel_voice_awakening";
        public static readonly string VoiceUltimate = "morvan_kreel_voice_ultimate";

        public static readonly string SfxLightAttack = "morvan_kreel_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "morvan_kreel_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "morvan_kreel_sfx_special1";
        public static readonly string SfxSpecial2 = "morvan_kreel_sfx_special2";
        public static readonly string SfxSpecial3 = "morvan_kreel_sfx_special3";
        public static readonly string SfxUltimateClimax = "morvan_kreel_sfx_ultimate_climax";

        public static readonly string ElementalHum = "death_ambient_hum";

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
