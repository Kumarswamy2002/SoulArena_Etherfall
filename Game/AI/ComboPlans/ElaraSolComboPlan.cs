using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Elara Sol (Dawn Saint).
    /// </summary>
    public static class ElaraSolComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "elara_sol_light1", "elara_sol_light2", "elara_sol_light3", "elara_sol_special1" },
            new string[] { "elara_sol_light1", "elara_sol_launcher", "elara_sol_air_strike", "elara_sol_special3" },
            new string[] { "elara_sol_heavy", "elara_sol_special1", "elara_sol_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "elara_sol_heavy", "elara_sol_light2", "elara_sol_launcher", "elara_sol_air_strike", "elara_sol_special2" },
            new string[] { "elara_sol_special3", "elara_sol_light1", "elara_sol_light2", "elara_sol_special1", "elara_sol_ultimate" }
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
