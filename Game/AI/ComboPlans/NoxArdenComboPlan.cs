using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Nox Arden (Riftborn).
    /// </summary>
    public static class NoxArdenComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "nox_arden_light1", "nox_arden_light2", "nox_arden_light3", "nox_arden_special1" },
            new string[] { "nox_arden_light1", "nox_arden_launcher", "nox_arden_air_strike", "nox_arden_special3" },
            new string[] { "nox_arden_heavy", "nox_arden_special1", "nox_arden_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "nox_arden_heavy", "nox_arden_light2", "nox_arden_launcher", "nox_arden_air_strike", "nox_arden_special2" },
            new string[] { "nox_arden_special3", "nox_arden_light1", "nox_arden_light2", "nox_arden_special1", "nox_arden_ultimate" }
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
