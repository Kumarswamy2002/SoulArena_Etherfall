using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Achievements
{
    /// <summary>
    /// Milestone & Mastery Achievement Evaluator for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilAchievementListener
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
                OnMilestoneUnlocked?.Invoke("orin_veil_10_wins");
            }
            else if (MatchesWon == 50)
            {
                OnMilestoneUnlocked?.Invoke("orin_veil_50_wins_master");
            }
        }

        public void RecordUltimateImpact()
        {
            TotalUltimatesLanded++;
            if (TotalUltimatesLanded == 25)
            {
                OnMilestoneUnlocked?.Invoke("orin_veil_25_ultimates");
            }
        }
    }
}
