using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Base
{
    /// <summary>
    /// Extended Profile, Lore Excerpts, and Balance Notes for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public static class ZaynRheoLoreData
    {
        public const string CharacterCode = "zayn_rheo";
        public const string RegionOfOrigin = "Soulforge Realm";
        public const string WeaponClass = "Soulforged Relic";

        public static readonly string[] LoreDialogueLines = new string[]
        {
            "The Ether will forge a new dawn.",
            "Stand down before the Volt power consumes you.",
            "My blade was quenched in celestial flame.",
            "Victory is the only path forward."
        };

        public static string GetRandomVictoryQuote()
        {
            var rng = new Random();
            return LoreDialogueLines[rng.Next(LoreDialogueLines.Length)];
        }
    }
}
