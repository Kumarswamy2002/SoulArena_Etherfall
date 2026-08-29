using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Story
{
    public class CutsceneDirector
    {
        public bool IsCutscenePlaying { get; private set; } = false;
        public int CurrentDialogueIndex { get; private set; } = 0;
        public float CurrentLineElapsed { get; private set; } = 0.0f;
        public List<StoryDialogueEntry> ActiveDialogueTrack { get; private set; } = new List<StoryDialogueEntry>();

        public event Action<StoryDialogueEntry> OnDialogueLineStarted;
        public event Action OnCutsceneFinished;

        public void StartCutscene(int chapterNumber)
        {
            ActiveDialogueTrack = StoryDialogueDatabase.GetChapterDialogue(chapterNumber);
            if (ActiveDialogueTrack.Count == 0) return;

            IsCutscenePlaying = true;
            CurrentDialogueIndex = 0;
            CurrentLineElapsed = 0.0f;

            OnDialogueLineStarted?.Invoke(ActiveDialogueTrack[CurrentDialogueIndex]);
        }

        public void Update(float deltaTime)
        {
            if (!IsCutscenePlaying || ActiveDialogueTrack.Count == 0) return;

            CurrentLineElapsed += deltaTime;
            if (CurrentLineElapsed >= ActiveDialogueTrack[CurrentDialogueIndex].DisplayDuration)
            {
                CurrentLineElapsed = 0.0f;
                CurrentDialogueIndex++;

                if (CurrentDialogueIndex < ActiveDialogueTrack.Count)
                {
                    OnDialogueLineStarted?.Invoke(ActiveDialogueTrack[CurrentDialogueIndex]);
                }
                else
                {
                    EndCutscene();
                }
            }
        }

        public void SkipLine()
        {
            if (!IsCutscenePlaying) return;
            CurrentLineElapsed = 0.0f;
            CurrentDialogueIndex++;

            if (CurrentDialogueIndex < ActiveDialogueTrack.Count)
            {
                OnDialogueLineStarted?.Invoke(ActiveDialogueTrack[CurrentDialogueIndex]);
            }
            else
            {
                EndCutscene();
            }
        }

        public void EndCutscene()
        {
            IsCutscenePlaying = false;
            ActiveDialogueTrack.Clear();
            CurrentDialogueIndex = 0;
            CurrentLineElapsed = 0.0f;
            OnCutsceneFinished?.Invoke();
        }
    }
}
