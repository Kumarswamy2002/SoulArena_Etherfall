using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Nox Arden (Riftborn).
    /// </summary>
    public static class NoxArdenAudioProfile
    {
        public static readonly string VoiceIntro = "nox_arden_voice_intro";
        public static readonly string VoiceVictory = "nox_arden_voice_victory";
        public static readonly string VoiceDefeat = "nox_arden_voice_defeat";
        public static readonly string VoiceAwakening = "nox_arden_voice_awakening";
        public static readonly string VoiceUltimate = "nox_arden_voice_ultimate";

        public static readonly string SfxLightAttack = "nox_arden_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "nox_arden_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "nox_arden_sfx_special1";
        public static readonly string SfxSpecial2 = "nox_arden_sfx_special2";
        public static readonly string SfxSpecial3 = "nox_arden_sfx_special3";
        public static readonly string SfxUltimateClimax = "nox_arden_sfx_ultimate_climax";

        public static readonly string ElementalHum = "rift_ambient_hum";

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
