using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Raven Drake (Blood Knight).
    /// </summary>
    public static class RavenDrakeAudioProfile
    {
        public static readonly string VoiceIntro = "raven_drake_voice_intro";
        public static readonly string VoiceVictory = "raven_drake_voice_victory";
        public static readonly string VoiceDefeat = "raven_drake_voice_defeat";
        public static readonly string VoiceAwakening = "raven_drake_voice_awakening";
        public static readonly string VoiceUltimate = "raven_drake_voice_ultimate";

        public static readonly string SfxLightAttack = "raven_drake_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "raven_drake_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "raven_drake_sfx_special1";
        public static readonly string SfxSpecial2 = "raven_drake_sfx_special2";
        public static readonly string SfxSpecial3 = "raven_drake_sfx_special3";
        public static readonly string SfxUltimateClimax = "raven_drake_sfx_ultimate_climax";

        public static readonly string ElementalHum = "crimson_ambient_hum";

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
