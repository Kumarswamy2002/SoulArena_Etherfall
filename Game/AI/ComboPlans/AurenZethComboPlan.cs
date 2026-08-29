using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Auren Zeth (First Soul).
    /// </summary>
    public static class AurenZethComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "auren_zeth_light1", "auren_zeth_light2", "auren_zeth_light3", "auren_zeth_special1" },
            new string[] { "auren_zeth_light1", "auren_zeth_launcher", "auren_zeth_air_strike", "auren_zeth_special3" },
            new string[] { "auren_zeth_heavy", "auren_zeth_special1", "auren_zeth_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "auren_zeth_heavy", "auren_zeth_light2", "auren_zeth_launcher", "auren_zeth_air_strike", "auren_zeth_special2" },
            new string[] { "auren_zeth_special3", "auren_zeth_light1", "auren_zeth_light2", "auren_zeth_special1", "auren_zeth_ultimate" }
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
