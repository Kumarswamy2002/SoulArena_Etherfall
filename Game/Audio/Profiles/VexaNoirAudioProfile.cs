using System;
using System.Collections.Generic;

namespace SoulArena.Audio.Profiles
{
    /// <summary>
    /// Audio Profile Sound Bank & Voice Cue Mapping for Vexa Noir (Void Walker).
    /// </summary>
    public static class VexaNoirAudioProfile
    {
        public static readonly string VoiceIntro = "vexa_noir_voice_intro";
        public static readonly string VoiceVictory = "vexa_noir_voice_victory";
        public static readonly string VoiceDefeat = "vexa_noir_voice_defeat";
        public static readonly string VoiceAwakening = "vexa_noir_voice_awakening";
        public static readonly string VoiceUltimate = "vexa_noir_voice_ultimate";

        public static readonly string SfxLightAttack = "vexa_noir_sfx_light_swing";
        public static readonly string SfxHeavyAttack = "vexa_noir_sfx_heavy_impact";
        public static readonly string SfxSpecial1 = "vexa_noir_sfx_special1";
        public static readonly string SfxSpecial2 = "vexa_noir_sfx_special2";
        public static readonly string SfxSpecial3 = "vexa_noir_sfx_special3";
        public static readonly string SfxUltimateClimax = "vexa_noir_sfx_ultimate_climax";

        public static readonly string ElementalHum = "void_ambient_hum";

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
