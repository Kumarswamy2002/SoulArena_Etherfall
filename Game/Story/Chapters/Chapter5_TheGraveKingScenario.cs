using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.Story.Chapters
{
    /// <summary>
    /// Story Chapter 5: TheGraveKing
    /// Description: The Grave King: Morvan Kreel's army of fallen spirits in the Cathedral
    /// </summary>
    public class Chapter5_TheGraveKingScenario
    {
        public int ChapterNumber { get; } = 5;
        public string Title { get; } = "TheGraveKing";
        public string Description { get; } = "The Grave King: Morvan Kreel's army of fallen spirits in the Cathedral";
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
