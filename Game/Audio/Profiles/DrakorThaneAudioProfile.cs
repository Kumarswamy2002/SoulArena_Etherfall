using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Drakor Thane (Iron Colossus).
    /// </summary>
    public static class DrakorThaneAudioProfile
    {
        public static readonly string VoiceIntro = "drakor_thane_voice_intro";
        public static readonly string VoiceVictory = "drakor_thane_voice_victory";
        public static readonly string VoiceDefeat = "drakor_thane_voice_defeat";
        public static readonly string VoiceAwakening = "drakor_thane_voice_awakening";
        public static readonly string VoiceUltimate = "drakor_thane_voice_ultimate";

        public static readonly string SfxLightAttack = "drakor_thane_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "drakor_thane_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "drakor_thane_sfx_special1";
        public static readonly string SfxSpecial2 = "drakor_thane_sfx_special2";
        public static readonly string SfxSpecial3 = "drakor_thane_sfx_special3";
        public static readonly string SfxUltimateClimax = "drakor_thane_sfx_ultimate_climax";

        public static readonly string ElementalHum = "stone_ambient_hum";

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
