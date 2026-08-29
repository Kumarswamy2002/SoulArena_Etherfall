using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Yuna Rei (Spirit Dancer).
    /// </summary>
    public static class YunaReiComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "yuna_rei_light1", "yuna_rei_light2", "yuna_rei_light3", "yuna_rei_special1" },
            new string[] { "yuna_rei_light1", "yuna_rei_launcher", "yuna_rei_air_strike", "yuna_rei_special3" },
            new string[] { "yuna_rei_heavy", "yuna_rei_special1", "yuna_rei_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "yuna_rei_heavy", "yuna_rei_light2", "yuna_rei_launcher", "yuna_rei_air_strike", "yuna_rei_special2" },
            new string[] { "yuna_rei_special3", "yuna_rei_light1", "yuna_rei_light2", "yuna_rei_special1", "yuna_rei_ultimate" }
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
