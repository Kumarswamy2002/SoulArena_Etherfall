using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;
using SoulArena.Abilities;

namespace SoulArena.Characters
{
    /// <summary>
    /// Master repository defining all 20 original Soulforged fighters, their stats, move trees, special abilities, and lore.
    /// </summary>
    public static class FighterRoster
    {
        private static readonly Dictionary<string, FighterDefinition> _roster = new Dictionary<string, FighterDefinition>();

        static FighterRoster()
        {
            InitializeRoster();
        }

        public static IReadOnlyCollection<FighterDefinition> GetAllFighters() => _roster.Values;

        public static FighterDefinition GetFighter(string fighterId)
        {
            _roster.TryGetValue(fighterId, out var def);
            return def;
        }

        private static void InitializeRoster()
        {
            // 1. Kael Varyn
            RegisterFighter(new FighterDefinition
            {
                FighterId = "kael_varyn",
                Name = "Kael Varyn",
                Title = "Stormbound",
                Element = EtherElement.Storm,
                Role = FighterRole.Rushdown,
                WeaponType = "Twin Ether Blades",
                Backstory = "A tempestuous warrior from the Cloudspire Enclave who channels raw thunderstorm currents through dual energized blades.",
                BaseStats = new FighterStats { MaxHealth = 1000, AttackPower = 105, DefenseArmor = 20, MoveSpeed = 6.8f, DashSpeed = 15.5f, JumpForce = 13.0f, Weight = 1.0f, CriticalChance = 0.08f },
                PassiveAbilityName = "Gale Cadence",
                PassiveDescription = "Consecutive light attacks increase movement speed by 4% up to 20%.",
                UltimateName = "Tempest Overdrive",
                UltimateDescription = "Envelops the arena in an electrified storm vortex, slashing the target 18 times before detonating a thunderclap."
            });

            // 2. Ryka Voss
            RegisterFighter(new FighterDefinition
            {
                FighterId = "ryka_voss",
                Name = "Ryka Voss",
                Title = "Ember Wolf",
                Element = EtherElement.Ember,
                Role = FighterRole.AggressiveBruiser,
                WeaponType = "Chain Gauntlets",
                Backstory = "A ferocious gladiator who reforged heavy prison chains into blistering flame conduits, fighting with wolf-like savagery.",
                BaseStats = new FighterStats { MaxHealth = 1050, AttackPower = 110, DefenseArmor = 22, MoveSpeed = 6.2f, DashSpeed = 14.5f, JumpForce = 12.0f, Weight = 1.15f, CriticalChance = 0.06f },
                PassiveAbilityName = "Ignition Drive",
                PassiveDescription = "Dealing damage builds Burn potency; attacks against burning targets heal 5% of damage dealt.",
                UltimateName = "Infernal Pack Hunt",
                UltimateDescription = "Manifests ethereal ember wolves that pin the enemy while Ryka delivers a volcanic ground-shatter impact."
            });

            // 3. Seren Vale
            RegisterFighter(new FighterDefinition
            {
                FighterId = "seren_vale",
                Name = "Seren Vale",
                Title = "Frozen Blade",
                Element = EtherElement.Frost,
                Role = FighterRole.Control,
                WeaponType = "Crystal Katana",
                Backstory = "The stoic guardian of the Glacial Spire whose diamond-forged katana freezes the air into razor ice mirrors.",
                BaseStats = new FighterStats { MaxHealth = 950, AttackPower = 98, DefenseArmor = 25, MoveSpeed = 6.0f, DashSpeed = 13.8f, JumpForce = 11.5f, Weight = 0.95f, CriticalChance = 0.07f },
                PassiveAbilityName = "Absolute Zero",
                PassiveDescription = "Cold attacks slow enemy recovery frames by 15% and build towards Freeze stun.",
                UltimateName = "Glacial Domain Shatter",
                UltimateDescription = "Traps the foe in a gigantic frost lotus and performs a single dimensional sword draw that shatters the crystal."
            });

            // 4. Zayn Rheo
            RegisterFighter(new FighterDefinition
            {
                FighterId = "zayn_rheo",
                Name = "Zayn Rheo",
                Title = "Lightning Phantom",
                Element = EtherElement.Volt,
                Role = FighterRole.SpeedAssassin,
                WeaponType = "Twin Daggers",
                Backstory = "An elusive rogue who moves faster than light, leaving afterimages that shock opponents who attempt to counterattack.",
                BaseStats = new FighterStats { MaxHealth = 900, AttackPower = 115, DefenseArmor = 15, MoveSpeed = 7.5f, DashSpeed = 18.0f, JumpForce = 14.0f, Weight = 0.85f, CriticalChance = 0.12f },
                PassiveAbilityName = "Static Afterimage",
                PassiveDescription = "Perfect dodges leave behind an electrical decoy that shocks the attacker for 0.5s.",
                UltimateName = "Phantom Volt Flash",
                UltimateDescription = "Teleports through the opponent 20 times at lightning velocity, culminating in a thunderous cross-cleave."
            });

            // 5. Drakor Thane
            RegisterFighter(new FighterDefinition
            {
                FighterId = "drakor_thane",
                Name = "Drakor Thane",
                Title = "Iron Colossus",
                Element = EtherElement.Stone,
                Role = FighterRole.Tank,
                WeaponType = "Massive Hammer",
                Backstory = "An armored mountain of a warrior imbued with seismic stone energy, capable of shattering arena foundations.",
                BaseStats = new FighterStats { MaxHealth = 1300, AttackPower = 120, DefenseArmor = 45, MoveSpeed = 4.8f, DashSpeed = 11.0f, JumpForce = 9.5f, Weight = 1.6f, CriticalChance = 0.04f },
                PassiveAbilityName = "Unshakable Bulwark",
                PassiveDescription = "Possesses Super Armor during heavy attack startups, reducing incoming damage by 40%.",
                UltimateName = "Tectonic Cataclysm",
                UltimateDescription = "Slams the colossal hammer into the earth, raising jagged stone spires that impale and crush the opponent."
            });

            // 6. Vexa Noir
            RegisterFighter(new FighterDefinition
            {
                FighterId = "vexa_noir",
                Name = "Vexa Noir",
                Title = "Void Walker",
                Element = EtherElement.Void,
                Role = FighterRole.TricksterAssassin,
                WeaponType = "Void Blades",
                Backstory = "A shadow assassin from the Null Realm who slips between spatial dimensions to strike from behind blind spots.",
                BaseStats = new FighterStats { MaxHealth = 920, AttackPower = 108, DefenseArmor = 18, MoveSpeed = 6.9f, DashSpeed = 16.0f, JumpForce = 13.0f, Weight = 0.90f, CriticalChance = 0.10f },
                PassiveAbilityName = "Phase Shift",
                PassiveDescription = "Dashing makes Vexa intangible for the first 8 frames.",
                UltimateName = "Null Horizon Execution",
                UltimateDescription = "Opens a black hole that pulls all enemies to the center, followed by a flurry of void dimension slashes."
            });

            // 7. Elara Sol
            RegisterFighter(new FighterDefinition
            {
                FighterId = "elara_sol",
                Name = "Elara Sol",
                Title = "Dawn Saint",
                Element = EtherElement.Radiance,
                Role = FighterRole.SupportFighter,
                WeaponType = "Light Spear",
                Backstory = "A solar paladin who uses solar spears to blind adversaries and purify corrupt Ether.",
                BaseStats = new FighterStats { MaxHealth = 1020, AttackPower = 100, DefenseArmor = 26, MoveSpeed = 6.1f, DashSpeed = 14.0f, JumpForce = 12.0f, Weight = 1.05f, CriticalChance = 0.05f },
                PassiveAbilityName = "Luminous Aegis",
                PassiveDescription = "Successful guards generate a radiant pulse that blinds nearby attackers.",
                UltimateName = "Judgment of the Solar Dawn",
                UltimateDescription = "Calls down a devastating pillar of pure sunlight that incinerates the target while granting invulnerability."
            });

            // 8. Torren Kai
            RegisterFighter(new FighterDefinition
            {
                FighterId = "torren_kai",
                Name = "Torren Kai",
                Title = "Wind Dancer",
                Element = EtherElement.Gale,
                Role = FighterRole.Mobility,
                WeaponType = "Twin Rings",
                Backstory = "An acrobatic wind monk wielding razor-sharp bladed chakrams with effortless aerial control.",
                BaseStats = new FighterStats { MaxHealth = 960, AttackPower = 102, DefenseArmor = 20, MoveSpeed = 7.0f, DashSpeed = 16.5f, JumpForce = 15.0f, Weight = 0.88f, CriticalChance = 0.07f },
                PassiveAbilityName = "Aerial Mastery",
                PassiveDescription = "Can perform a double air dash and suffers no damage scaling penalty on aerial juggles.",
                UltimateName = "Whirlwind Ascension",
                UltimateDescription = "Launches the foe into the high sky inside a massive cyclone, striking them repeatedly with spinning rings."
            });

            // 9. Raven Drake
            RegisterFighter(new FighterDefinition
            {
                FighterId = "raven_drake",
                Name = "Raven Drake",
                Title = "Blood Knight",
                Element = EtherElement.Crimson,
                Role = FighterRole.HighRiskReward,
                WeaponType = "Greatsword",
                Backstory = "A cursed swordsman who sacrifices his own vitality to fuel immense crimson blade sweeps.",
                BaseStats = new FighterStats { MaxHealth = 1100, AttackPower = 125, DefenseArmor = 20, MoveSpeed = 5.8f, DashSpeed = 13.5f, JumpForce = 11.0f, Weight = 1.25f, CriticalChance = 0.15f },
                PassiveAbilityName = "Blood Pact Frenzy",
                PassiveDescription = "Attack power increases up to +35% as current health drops below 50%.",
                UltimateName = "Crimson Eclipse Decapitation",
                UltimateDescription = "Unleashes an ocean of blood mist and performs an apocalyptic downward greatsword cleave."
            });

            // 10. Nyla Verd
            RegisterFighter(new FighterDefinition
            {
                FighterId = "nyla_verd",
                Name = "Nyla Verd",
                Title = "Wild Caller",
                Element = EtherElement.Nature,
                Role = FighterRole.Summoner,
                WeaponType = "Spirit Bow",
                Backstory = "A forest shaman who shoots enchanted nature arrows and summons spirit familiars to control the arena.",
                BaseStats = new FighterStats { MaxHealth = 940, AttackPower = 95, DefenseArmor = 19, MoveSpeed = 6.4f, DashSpeed = 14.8f, JumpForce = 12.5f, Weight = 0.92f, CriticalChance = 0.08f },
                PassiveAbilityName = "Entangling Briars",
                PassiveDescription = "Arrow hits apply Root for 1 second on a 10s internal cooldown.",
                UltimateName = "Wrath of the Primeval Beast",
                UltimateDescription = "Summons a colossal spirit stag that tramples the battlefield in a stampede of nature energy."
            });

            // 11. Orin Veil
            RegisterFighter(new FighterDefinition
            {
                FighterId = "orin_veil",
                Name = "Orin Veil",
                Title = "Mind Weaver",
                Element = EtherElement.Psionic,
                Role = FighterRole.Control,
                WeaponType = "Ether Orbs",
                Backstory = "A telekinetic scholar controlling orbiting psychic spheres that disrupt opponent minds and reverse controls.",
                BaseStats = new FighterStats { MaxHealth = 930, AttackPower = 104, DefenseArmor = 21, MoveSpeed = 6.0f, DashSpeed = 13.5f, JumpForce = 12.0f, Weight = 0.95f, CriticalChance = 0.06f },
                PassiveAbilityName = "Psionic Field",
                PassiveDescription = "Orbiting spheres automatically intercept and neutralize 1 projectile every 8 seconds.",
                UltimateName = "Synaptic Collapse",
                UltimateDescription = "Envelops the enemy in a telekinetic stasis sphere, compressing it until psychic shockwaves erupt."
            });

            // 12. Solan Ark
            RegisterFighter(new FighterDefinition
            {
                FighterId = "solan_ark",
                Name = "Solan Ark",
                Title = "Sunforged",
                Element = EtherElement.Solar,
                Role = FighterRole.PowerFighter,
                WeaponType = "Ether Fists",
                Backstory = "A martial arts master whose bare fists glow with the internal heat of a miniature nuclear sun.",
                BaseStats = new FighterStats { MaxHealth = 1080, AttackPower = 118, DefenseArmor = 24, MoveSpeed = 6.3f, DashSpeed = 15.0f, JumpForce = 12.5f, Weight = 1.10f, CriticalChance = 0.07f },
                PassiveAbilityName = "Solar Flare Impact",
                PassiveDescription = "Every 4th hit triggers an explosive blast that inflicts Burn and knocks the target back.",
                UltimateName = "Supernova Barrage",
                UltimateDescription = "Channels solar plasma into a rapid hundred-fist barrage finished with an earth-shattering uppercut."
            });

            // 13. Mira Tide
            RegisterFighter(new FighterDefinition
            {
                FighterId = "mira_tide",
                Name = "Mira Tide",
                Title = "Tideblade",
                Element = EtherElement.Tidal,
                Role = FighterRole.Balanced,
                WeaponType = "Water Blades",
                Backstory = "A fluid duelist whose liquid swords shift seamlessly between defensive waves and piercing torrents.",
                BaseStats = new FighterStats { MaxHealth = 990, AttackPower = 103, DefenseArmor = 22, MoveSpeed = 6.5f, DashSpeed = 15.0f, JumpForce = 12.8f, Weight = 0.98f, CriticalChance = 0.06f },
                PassiveAbilityName = "Fluid Riposte",
                PassiveDescription = "Perfect guards immediately replenish 15 Ether and boost counterattack damage by 20%.",
                UltimateName = "Maelstrom Tsunami",
                UltimateDescription = "Creates a swirling whirlpool arena that drowns defenses and sweeps the enemy into a tidal vortex."
            });

            // 14. Kade Rourke
            RegisterFighter(new FighterDefinition
            {
                FighterId = "kade_rourke",
                Name = "Kade Rourke",
                Title = "Iron Marauder",
                Element = EtherElement.Metal,
                Role = FighterRole.Brawler,
                WeaponType = "Mechanical Gauntlets",
                Backstory = "A rugged mechanist outfitted with steam-pressured hydraulic gauntlets designed for bone-crushing brawls.",
                BaseStats = new FighterStats { MaxHealth = 1150, AttackPower = 112, DefenseArmor = 30, MoveSpeed = 5.7f, DashSpeed = 13.8f, JumpForce = 11.2f, Weight = 1.30f, CriticalChance = 0.05f },
                PassiveAbilityName = "Hydraulic Pressure",
                PassiveDescription = "Blocking hits builds steam pressure; release it for a devastating unblockable counter-slam.",
                UltimateName = "Piston Overdrive Catastrophe",
                UltimateDescription = "Grabs the enemy, fires continuous explosive piston charges point-blank, and piledrives them into the ground."
            });

            // 15. Aeris Quin
            RegisterFighter(new FighterDefinition
            {
                FighterId = "aeris_quin",
                Name = "Aeris Quin",
                Title = "Star Weaver",
                Element = EtherElement.Astral,
                Role = FighterRole.Ranged,
                WeaponType = "Ether Staff",
                Backstory = "An astronomer mystic who weaves cosmic constellations into falling star projectiles and gravitational traps.",
                BaseStats = new FighterStats { MaxHealth = 910, AttackPower = 106, DefenseArmor = 18, MoveSpeed = 6.1f, DashSpeed = 13.5f, JumpForce = 12.2f, Weight = 0.90f, CriticalChance = 0.09f },
                PassiveAbilityName = "Starlight Shimmer",
                PassiveDescription = "Standing still for 1.5 seconds grants a starlight shield absorbing up to 100 damage.",
                UltimateName = "Astral Convergence",
                UltimateDescription = "Draws the zodiac constellations across the sky, bombarding the arena with a catastrophic meteor shower."
            });

            // 16. Rokan Fen
            RegisterFighter(new FighterDefinition
            {
                FighterId = "rokan_fen",
                Name = "Rokan Fen",
                Title = "Beast Soul",
                Element = EtherElement.Beast,
                Role = FighterRole.CloseCombat,
                WeaponType = "Clawed Gauntlets",
                Backstory = "A feral warrior who fuses his spirit with ancient apex predators to tear through opponent defenses.",
                BaseStats = new FighterStats { MaxHealth = 1040, AttackPower = 114, DefenseArmor = 21, MoveSpeed = 7.1f, DashSpeed = 16.8f, JumpForce = 13.5f, Weight = 1.02f, CriticalChance = 0.11f },
                PassiveAbilityName = "Predator Instinct",
                PassiveDescription = "Gain +15% movement speed and +10% damage when the target is below 30% health.",
                UltimateName = "Primal Apex Rend",
                UltimateDescription = "Transforms into a roaring beast avatar, pouncing and ravaging the enemy before a sonic roar finish."
            });

            // 17. Nox Arden
            RegisterFighter(new FighterDefinition
            {
                FighterId = "nox_arden",
                Name = "Nox Arden",
                Title = "Riftborn",
                Element = EtherElement.Rift,
                Role = FighterRole.SpaceManipulator,
                WeaponType = "Rift Scythe",
                Backstory = "A dark sorcerer wielding a spatial scythe that rips open tears in reality, swapping positions and cutting through space.",
                BaseStats = new FighterStats { MaxHealth = 970, AttackPower = 109, DefenseArmor = 20, MoveSpeed = 6.3f, DashSpeed = 14.5f, JumpForce = 12.0f, Weight = 1.0f, CriticalChance = 0.08f },
                PassiveAbilityName = "Dimensional Rupture",
                PassiveDescription = "Heavy attacks create dimensional tears that explode when struck by abilities.",
                UltimateName = "Event Horizon Reaper",
                UltimateDescription = "Slices open a massive reality rift, trapping the target in a black vortex and severing space itself."
            });

            // 18. Yuna Rei
            RegisterFighter(new FighterDefinition
            {
                FighterId = "yuna_rei",
                Name = "Yuna Rei",
                Title = "Spirit Dancer",
                Element = EtherElement.Spirit,
                Role = FighterRole.TechnicalFighter,
                WeaponType = "Ribbon Blades",
                Backstory = "A shrine maiden who blends graceful sacred dance ribbons with razor-sharp spiritual edge strikes.",
                BaseStats = new FighterStats { MaxHealth = 960, AttackPower = 101, DefenseArmor = 22, MoveSpeed = 6.7f, DashSpeed = 15.5f, JumpForce = 13.2f, Weight = 0.88f, CriticalChance = 0.07f },
                PassiveAbilityName = "Spiritual Flow",
                PassiveDescription = "Executing complete combo chains refunds 20% of the Ether spent during the chain.",
                UltimateName = "Dance of the Thousand Spirits",
                UltimateDescription = "Spins in an ethereal blossom vortex of spectral ribbons that shred defenses and banish negative statuses."
            });

            // 19. Morvan Kreel
            RegisterFighter(new FighterDefinition
            {
                FighterId = "morvan_kreel",
                Name = "Morvan Kreel",
                Title = "Grave King",
                Element = EtherElement.Death,
                Role = FighterRole.SummonerControl,
                WeaponType = "Soul Staff",
                Backstory = "The necromantic sovereign of the Silent Necropolis who drains Ether from foes to summon spectral legionnaires.",
                BaseStats = new FighterStats { MaxHealth = 1010, AttackPower = 107, DefenseArmor = 23, MoveSpeed = 5.9f, DashSpeed = 13.2f, JumpForce = 11.0f, Weight = 1.08f, CriticalChance = 0.06f },
                PassiveAbilityName = "Soul Harvester",
                PassiveDescription = "Every successful hit drains 2 Ether from the opponent and transfers it to Morvan.",
                UltimateName = "Army of the Damned",
                UltimateDescription = "Summons skeletal hands from the underworld to drag the opponent down while Morvan reaps their soul."
            });

            // 20. Auren Zeth
            RegisterFighter(new FighterDefinition
            {
                FighterId = "auren_zeth",
                Name = "Auren Zeth",
                Title = "First Soul",
                Element = EtherElement.PrimeEther,
                Role = FighterRole.BossAdvanced,
                WeaponType = "Ether Greatblade",
                Backstory = "The primordial entity who first forged Ether itself, wielding mastery over all elements and reality-shaking strikes.",
                BaseStats = new FighterStats { MaxHealth = 1200, AttackPower = 130, DefenseArmor = 35, MoveSpeed = 6.6f, DashSpeed = 16.0f, JumpForce = 13.0f, Weight = 1.20f, CriticalChance = 0.10f },
                PassiveAbilityName = "Primordial Origin",
                PassiveDescription = "Immune to Silence and Ether Drain; recovers 5% Resonance every 3 seconds.",
                UltimateName = "Etherfall: Genesis & Extinction",
                UltimateDescription = "Channels the pure white primeval Ether flame to wipe clean the battlefield with a celestial supernova."
            });
        }

        private static void RegisterFighter(FighterDefinition def)
        {
            _roster[def.FighterId] = def;
        }

        public static FighterBase CreateFighterInstance(int runtimeId, string fighterId)
        {
            var def = GetFighter(fighterId);
            if (def == null)
            {
                throw new ArgumentException($"Fighter '{fighterId}' does not exist in the roster.");
            }

            var fighter = new FighterBase(runtimeId, def);
            SetupFighterMovesAndAbilities(fighter);
            return fighter;
        }

        private static void SetupFighterMovesAndAbilities(FighterBase fighter)
        {
            string id = fighter.Definition.FighterId;

            // 1. Basic Attack Chain: Light 1 -> Light 2 -> Light 3
            var l1 = new ComboMoveData
            {
                MoveId = $"{id}_light1",
                AnimationStateName = "Attack_Light1",
                AttackType = AttackType.Light,
                Property = AttackProperty.High,
                StartupFrames = 4,
                ActiveFrames = 3,
                RecoveryFrames = 8,
                CancelWindowStartFrame = 5,
                CancelWindowEndFrame = 12,
                AllowedCancelType = CancelWindowType.OnHitOnly,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = $"{id}_hb_l1",
                    OwnerFighterId = fighter.FighterId,
                    Radius = 0.7f,
                    BaseDamage = 25.0f,
                    GuardDamage = 10.0f,
                    HitstunSeconds = 0.30f,
                    BlockstunSeconds = 0.18f,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { $"{id}_light2", $"{id}_heavy" }
            };

            var l2 = new ComboMoveData
            {
                MoveId = $"{id}_light2",
                AnimationStateName = "Attack_Light2",
                AttackType = AttackType.Light,
                Property = AttackProperty.Mid,
                StartupFrames = 5,
                ActiveFrames = 3,
                RecoveryFrames = 9,
                CancelWindowStartFrame = 6,
                CancelWindowEndFrame = 14,
                AllowedCancelType = CancelWindowType.OnHitOnly,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = $"{id}_hb_l2",
                    OwnerFighterId = fighter.FighterId,
                    Radius = 0.75f,
                    BaseDamage = 35.0f,
                    GuardDamage = 12.0f,
                    HitstunSeconds = 0.35f,
                    BlockstunSeconds = 0.20f,
                    HitReaction = HitReactionType.LightStagger
                },
                FollowupMoveIds = new List<string> { $"{id}_light3", $"{id}_launcher", $"{id}_special1" }
            };

            var l3 = new ComboMoveData
            {
                MoveId = $"{id}_light3",
                AnimationStateName = "Attack_Light3",
                AttackType = AttackType.Light,
                Property = AttackProperty.Mid,
                StartupFrames = 6,
                ActiveFrames = 4,
                RecoveryFrames = 12,
                CancelWindowStartFrame = 8,
                CancelWindowEndFrame = 16,
                AllowedCancelType = CancelWindowType.SpecialCancelable,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = $"{id}_hb_l3",
                    OwnerFighterId = fighter.FighterId,
                    Radius = 0.85f,
                    BaseDamage = 45.0f,
                    GuardDamage = 15.0f,
                    HitstunSeconds = 0.40f,
                    BlockstunSeconds = 0.22f,
                    HitReaction = HitReactionType.HeavyStagger,
                    KnockbackTrajectory = new Vector3D(4.0f, 1.0f, 0.0f)
                },
                FollowupMoveIds = new List<string> { $"{id}_special1", $"{id}_special2", $"{id}_ultimate" }
            };

            // 2. Heavy Attack
            var heavy = new ComboMoveData
            {
                MoveId = $"{id}_heavy",
                AnimationStateName = "Attack_Heavy",
                AttackType = AttackType.Heavy,
                Property = AttackProperty.Mid,
                StartupFrames = 12,
                ActiveFrames = 5,
                RecoveryFrames = 18,
                CancelWindowStartFrame = 14,
                CancelWindowEndFrame = 22,
                AllowedCancelType = CancelWindowType.SpecialCancelable,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = $"{id}_hb_heavy",
                    OwnerFighterId = fighter.FighterId,
                    Radius = 1.1f,
                    BaseDamage = 75.0f,
                    GuardDamage = 35.0f,
                    HitstunSeconds = 0.50f,
                    BlockstunSeconds = 0.28f,
                    HitstopFrames = GameConstants.HITSTOP_HEAVY_FRAMES,
                    HitReaction = HitReactionType.Crumple,
                    KnockbackTrajectory = new Vector3D(6.0f, 2.0f, 0.0f),
                    WallSplatTrigger = true
                },
                FollowupMoveIds = new List<string> { $"{id}_special1", $"{id}_special2" }
            };

            // 3. Launcher Attack
            var launcher = new ComboMoveData
            {
                MoveId = $"{id}_launcher",
                AnimationStateName = "Attack_Launcher",
                AttackType = AttackType.Launcher,
                Property = AttackProperty.Low,
                StartupFrames = 9,
                ActiveFrames = 4,
                RecoveryFrames = 15,
                CancelWindowStartFrame = 11,
                CancelWindowEndFrame = 18,
                AllowedCancelType = CancelWindowType.JumpCancelable,
                EtherCost = 0,
                HitboxDefinition = new HitboxData
                {
                    HitboxId = $"{id}_hb_launcher",
                    OwnerFighterId = fighter.FighterId,
                    Radius = 0.9f,
                    BaseDamage = 55.0f,
                    GuardDamage = 18.0f,
                    HitstunSeconds = 0.60f,
                    BlockstunSeconds = 0.20f,
                    HitReaction = HitReactionType.LaunchUp,
                    KnockbackTrajectory = new Vector3D(1.0f, 9.5f, 0.0f)
                },
                FollowupMoveIds = new List<string> { $"{id}_air_strike" }
            };

            fighter.Moves.RegisterMove(l1);
            fighter.Moves.RegisterMove(l2);
            fighter.Moves.RegisterMove(l3);
            fighter.Moves.RegisterMove(heavy);
            fighter.Moves.RegisterMove(launcher);

            // Register Character Abilities (Special 1, Special 2, Special 3, Ultimate)
            fighter.Abilities.RegisterAbility(new AbilityData
            {
                AbilityId = $"{id}_special1",
                Name = $"{fighter.Definition.Title} Surge",
                Description = "Primary elemental technique unleashing a concentrated burst of Ether.",
                CastType = AbilityCastType.Instant,
                Element = fighter.Definition.Element,
                EtherCost = 20.0f,
                CooldownSeconds = 4.0f,
                StartupFrames = 8,
                ActiveFrames = 6,
                RecoveryFrames = 12,
                HitboxData = new HitboxData
                {
                    HitboxId = $"{id}_hb_sp1",
                    OwnerFighterId = fighter.FighterId,
                    BaseDamage = 60.0f,
                    GuardDamage = 25.0f,
                    HitstunSeconds = 0.45f,
                    AttackType = AttackType.Special1
                }
            });

            fighter.Abilities.RegisterAbility(new AbilityData
            {
                AbilityId = $"{id}_special2",
                Name = $"{fighter.Definition.Title} Blast",
                Description = "Secondary ranged projectile or area-of-effect elemental technique.",
                CastType = AbilityCastType.Projectile,
                Element = fighter.Definition.Element,
                EtherCost = 30.0f,
                CooldownSeconds = 7.0f,
                StartupFrames = 12,
                ActiveFrames = 4,
                RecoveryFrames = 16,
                ProjectileSpeed = 16.0f,
                ProjectileLifetime = 2.0f,
                HitboxData = new HitboxData
                {
                    HitboxId = $"{id}_hb_sp2",
                    OwnerFighterId = fighter.FighterId,
                    BaseDamage = 80.0f,
                    GuardDamage = 30.0f,
                    HitstunSeconds = 0.50f,
                    AttackType = AttackType.Special2
                }
            });

            fighter.Abilities.RegisterAbility(new AbilityData
            {
                AbilityId = $"{id}_special3",
                Name = $"{fighter.Definition.Title} Stance",
                Description = "Defensive counter stance or movement mobility dash.",
                CastType = AbilityCastType.DashStrike,
                Element = fighter.Definition.Element,
                EtherCost = 25.0f,
                CooldownSeconds = 6.0f,
                StartupFrames = 6,
                ActiveFrames = 8,
                RecoveryFrames = 10,
                HitboxData = new HitboxData
                {
                    HitboxId = $"{id}_hb_sp3",
                    OwnerFighterId = fighter.FighterId,
                    BaseDamage = 70.0f,
                    GuardDamage = 28.0f,
                    HitstunSeconds = 0.45f,
                    AttackType = AttackType.Special3
                }
            });

            fighter.Abilities.RegisterAbility(new AbilityData
            {
                AbilityId = $"{id}_ultimate",
                Name = fighter.Definition.UltimateName,
                Description = fighter.Definition.UltimateDescription,
                CastType = AbilityCastType.Instant,
                Element = fighter.Definition.Element,
                EtherCost = 30.0f,
                CooldownSeconds = 15.0f,
                StartupFrames = 18,
                ActiveFrames = 12,
                RecoveryFrames = 30,
                HitboxData = new HitboxData
                {
                    HitboxId = $"{id}_hb_ult",
                    OwnerFighterId = fighter.FighterId,
                    BaseDamage = 280.0f,
                    GuardDamage = 80.0f,
                    HitstunSeconds = 1.2f,
                    HitstopFrames = GameConstants.HITSTOP_ULTIMATE_FRAMES,
                    HitReaction = HitReactionType.HardKnockdown,
                    AttackType = AttackType.Ultimate
                }
            });
        }
    }
}
