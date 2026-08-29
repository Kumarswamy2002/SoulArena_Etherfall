using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Morvan Kreel (Grave King).
    /// </summary>
    public static class MorvanKreelComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "morvan_kreel_light1", "morvan_kreel_light2", "morvan_kreel_light3", "morvan_kreel_special1" },
            new string[] { "morvan_kreel_light1", "morvan_kreel_launcher", "morvan_kreel_air_strike", "morvan_kreel_special3" },
            new string[] { "morvan_kreel_heavy", "morvan_kreel_special1", "morvan_kreel_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "morvan_kreel_heavy", "morvan_kreel_light2", "morvan_kreel_launcher", "morvan_kreel_air_strike", "morvan_kreel_special2" },
            new string[] { "morvan_kreel_special3", "morvan_kreel_light1", "morvan_kreel_light2", "morvan_kreel_special1", "morvan_kreel_ultimate" }
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
