using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.AI.ComboPlans
{
    /// <summary>
    /// AI Optimal Combo Sequence Plan & Confirm Trees for Rokan Fen (Beast Soul).
    /// </summary>
    public static class RokanFenComboPlan
    {
        public static readonly List<string[]> BreadAndButterCombos = new List<string[]>
        {
            new string[] { "rokan_fen_light1", "rokan_fen_light2", "rokan_fen_light3", "rokan_fen_special1" },
            new string[] { "rokan_fen_light1", "rokan_fen_launcher", "rokan_fen_air_strike", "rokan_fen_special3" },
            new string[] { "rokan_fen_heavy", "rokan_fen_special1", "rokan_fen_ultimate" }
        };

        public static readonly List<string[]> CornerCombos = new List<string[]>
        {
            new string[] { "rokan_fen_heavy", "rokan_fen_light2", "rokan_fen_launcher", "rokan_fen_air_strike", "rokan_fen_special2" },
            new string[] { "rokan_fen_special3", "rokan_fen_light1", "rokan_fen_light2", "rokan_fen_special1", "rokan_fen_ultimate" }
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
