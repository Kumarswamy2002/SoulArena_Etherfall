using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Drakor Thane (Iron Colossus).
    /// </summary>
    public static class DrakorThaneComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "drakor_thane_light1", "drakor_thane_light2", "drakor_thane_light3", "drakor_thane_special1" },
            new string[] { "drakor_thane_light1", "drakor_thane_launcher", "drakor_thane_air_strike", "drakor_thane_special3" },
            new string[] { "drakor_thane_heavy", "drakor_thane_special1", "drakor_thane_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "drakor_thane_heavy", "drakor_thane_light2", "drakor_thane_launcher", "drakor_thane_air_strike", "drakor_thane_special2" },
            new string[] { "drakor_thane_special3", "drakor_thane_light1", "drakor_thane_light2", "drakor_thane_special1", "drakor_thane_ultimate" }
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
