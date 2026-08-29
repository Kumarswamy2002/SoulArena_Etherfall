using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.Story.Chapters
{
    /// <summary>
    /// Story Chapter 3: TheFrozenGate
    /// Description: The Frozen Gate: Seren Vale guards the Frostveil seal
    /// </summary>
    public class Chapter3_TheFrozenGateScenario
    {
        public int ChapterNumber { get; } = 3;
        public string Title { get; } = "TheFrozenGate";
        public string Description { get; } = "The Frozen Gate: Seren Vale guards the Frostveil seal";
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
