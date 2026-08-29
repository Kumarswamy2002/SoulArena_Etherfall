using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Cosmetics
{
    /// <summary>
    /// Cosmetic Skins, Weapon Recolors, and Visual Unlocks for Ryka Voss (Ember Wolf).
    /// </summary>
    public static class RykaVossCosmeticCatalog
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
            new SkinData { SkinId = "ryka_voss_default", DisplayName = "Classic Ember Wolf", Rarity = "Common", TextureOverride = "default" },
            new SkinData { SkinId = "ryka_voss_recolor_alt", DisplayName = "Astral Eclipse", Rarity = "Rare", TextureOverride = "alt1" },
            new SkinData { SkinId = "ryka_voss_awakened_sovereign", DisplayName = "Prime Ember Sovereign", Rarity = "Legendary", TextureOverride = "legendary" }
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
