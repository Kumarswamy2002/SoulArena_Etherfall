using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Vexa Noir (Void Walker).
    /// </summary>
    public static class VexaNoirComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "vexa_noir_light1", "vexa_noir_light2", "vexa_noir_light3", "vexa_noir_special1" },
            new string[] { "vexa_noir_light1", "vexa_noir_launcher", "vexa_noir_air_strike", "vexa_noir_special3" },
            new string[] { "vexa_noir_heavy", "vexa_noir_special1", "vexa_noir_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "vexa_noir_heavy", "vexa_noir_light2", "vexa_noir_launcher", "vexa_noir_air_strike", "vexa_noir_special2" },
            new string[] { "vexa_noir_special3", "vexa_noir_light1", "vexa_noir_light2", "vexa_noir_special1", "vexa_noir_ultimate" }
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
