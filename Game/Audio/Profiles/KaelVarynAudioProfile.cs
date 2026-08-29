using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Kael Varyn (Stormbound).
    /// </summary>
    public static class KaelVarynAudioProfile
    {
        public static readonly string VoiceIntro = "kael_varyn_voice_intro";
        public static readonly string VoiceVictory = "kael_varyn_voice_victory";
        public static readonly string VoiceDefeat = "kael_varyn_voice_defeat";
        public static readonly string VoiceAwakening = "kael_varyn_voice_awakening";
        public static readonly string VoiceUltimate = "kael_varyn_voice_ultimate";

        public static readonly string SfxLightAttack = "kael_varyn_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "kael_varyn_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "kael_varyn_sfx_special1";
        public static readonly string SfxSpecial2 = "kael_varyn_sfx_special2";
        public static readonly string SfxSpecial3 = "kael_varyn_sfx_special3";
        public static readonly string SfxUltimateClimax = "kael_varyn_sfx_ultimate_climax";

        public static readonly string ElementalHum = "storm_ambient_hum";

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
