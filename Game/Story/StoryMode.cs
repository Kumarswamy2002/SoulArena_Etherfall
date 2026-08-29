using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.Story
{
    [Serializable]
    public class DialogueLine
    {
        public string SpeakerName;
        public string Text;
        public string Emotion;
    }

    [Serializable]
    public class StoryChapter
    {
        public int ChapterNumber;
        public string ChapterTitle;
        public string PlayerFighterId;
        public string OpponentFighterId;
        public ArenaId Arena;
        public List<DialogueLine> PreFightDialogue = new List<DialogueLine>();
        public List<DialogueLine> PostFightVictoryDialogue = new List<DialogueLine>();
        public string SpecialObjective;
    }

    public class StoryModeRunner
    {
        public List<StoryChapter> Chapters { get; private set; } = new List<StoryChapter>();
        public int CurrentChapterIndex { get; private set; } = 0;

        public StoryChapter CurrentChapter => (CurrentChapterIndex >= 0 && CurrentChapterIndex < Chapters.Count) 
            ? Chapters[CurrentChapterIndex] 
            : null;

        public StoryModeRunner()
        {
            InitializeStoryline();
        }

        private void InitializeStoryline()
        {
            Chapters.Add(new StoryChapter
            {
                ChapterNumber = 1,
                ChapterTitle = "Awakening of the Storm",
                PlayerFighterId = "kael_varyn",
                OpponentFighterId = "ryka_voss",
                Arena = ArenaId.SkyforgeTemple,
                PreFightDialogue = new List<DialogueLine>
                {
                    new DialogueLine { SpeakerName = "Ryka Voss", Text = "Your storm blades won't quench the embers of my wrath, Kael!", Emotion = "Furious" },
                    new DialogueLine { SpeakerName = "Kael Varyn", Text = "The skies do not negotiate with wildfires. Draw your chains.", Emotion = "Calm" }
                },
                PostFightVictoryDialogue = new List<DialogueLine>
                {
                    new DialogueLine { SpeakerName = "Kael Varyn", Text = "The tempest stands unbroken. Tell me where the First Soul sleeps.", Emotion = "Determined" }
                },
                SpecialObjective = "Defeat Ryka Voss while maintaining above 50% health."
            });

            Chapters.Add(new StoryChapter
            {
                ChapterNumber = 2,
                ChapterTitle = "Echoes of the Glacial Spire",
                PlayerFighterId = "kael_varyn",
                OpponentFighterId = "seren_vale",
                Arena = ArenaId.FrostveilSanctuary,
                PreFightDialogue = new List<DialogueLine>
                {
                    new DialogueLine { SpeakerName = "Seren Vale", Text = "Halt, Stormbound. None trespass into the Frostveil without freezing in crystal.", Emotion = "Cold" },
                    new DialogueLine { SpeakerName = "Kael Varyn", Text = "Lightning breaks all crystals. Step aside, Seren.", Emotion = "Serious" }
                },
                SpecialObjective = "Perform a 5-hit combo."
            });

            Chapters.Add(new StoryChapter
            {
                ChapterNumber = 3,
                ChapterTitle = "Etherfall: The Final Genesis",
                PlayerFighterId = "kael_varyn",
                OpponentFighterId = "auren_zeth",
                Arena = ArenaId.SoulforgeColiseum,
                PreFightDialogue = new List<DialogueLine>
                {
                    new DialogueLine { SpeakerName = "Auren Zeth", Text = "I forged the Ether from nothingness. Mortals are but sparks in my eternal furnace.", Emotion = "Godlike" },
                    new DialogueLine { SpeakerName = "Kael Varyn", Text = "Then today, the spark extinguishes the flame. Awaken, Stormbound!", Emotion = "Awakened" }
                },
                SpecialObjective = "Defeat Auren Zeth using an Ultimate Attack."
            });
        }

        public bool AdvanceToNextChapter()
        {
            if (CurrentChapterIndex < Chapters.Count - 1)
            {
                CurrentChapterIndex++;
                return true;
            }
            return false;
        }
    }
}
