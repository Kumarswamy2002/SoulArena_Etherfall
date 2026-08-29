using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Achievements
{
    /// <summary>
    /// Milestone & Mastery Achievement Evaluator for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiAchievementListener
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
                OnMilestoneUnlocked?.Invoke("torren_kai_10_wins");
            }
            else if (MatchesWon == 50)
            {
                OnMilestoneUnlocked?.Invoke("torren_kai_50_wins_master");
            }
        }

        public void RecordUltimateImpact()
        {
            TotalUltimatesLanded++;
            if (TotalUltimatesLanded == 25)
            {
                OnMilestoneUnlocked?.Invoke("torren_kai_25_ultimates");
            }
        }
    }
}
