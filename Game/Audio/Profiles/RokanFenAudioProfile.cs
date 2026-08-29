using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Rokan Fen (Beast Soul).
    /// </summary>
    public static class RokanFenAudioProfile
    {
        public static readonly string VoiceIntro = "rokan_fen_voice_intro";
        public static readonly string VoiceVictory = "rokan_fen_voice_victory";
        public static readonly string VoiceDefeat = "rokan_fen_voice_defeat";
        public static readonly string VoiceAwakening = "rokan_fen_voice_awakening";
        public static readonly string VoiceUltimate = "rokan_fen_voice_ultimate";

        public static readonly string SfxLightAttack = "rokan_fen_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "rokan_fen_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "rokan_fen_sfx_special1";
        public static readonly string SfxSpecial2 = "rokan_fen_sfx_special2";
        public static readonly string SfxSpecial3 = "rokan_fen_sfx_special3";
        public static readonly string SfxUltimateClimax = "rokan_fen_sfx_ultimate_climax";

        public static readonly string ElementalHum = "beast_ambient_hum";

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
