using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Ryka Voss (Ember Wolf).
    /// </summary>
    public static class RykaVossComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "ryka_voss_light1", "ryka_voss_light2", "ryka_voss_light3", "ryka_voss_special1" },
            new string[] { "ryka_voss_light1", "ryka_voss_launcher", "ryka_voss_air_strike", "ryka_voss_special3" },
            new string[] { "ryka_voss_heavy", "ryka_voss_special1", "ryka_voss_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "ryka_voss_heavy", "ryka_voss_light2", "ryka_voss_launcher", "ryka_voss_air_strike", "ryka_voss_special2" },
            new string[] { "ryka_voss_special3", "ryka_voss_light1", "ryka_voss_light2", "ryka_voss_special1", "ryka_voss_ultimate" }
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
