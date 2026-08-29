using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Arenas
{
    /// <summary>
    /// Master factory providing all 10 interactive arenas with custom hazard configurations and destructibles.
    /// </summary>
    public static class ArenaFactory
    {
        private static readonly Dictionary<ArenaId, ArenaDefinition> _definitions = new Dictionary<ArenaId, ArenaDefinition>();

        static ArenaFactory()
        {
            InitializeArenas();
        }

        public static IReadOnlyCollection<ArenaDefinition> GetAllArenas() => _definitions.Values;

        public static ArenaDefinition GetArena(ArenaId id)
        {
            _definitions.TryGetValue(id, out var def);
            return def;
        }

        private static void InitializeArenas()
        {
            // 1. Skyforge Temple
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.SkyforgeTemple,
                Name = "Skyforge Temple",
                Description = "A breathtaking marble temple suspended in the high clouds by ancient Ether currents.",
                KeyFeatures = "Breakable pillars, gust wind zones, precipice edges",
                ArenaBounds = new Vector3D(35.0f, 25.0f, 18.0f),
                GroundFriction = 0.85f,
                GravityModifier = 0.95f
            });

            // 2. Emberfall Crater
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.EmberfallCrater,
                Name = "Emberfall Crater",
                Description = "An active volcanic caldera surrounded by flowing magma rivers and basalt rock outcroppings.",
                KeyFeatures = "Lava geysers, thermal damage zones, collapsing rock ledges",
                ArenaBounds = new Vector3D(40.0f, 20.0f, 20.0f),
                GroundFriction = 0.82f,
                GravityModifier = 1.0f
            });

            // 3. Frostveil Sanctuary
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.FrostveilSanctuary,
                Name = "Frostveil Sanctuary",
                Description = "A sacred subterranean cavern encased in eternal glacial ice with low surface friction.",
                KeyFeatures = "Slippery ice patches, falling icicle traps, blizzard mist",
                ArenaBounds = new Vector3D(38.0f, 20.0f, 18.0f),
                GroundFriction = 0.45f, // Very slippery
                GravityModifier = 1.0f
            });

            // 4. Verdant Ruins
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.VerdantRuins,
                Name = "Verdant Ruins",
                Description = "Ancient overgrown monoliths intertwined with thick roots and pulsing wild nature Ether.",
                KeyFeatures = "Destructible ancient trees, entangling briar patches, pollen spores",
                ArenaBounds = new Vector3D(36.0f, 20.0f, 20.0f),
                GroundFriction = 0.88f,
                GravityModifier = 1.0f
            });

            // 5. Iron Harbor
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.IronHarbor,
                Name = "Iron Harbor",
                Description = "A sprawling industrial shipyard filled with steel cranes, shipping containers, and dynamos.",
                KeyFeatures = "Swinging heavy cargo cranes, destructible containers, live electrical generators",
                ArenaBounds = new Vector3D(42.0f, 22.0f, 20.0f),
                GroundFriction = 0.85f,
                GravityModifier = 1.0f
            });

            // 6. Rift Observatory
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.RiftObservatory,
                Name = "Rift Observatory",
                Description = "A shattered astral observatory orbiting near a tear in the fabric of space-time.",
                KeyFeatures = "Low gravity zones, spatial teleport rifts, cosmic wave pulses",
                ArenaBounds = new Vector3D(45.0f, 30.0f, 22.0f),
                GroundFriction = 0.80f,
                GravityModifier = 0.65f // Low gravity floating jumps
            });

            // 7. Sunken Citadel
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.SunkenCitadel,
                Name = "Sunken Citadel",
                Description = "An ancient flooded fortress submerged in shallow coastal tides that rise dynamically.",
                KeyFeatures = "Dynamic water channels, tidal wave surges, waterborne movement drag",
                ArenaBounds = new Vector3D(40.0f, 20.0f, 20.0f),
                GroundFriction = 0.70f,
                GravityModifier = 1.0f
            });

            // 8. Grave Cathedral
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.GraveCathedral,
                Name = "Grave Cathedral",
                Description = "A gothic mausoleum steeped in spectral shadows and cursed tomb monuments.",
                KeyFeatures = "Shadow mist zones, decaying floor traps, spectral resonance conduits",
                ArenaBounds = new Vector3D(38.0f, 24.0f, 18.0f),
                GroundFriction = 0.85f,
                GravityModifier = 1.0f
            });

            // 9. Astral Garden
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.AstralGarden,
                Name = "Astral Garden",
                Description = "A luminous floating sanctum populated by crystalline celestial flowers and orbiting star rings.",
                KeyFeatures = "Prismatic gravity wells, celestial orbit platforms, ambient Ether surges",
                ArenaBounds = new Vector3D(44.0f, 28.0f, 22.0f),
                GroundFriction = 0.85f,
                GravityModifier = 0.80f,
                AmbientEtherRegenBoost = 1.5f
            });

            // 10. Soulforge Coliseum
            RegisterArena(new ArenaDefinition
            {
                Id = ArenaId.SoulforgeColiseum,
                Name = "Soulforge Coliseum",
                Description = "The legendary grand arena where the First Souls forged reality itself. The ultimate proving ground.",
                KeyFeatures = "Dynamic shifting arena floor rings, environmental Ether pillars, roar of the spirit crowd",
                ArenaBounds = new Vector3D(50.0f, 25.0f, 25.0f),
                GroundFriction = 0.90f,
                GravityModifier = 1.0f,
                AmbientEtherRegenBoost = 2.0f
            });
        }

        private static void RegisterArena(ArenaDefinition def)
        {
            _definitions[def.Id] = def;
        }

        public static ArenaController CreateArenaInstance(ArenaId id)
        {
            var def = GetArena(id);
            if (def == null)
            {
                throw new ArgumentException($"Arena '{id}' not found.");
            }

            var controller = new ArenaController(def);

            // Add default destructibles and hazards according to arena theme
            switch (id)
            {
                case ArenaId.SkyforgeTemple:
                    controller.AddDestructible(new DestructibleObject { ObjectId = "pillar_west", Position = new Vector3D(-12.0f, 0, 0), Health = 120 });
                    controller.AddDestructible(new DestructibleObject { ObjectId = "pillar_east", Position = new Vector3D(12.0f, 0, 0), Health = 120 });
                    break;

                case ArenaId.EmberfallCrater:
                    controller.AddHazard(new HazardZone { HazardId = "magma_left", Center = new Vector3D(-16.0f, 0, 0), Radius = 5.0f, DamagePerSecond = 25.0f, InflictedStatus = StatusEffectType.Burn, StatusDuration = 3.0f });
                    controller.AddHazard(new HazardZone { HazardId = "magma_right", Center = new Vector3D(16.0f, 0, 0), Radius = 5.0f, DamagePerSecond = 25.0f, InflictedStatus = StatusEffectType.Burn, StatusDuration = 3.0f });
                    break;

                case ArenaId.FrostveilSanctuary:
                    controller.AddHazard(new HazardZone { HazardId = "frost_center", Center = new Vector3D(0, 0, 0), Radius = 6.0f, DamagePerSecond = 10.0f, InflictedStatus = StatusEffectType.Slow, StatusDuration = 2.0f });
                    break;

                case ArenaId.IronHarbor:
                    controller.AddDestructible(new DestructibleObject { ObjectId = "crate_stack_1", Position = new Vector3D(-10.0f, 0, 0), Health = 100 });
                    controller.AddDestructible(new DestructibleObject { ObjectId = "crate_stack_2", Position = new Vector3D(10.0f, 0, 0), Health = 100 });
                    break;
            }

            return controller;
        }
    }
}
