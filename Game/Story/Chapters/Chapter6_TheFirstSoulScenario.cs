using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.Story.Chapters
{
    /// <summary>
    /// Story Chapter 6: TheFirstSoul
    /// Description: The First Soul: Final climactic showdown against Auren Zeth in the Soulforge
    /// </summary>
    public class Chapter6_TheFirstSoulScenario
    {
        public int ChapterNumber { get; } = 6;
        public string Title { get; } = "TheFirstSoul";
        public string Description { get; } = "The First Soul: Final climactic showdown against Auren Zeth in the Soulforge";
        public bool IsChapterCompleted { get; private set; } = false;
        public int ObjectivesAccomplished { get; private set; } = 0;

        public event Action<int, string> OnChapterObjectiveCompleted;
        public event Action<int> OnChapterFinished;

        public void CompleteObjective(int objectiveIndex, string description)
        {
            ObjectivesAccomplished++;
            OnChapterObjectiveCompleted?.Invoke(objectiveIndex, description);

            if (ObjectivesAccomplished >= 3)
            {
                IsChapterCompleted = true;
                OnChapterFinished?.Invoke(ChapterNumber);
            }
        }
    }
}
