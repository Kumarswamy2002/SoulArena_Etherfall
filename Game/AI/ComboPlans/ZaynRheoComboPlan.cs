using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public static class ZaynRheoComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "zayn_rheo_light1", "zayn_rheo_light2", "zayn_rheo_light3", "zayn_rheo_special1" },
            new string[] { "zayn_rheo_light1", "zayn_rheo_launcher", "zayn_rheo_air_strike", "zayn_rheo_special3" },
            new string[] { "zayn_rheo_heavy", "zayn_rheo_special1", "zayn_rheo_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "zayn_rheo_heavy", "zayn_rheo_light2", "zayn_rheo_launcher", "zayn_rheo_air_strike", "zayn_rheo_special2" },
            new string[] { "zayn_rheo_special3", "zayn_rheo_light1", "zayn_rheo_light2", "zayn_rheo_special1", "zayn_rheo_ultimate" }
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
