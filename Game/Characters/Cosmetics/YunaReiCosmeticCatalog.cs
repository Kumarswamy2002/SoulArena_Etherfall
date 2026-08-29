using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Cosmetics
{
    /// <summary>
    /// Cosmetic Skins, Weapon Recolors, and Visual Unlocks for Yuna Rei (Spirit Dancer).
    /// </summary>
    public static class YunaReiCosmeticCatalog
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
            new SkinData { SkinId = "yuna_rei_default", DisplayName = "Classic Spirit Dancer", Rarity = "Common", TextureOverride = "default" },
            new SkinData { SkinId = "yuna_rei_recolor_alt", DisplayName = "Astral Eclipse", Rarity = "Rare", TextureOverride = "alt1" },
            new SkinData { SkinId = "yuna_rei_awakened_sovereign", DisplayName = "Prime Spirit Sovereign", Rarity = "Legendary", TextureOverride = "legendary" }
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
