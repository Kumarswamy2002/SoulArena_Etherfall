using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Nyla Verd (Wild Caller).
    /// </summary>
    public static class NylaVerdComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "nyla_verd_light1", "nyla_verd_light2", "nyla_verd_light3", "nyla_verd_special1" },
            new string[] { "nyla_verd_light1", "nyla_verd_launcher", "nyla_verd_air_strike", "nyla_verd_special3" },
            new string[] { "nyla_verd_heavy", "nyla_verd_special1", "nyla_verd_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "nyla_verd_heavy", "nyla_verd_light2", "nyla_verd_launcher", "nyla_verd_air_strike", "nyla_verd_special2" },
            new string[] { "nyla_verd_special3", "nyla_verd_light1", "nyla_verd_light2", "nyla_verd_special1", "nyla_verd_ultimate" }
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
