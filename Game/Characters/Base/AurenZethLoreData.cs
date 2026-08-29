using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Base
{
    /// <summary>
    /// Extended Profile, Lore Excerpts, and Balance Notes for Auren Zeth (First Soul).
    /// </summary>
    public static class AurenZethLoreData
    {
        public const string CharacterCode = "auren_zeth";
        public const string RegionOfOrigin = "Soulforge Realm";
        public const string WeaponClass = "Soulforged Relic";

        public static readonly string[] LoreDialogueLines = new string[]
        {
            "The Ether will forge a new dawn.",
            "Stand down before the PrimeEther power consumes you.",
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
