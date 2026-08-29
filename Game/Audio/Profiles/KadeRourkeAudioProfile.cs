using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Kade Rourke (Iron Marauder).
    /// </summary>
    public static class KadeRourkeAudioProfile
    {
        public static readonly string VoiceIntro = "kade_rourke_voice_intro";
        public static readonly string VoiceVictory = "kade_rourke_voice_victory";
        public static readonly string VoiceDefeat = "kade_rourke_voice_defeat";
        public static readonly string VoiceAwakening = "kade_rourke_voice_awakening";
        public static readonly string VoiceUltimate = "kade_rourke_voice_ultimate";

        public static readonly string SfxLightAttack = "kade_rourke_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "kade_rourke_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "kade_rourke_sfx_special1";
        public static readonly string SfxSpecial2 = "kade_rourke_sfx_special2";
        public static readonly string SfxSpecial3 = "kade_rourke_sfx_special3";
        public static readonly string SfxUltimateClimax = "kade_rourke_sfx_ultimate_climax";

        public static readonly string ElementalHum = "metal_ambient_hum";

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
