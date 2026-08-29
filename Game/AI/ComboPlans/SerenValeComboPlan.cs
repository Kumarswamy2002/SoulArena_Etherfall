using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Seren Vale (Frozen Blade).
    /// </summary>
    public static class SerenValeComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "seren_vale_light1", "seren_vale_light2", "seren_vale_light3", "seren_vale_special1" },
            new string[] { "seren_vale_light1", "seren_vale_launcher", "seren_vale_air_strike", "seren_vale_special3" },
            new string[] { "seren_vale_heavy", "seren_vale_special1", "seren_vale_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "seren_vale_heavy", "seren_vale_light2", "seren_vale_launcher", "seren_vale_air_strike", "seren_vale_special2" },
            new string[] { "seren_vale_special3", "seren_vale_light1", "seren_vale_light2", "seren_vale_special1", "seren_vale_ultimate" }
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
