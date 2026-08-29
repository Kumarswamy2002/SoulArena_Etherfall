using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Cosmetics
{
    /// <summary>
    /// Cosmetic Skins, Weapon Recolors, and Visual Unlocks for Elara Sol (Dawn Saint).
    /// </summary>
    public static class ElaraSolCosmeticCatalog
    {
        public struct SkinData
        {
            public string SkinId;
            public string DisplayName;
            public string Rarity;
            public string TextureOverride;
        }

        public static readonly List<SkinData> AvailableSkins = new List<SkinData>
        {
            new SkinData { SkinId = "elara_sol_default", DisplayName = "Classic Dawn Saint", Rarity = "Common", TextureOverride = "default" },
            new SkinData { SkinId = "elara_sol_recolor_alt", DisplayName = "Astral Eclipse", Rarity = "Rare", TextureOverride = "alt1" },
            new SkinData { SkinId = "elara_sol_awakened_sovereign", DisplayName = "Prime Radiance Sovereign", Rarity = "Legendary", TextureOverride = "legendary" }
        };

        public static SkinData GetSkin(string skinId)
        {
            foreach (var skin in AvailableSkins)
            {
                if (skin.SkinId == skinId) return skin;
            }
            return AvailableSkins[0];
        }
    }
}
