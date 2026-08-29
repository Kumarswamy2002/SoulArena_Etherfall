using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.FrameData
{
    /// <summary>
    /// Frame Data Table & Lookup Dictionary for Vexa Noir (Void Walker).
    /// </summary>
    public static class VexaNoirFrameDataTable
    {
        public struct FrameEntry
        {
            public string MoveName;
            public int Startup;
            public int Active;
            public int Recovery;
            public int OnHitAdvantage;
            public int OnBlockAdvantage;
            public float Damage;
            public float GuardDmg;
        }

        public static readonly Dictionary<string, FrameEntry> Table = new Dictionary<string, FrameEntry>
        {
            ["Light1"] = new FrameEntry { MoveName = "Vexa Noir Light 1", Startup = 4, Active = 3, Recovery = 7, OnHitAdvantage = 4, OnBlockAdvantage = 1, Damage = 25f, GuardDmg = 10f },
            ["Light2"] = new FrameEntry { MoveName = "Vexa Noir Light 2", Startup = 5, Active = 3, Recovery = 8, OnHitAdvantage = 5, OnBlockAdvantage = 0, Damage = 35f, GuardDmg = 12f },
            ["Light3"] = new FrameEntry { MoveName = "Vexa Noir Light 3", Startup = 6, Active = 4, Recovery = 11, OnHitAdvantage = 8, OnBlockAdvantage = -2, Damage = 50f, GuardDmg = 18f },
            ["Heavy"] = new FrameEntry { MoveName = "Vexa Noir Heavy Strike", Startup = 12, Active = 5, Recovery = 18, OnHitAdvantage = 12, OnBlockAdvantage = -6, Damage = 85f, GuardDmg = 40f },
            ["Launcher"] = new FrameEntry { MoveName = "Vexa Noir Launcher", Startup = 9, Active = 4, Recovery = 15, OnHitAdvantage = 15, OnBlockAdvantage = -4, Damage = 60f, GuardDmg = 22f },
            ["AirStrike"] = new FrameEntry { MoveName = "Vexa Noir Aerial Strike", Startup = 5, Active = 4, Recovery = 9, OnHitAdvantage = 6, OnBlockAdvantage = 2, Damage = 45f, GuardDmg = 15f },
            ["Special1"] = new FrameEntry { MoveName = "Vexa Noir Special 1", Startup = 8, Active = 6, Recovery = 12, OnHitAdvantage = 10, OnBlockAdvantage = -3, Damage = 65f, GuardDmg = 28f },
            ["Special2"] = new FrameEntry { MoveName = "Vexa Noir Special 2", Startup = 12, Active = 4, Recovery = 16, OnHitAdvantage = 12, OnBlockAdvantage = -5, Damage = 85f, GuardDmg = 32f },
            ["Special3"] = new FrameEntry { MoveName = "Vexa Noir Special 3", Startup = 6, Active = 8, Recovery = 10, OnHitAdvantage = 8, OnBlockAdvantage = 1, Damage = 70f, GuardDmg = 25f },
            ["Ultimate"] = new FrameEntry { MoveName = "Vexa Noir Ultimate", Startup = 18, Active = 14, Recovery = 30, OnHitAdvantage = 30, OnBlockAdvantage = -10, Damage = 290f, GuardDmg = 85f }
        };

        public static FrameEntry GetEntry(string key)
        {
            if (Table.TryGetValue(key, out var entry))
            {
                return entry;
            }
            return default;
        }
    }
}
