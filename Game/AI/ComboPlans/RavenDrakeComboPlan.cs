using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Raven Drake (Blood Knight).
    /// </summary>
    public static class RavenDrakeComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "raven_drake_light1", "raven_drake_light2", "raven_drake_light3", "raven_drake_special1" },
            new string[] { "raven_drake_light1", "raven_drake_launcher", "raven_drake_air_strike", "raven_drake_special3" },
            new string[] { "raven_drake_heavy", "raven_drake_special1", "raven_drake_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "raven_drake_heavy", "raven_drake_light2", "raven_drake_launcher", "raven_drake_air_strike", "raven_drake_special2" },
            new string[] { "raven_drake_special3", "raven_drake_light1", "raven_drake_light2", "raven_drake_special1", "raven_drake_ultimate" }
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
