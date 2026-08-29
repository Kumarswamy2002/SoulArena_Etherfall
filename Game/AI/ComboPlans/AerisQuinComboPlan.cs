using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Aeris Quin (Star Weaver).
    /// </summary>
    public static class AerisQuinComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "aeris_quin_light1", "aeris_quin_light2", "aeris_quin_light3", "aeris_quin_special1" },
            new string[] { "aeris_quin_light1", "aeris_quin_launcher", "aeris_quin_air_strike", "aeris_quin_special3" },
            new string[] { "aeris_quin_heavy", "aeris_quin_special1", "aeris_quin_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "aeris_quin_heavy", "aeris_quin_light2", "aeris_quin_launcher", "aeris_quin_air_strike", "aeris_quin_special2" },
            new string[] { "aeris_quin_special3", "aeris_quin_light1", "aeris_quin_light2", "aeris_quin_special1", "aeris_quin_ultimate" }
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
