using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.Story.Chapters
{
    /// <summary>
    /// Story Chapter 2: StormAndEmber
    /// Description: Storm and Ember: Kael Varyn vs. Ryka Voss volcanic confrontation
    /// </summary>
    public class Chapter2_StormAndEmberScenario
    {
        public int ChapterNumber { get; } = 2;
        public string Title { get; } = "StormAndEmber";
        public string Description { get; } = "Storm and Ember: Kael Varyn vs. Ryka Voss volcanic confrontation";
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
