using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Kade Rourke (Iron Marauder).
    /// </summary>
    public static class KadeRourkeComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "kade_rourke_light1", "kade_rourke_light2", "kade_rourke_light3", "kade_rourke_special1" },
            new string[] { "kade_rourke_light1", "kade_rourke_launcher", "kade_rourke_air_strike", "kade_rourke_special3" },
            new string[] { "kade_rourke_heavy", "kade_rourke_special1", "kade_rourke_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "kade_rourke_heavy", "kade_rourke_light2", "kade_rourke_launcher", "kade_rourke_air_strike", "kade_rourke_special2" },
            new string[] { "kade_rourke_special3", "kade_rourke_light1", "kade_rourke_light2", "kade_rourke_special1", "kade_rourke_ultimate" }
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
