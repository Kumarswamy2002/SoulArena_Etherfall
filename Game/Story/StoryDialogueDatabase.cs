using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Story
{
    public struct StoryDialogueEntry
    {
        public string SpeakerId;
        public string SpeakerName;
        public string LineText;
        public string EmotionTag;
        public float DisplayDuration;
        public string AudioVoiceClip;
    }

    /// <summary>
    /// Master Story Dialogue Catalog covering Chapters 1 through 10 with narrative arcs for all 20 fighters.
    /// </summary>
    public static class StoryDialogueDatabase
    {
        private static readonly Dictionary<int, List<StoryDialogueEntry>> _chapterDialogues = new Dictionary<int, List<StoryDialogueEntry>>();

        static StoryDialogueDatabase()
        {
            InitializeAllChapters();
        }

        private static void InitializeAllChapters()
        {
            // Chapter 1: The Storm Gathers
            _chapterDialogues[1] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "kael_varyn", SpeakerName = "Kael Varyn", LineText = "The ether currents in the Skyforge Temple are trembling.", EmotionTag = "Serious", DisplayDuration = 3.5f, AudioVoiceClip = "kael_ch1_01" },
                new StoryDialogueEntry { SpeakerId = "ryka_voss", SpeakerName = "Ryka Voss", LineText = "They tremble because my flame burns away the false peace of the Enclave!", EmotionTag = "Aggressive", DisplayDuration = 4.0f, AudioVoiceClip = "ryka_ch1_01" },
                new StoryDialogueEntry { SpeakerId = "kael_varyn", SpeakerName = "Kael Varyn", LineText = "Let us see if your embers survive the tempest.", EmotionTag = "Resolute", DisplayDuration = 3.0f, AudioVoiceClip = "kael_ch1_02" }
            };

            // Chapter 2: Frozen Resonances
            _chapterDialogues[2] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "seren_vale", SpeakerName = "Seren Vale", LineText = "None may pass into the Frostveil Sanctuary while the ancient seals crack.", EmotionTag = "Cold", DisplayDuration = 3.8f, AudioVoiceClip = "seren_ch2_01" },
                new StoryDialogueEntry { SpeakerId = "zayn_rheo", SpeakerName = "Zayn Rheo", LineText = "Ice is only an obstacle for those too slow to run around it.", EmotionTag = "Smug", DisplayDuration = 3.2f, AudioVoiceClip = "zayn_ch2_01" },
                new StoryDialogueEntry { SpeakerId = "seren_vale", SpeakerName = "Seren Vale", LineText = "Lightning freezes just like blood when absolute zero descends.", EmotionTag = "Focused", DisplayDuration = 3.5f, AudioVoiceClip = "seren_ch2_02" }
            };

            // Chapter 3: Seismic Roots
            _chapterDialogues[3] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "drakor_thane", SpeakerName = "Drakor Thane", LineText = "Stand fast. The earth beneath the Verdant Ruins remembers the First Soul.", EmotionTag = "Deep", DisplayDuration = 4.2f, AudioVoiceClip = "drakor_ch3_01" },
                new StoryDialogueEntry { SpeakerId = "nyla_verd", SpeakerName = "Nyla Verd", LineText = "The spirits whisper of an eternal winter unless the Ether forge is reignited.", EmotionTag = "Concerned", DisplayDuration = 4.0f, AudioVoiceClip = "nyla_ch3_01" }
            };

            // Chapter 4: Shadows of the Void
            _chapterDialogues[4] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "vexa_noir", SpeakerName = "Vexa Noir", LineText = "In the Null Realm, even light is swallowed into eternal silence.", EmotionTag = "Mysterious", DisplayDuration = 3.6f, AudioVoiceClip = "vexa_ch4_01" },
                new StoryDialogueEntry { SpeakerId = "elara_sol", SpeakerName = "Elara Sol", LineText = "Where shadows deepen, the dawn burns with greater radiance!", EmotionTag = "Righteous", DisplayDuration = 3.8f, AudioVoiceClip = "elara_ch4_01" }
            };

            // Chapter 5: Blood and Gale
            _chapterDialogues[5] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "raven_drake", SpeakerName = "Raven Drake", LineText = "Every slash costs vitality, but the crimson resonance demands sacrifice.", EmotionTag = "Grim", DisplayDuration = 4.0f, AudioVoiceClip = "raven_ch5_01" },
                new StoryDialogueEntry { SpeakerId = "torren_kai", SpeakerName = "Torren Kai", LineText = "The wind flows unbound. Your blood magic cannot bind what it cannot touch!", EmotionTag = "Confident", DisplayDuration = 3.5f, AudioVoiceClip = "torren_ch5_01" }
            };

            // Chapter 6: The Mind's Labyrinth
            _chapterDialogues[6] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "orin_veil", SpeakerName = "Orin Veil", LineText = "Your thoughts are an open scroll to the Psionic weave.", EmotionTag = "Analytical", DisplayDuration = 3.7f, AudioVoiceClip = "orin_ch6_01" },
                new StoryDialogueEntry { SpeakerId = "solan_ark", SpeakerName = "Solan Ark", LineText = "Read this then: an exploding supernova straight to the face!", EmotionTag = "Passionate", DisplayDuration = 3.4f, AudioVoiceClip = "solan_ch6_01" }
            };

            // Chapter 7: Iron Tide
            _chapterDialogues[7] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "kade_rourke", SpeakerName = "Kade Rourke", LineText = "Hydraulics primed, steam pressure rising. Let us crush some steel!", EmotionTag = "Boisterous", DisplayDuration = 3.8f, AudioVoiceClip = "kade_ch7_01" },
                new StoryDialogueEntry { SpeakerId = "mira_tide", SpeakerName = "Mira Tide", LineText = "Water wears away the hardest steel. Your pistons will rust in the tide.", EmotionTag = "Calm", DisplayDuration = 3.9f, AudioVoiceClip = "mira_ch7_01" }
            };

            // Chapter 8: Astral Beast
            _chapterDialogues[8] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "aeris_quin", SpeakerName = "Aeris Quin", LineText = "The stars align in fateful constellations. Disaster looms overhead.", EmotionTag = "Mystic", DisplayDuration = 4.1f, AudioVoiceClip = "aeris_ch8_01" },
                new StoryDialogueEntry { SpeakerId = "rokan_fen", SpeakerName = "Rokan Fen", LineText = "I don't look at stars when there is prey on the battlefield!", EmotionTag = "Feral", DisplayDuration = 3.3f, AudioVoiceClip = "rokan_ch8_01" }
            };

            // Chapter 9: Rift of Spirits
            _chapterDialogues[9] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "nox_arden", SpeakerName = "Nox Arden", LineText = "The boundary between dimensions dissolves. Eternity awaits.", EmotionTag = "Menacing", DisplayDuration = 3.7f, AudioVoiceClip = "nox_ch9_01" },
                new StoryDialogueEntry { SpeakerId = "yuna_rei", SpeakerName = "Yuna Rei", LineText = "The spirit dance shall weave peace back into the torn sky.", EmotionTag = "Serene", DisplayDuration = 3.6f, AudioVoiceClip = "yuna_ch9_01" }
            };

            // Chapter 10: The Sovereign's Reckoning
            _chapterDialogues[10] = new List<StoryDialogueEntry>
            {
                new StoryDialogueEntry { SpeakerId = "auren_zeth", SpeakerName = "Auren Zeth", LineText = "Mortals dare challenge the First Soul? I am the forge of existence!", EmotionTag = "Omnipotent", DisplayDuration = 4.5f, AudioVoiceClip = "auren_ch10_01" },
                new StoryDialogueEntry { SpeakerId = "kael_varyn", SpeakerName = "Kael Varyn", LineText = "Then behold our united resonance! Etherfall: Genesis!", EmotionTag = "Climactic", DisplayDuration = 4.0f, AudioVoiceClip = "kael_ch10_03" }
            };
        }

        public static List<StoryDialogueEntry> GetChapterDialogue(int chapterNumber)
        {
            if (_chapterDialogues.TryGetValue(chapterNumber, out var list))
            {
                return list;
            }
            return new List<StoryDialogueEntry>();
        }
    }
}
