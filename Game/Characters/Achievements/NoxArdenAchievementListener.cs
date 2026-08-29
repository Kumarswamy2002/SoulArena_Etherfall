using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Achievements
{
    /// <summary>
    /// Milestone & Mastery Achievement Evaluator for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenAchievementListener
    {
        public int MatchesWon { get; private set; } = 0;
        public int TotalUltimatesLanded { get; private set; } = 0;
        public int PerfectGuardsPerformed { get; private set; } = 0;

        public event Action<string> OnMilestoneUnlocked;

        public void RecordMatchVictory()
        {
            MatchesWon++;
            if (MatchesWon == 10)
            {
                OnMilestoneUnlocked?.Invoke("nox_arden_10_wins");
            }
            else if (MatchesWon == 50)
            {
                OnMilestoneUnlocked?.Invoke("nox_arden_50_wins_master");
            }
        }

        public void RecordUltimateImpact()
        {
            TotalUltimatesLanded++;
            if (TotalUltimatesLanded == 25)
            {
                OnMilestoneUnlocked?.Invoke("nox_arden_25_ultimates");
            }
        }
    }
}
