using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Mira Tide (Tideblade).
    /// </summary>
    public static class MiraTideComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "mira_tide_light1", "mira_tide_light2", "mira_tide_light3", "mira_tide_special1" },
            new string[] { "mira_tide_light1", "mira_tide_launcher", "mira_tide_air_strike", "mira_tide_special3" },
            new string[] { "mira_tide_heavy", "mira_tide_special1", "mira_tide_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "mira_tide_heavy", "mira_tide_light2", "mira_tide_launcher", "mira_tide_air_strike", "mira_tide_special2" },
            new string[] { "mira_tide_special3", "mira_tide_light1", "mira_tide_light2", "mira_tide_special1", "mira_tide_ultimate" }
        };

        public static string[] GetOptimalCombo(bool isInCorner, bool hasAwakening)
        {
            if (isInCorner)
            {
                return CornerCombos[0];
            }
            return hasAwakening ? BreadAndButterCombos[2] : BreadAndButterCombos[0];
        }
    }
}
