using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.Story.Chapters
{
    /// <summary>
    /// Story Chapter 4: TheRiftOpens
    /// Description: The Rift Opens: Vexa Noir and Nox Arden unravel dimensional boundaries
    /// </summary>
    public class Chapter4_TheRiftOpensScenario
    {
        public int ChapterNumber { get; } = 4;
        public string Title { get; } = "TheRiftOpens";
        public string Description { get; } = "The Rift Opens: Vexa Noir and Nox Arden unravel dimensional boundaries";
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
