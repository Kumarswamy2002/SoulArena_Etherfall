using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Cosmetics
{
    /// <summary>
    /// Cosmetic Skins, Weapon Recolors, and Visual Unlocks for Morvan Kreel (Grave King).
    /// </summary>
    public static class MorvanKreelCosmeticCatalog
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
            new SkinData { SkinId = "morvan_kreel_default", DisplayName = "Classic Grave King", Rarity = "Common", TextureOverride = "default" },
            new SkinData { SkinId = "morvan_kreel_recolor_alt", DisplayName = "Astral Eclipse", Rarity = "Rare", TextureOverride = "alt1" },
            new SkinData { SkinId = "morvan_kreel_awakened_sovereign", DisplayName = "Prime Death Sovereign", Rarity = "Legendary", TextureOverride = "legendary" }
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
