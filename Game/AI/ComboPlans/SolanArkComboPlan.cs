using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Solan Ark (Sunforged).
    /// </summary>
    public static class SolanArkComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "solan_ark_light1", "solan_ark_light2", "solan_ark_light3", "solan_ark_special1" },
            new string[] { "solan_ark_light1", "solan_ark_launcher", "solan_ark_air_strike", "solan_ark_special3" },
            new string[] { "solan_ark_heavy", "solan_ark_special1", "solan_ark_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "solan_ark_heavy", "solan_ark_light2", "solan_ark_launcher", "solan_ark_air_strike", "solan_ark_special2" },
            new string[] { "solan_ark_special3", "solan_ark_light1", "solan_ark_light2", "solan_ark_special1", "solan_ark_ultimate" }
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
