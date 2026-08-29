using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Torren Kai (Wind Dancer).
    /// </summary>
    public static class TorrenKaiComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "torren_kai_light1", "torren_kai_light2", "torren_kai_light3", "torren_kai_special1" },
            new string[] { "torren_kai_light1", "torren_kai_launcher", "torren_kai_air_strike", "torren_kai_special3" },
            new string[] { "torren_kai_heavy", "torren_kai_special1", "torren_kai_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "torren_kai_heavy", "torren_kai_light2", "torren_kai_launcher", "torren_kai_air_strike", "torren_kai_special2" },
            new string[] { "torren_kai_special3", "torren_kai_light1", "torren_kai_light2", "torren_kai_special1", "torren_kai_ultimate" }
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
