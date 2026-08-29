using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Ryka Voss (Ember Wolf).
    /// </summary>
    public static class RykaVossAudioProfile
    {
        public static readonly string VoiceIntro = "ryka_voss_voice_intro";
        public static readonly string VoiceVictory = "ryka_voss_voice_victory";
        public static readonly string VoiceDefeat = "ryka_voss_voice_defeat";
        public static readonly string VoiceAwakening = "ryka_voss_voice_awakening";
        public static readonly string VoiceUltimate = "ryka_voss_voice_ultimate";

        public static readonly string SfxLightAttack = "ryka_voss_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "ryka_voss_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "ryka_voss_sfx_special1";
        public static readonly string SfxSpecial2 = "ryka_voss_sfx_special2";
        public static readonly string SfxSpecial3 = "ryka_voss_sfx_special3";
        public static readonly string SfxUltimateClimax = "ryka_voss_sfx_ultimate_climax";

        public static readonly string ElementalHum = "ember_ambient_hum";

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
