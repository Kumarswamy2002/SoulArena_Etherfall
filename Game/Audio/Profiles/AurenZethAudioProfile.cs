using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Auren Zeth (First Soul).
    /// </summary>
    public static class AurenZethAudioProfile
    {
        public static readonly string VoiceIntro = "auren_zeth_voice_intro";
        public static readonly string VoiceVictory = "auren_zeth_voice_victory";
        public static readonly string VoiceDefeat = "auren_zeth_voice_defeat";
        public static readonly string VoiceAwakening = "auren_zeth_voice_awakening";
        public static readonly string VoiceUltimate = "auren_zeth_voice_ultimate";

        public static readonly string SfxLightAttack = "auren_zeth_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "auren_zeth_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "auren_zeth_sfx_special1";
        public static readonly string SfxSpecial2 = "auren_zeth_sfx_special2";
        public static readonly string SfxSpecial3 = "auren_zeth_sfx_special3";
        public static readonly string SfxUltimateClimax = "auren_zeth_sfx_ultimate_climax";

        public static readonly string ElementalHum = "primeether_ambient_hum";

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
