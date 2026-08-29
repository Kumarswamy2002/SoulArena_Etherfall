using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Orin Veil (Mind Weaver).
    /// </summary>
    public static class OrinVeilComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "orin_veil_light1", "orin_veil_light2", "orin_veil_light3", "orin_veil_special1" },
            new string[] { "orin_veil_light1", "orin_veil_launcher", "orin_veil_air_strike", "orin_veil_special3" },
            new string[] { "orin_veil_heavy", "orin_veil_special1", "orin_veil_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "orin_veil_heavy", "orin_veil_light2", "orin_veil_launcher", "orin_veil_air_strike", "orin_veil_special2" },
            new string[] { "orin_veil_special3", "orin_veil_light1", "orin_veil_light2", "orin_veil_special1", "orin_veil_ultimate" }
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
