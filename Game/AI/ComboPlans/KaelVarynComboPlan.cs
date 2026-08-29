using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Kael Varyn (Stormbound).
    /// </summary>
    public static class KaelVarynComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "kael_varyn_light1", "kael_varyn_light2", "kael_varyn_light3", "kael_varyn_special1" },
            new string[] { "kael_varyn_light1", "kael_varyn_launcher", "kael_varyn_air_strike", "kael_varyn_special3" },
            new string[] { "kael_varyn_heavy", "kael_varyn_special1", "kael_varyn_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "kael_varyn_heavy", "kael_varyn_light2", "kael_varyn_launcher", "kael_varyn_air_strike", "kael_varyn_special2" },
            new string[] { "kael_varyn_special3", "kael_varyn_light1", "kael_varyn_light2", "kael_varyn_special1", "kael_varyn_ultimate" }
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
