using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Arenas.Implementations
{
    /// <summary>
    /// Interactive Arena Controller: Rift Observatory
    /// Key Features: Floating structure, gravity zones, teleport gates
    /// Surface Friction: 0.8 | Gravity Modifier: 0.65g
    /// </summary>
    public class RiftObservatoryArena : ArenaController
    {
        public float StageHazardIntensity { get; private set; } = 1.0f;
        public int ActiveWeatherCycle { get; private set; } = 0;
        public bool IsBoundaryCollapsed { get; private set; } = false;
        public float AmbientEtherPulseTimer { get; private set; } = 0.0f;

        public event Action<string, float> OnEnvironmentalHazardAlert;
        public event Action<int> OnWeatherCycleAdvanced;

        public RiftObservatoryArena(ArenaDefinition definition) : base(definition)
        {
            SetupRiftObservatoryDestructibles();
            SetupRiftObservatoryHazards();
        }

        private void SetupRiftObservatoryDestructibles()
        {
            Destructibles.Clear();
            AddDestructible(new DestructibleObject
            {
                ObjectId = "riftobservatory_destructible_west",
                Position = new Vector3D(-14.0f, 0.0f, 0.0f),
                Health = 150.0f,
                MaxHealth = 150.0f,
                Radius = 1.5f
            });

            AddDestructible(new DestructibleObject
            {
                ObjectId = "riftobservatory_destructible_east",
                Position = new Vector3D(14.0f, 0.0f, 0.0f),
                Health = 150.0f,
                MaxHealth = 150.0f,
                Radius = 1.5f
            });
        }

        private void SetupRiftObservatoryHazards()
        {
            Hazards.Clear();
            AddHazard(new HazardZone
            {
                HazardId = "riftobservatory_zone_alpha",
                Center = new Vector3D(-18.0f, 0.0f, 0.0f),
                Radius = 5.0f,
                DamagePerSecond = 20.0f,
                InflictedStatus = StatusEffectType.None,
                StatusDuration = 2.0f,
                TickInterval = 0.5f,
                IsActive = true
            });

            AddHazard(new HazardZone
            {
                HazardId = "riftobservatory_zone_beta",
                Center = new Vector3D(18.0f, 0.0f, 0.0f),
                Radius = 5.0f,
                DamagePerSecond = 20.0f,
                InflictedStatus = StatusEffectType.None,
                StatusDuration = 2.0f,
                TickInterval = 0.5f,
                IsActive = true
            });
        }

        public virtual void TriggerStageHazardSurge(float intensityMultiplier)
        {
            StageHazardIntensity = intensityMultiplier;
            foreach (var hazard in Hazards)
            {
                hazard.DamagePerSecond = 20.0f * intensityMultiplier;
            }
            OnEnvironmentalHazardAlert?.Invoke("Rift Observatory Hazard Surge Triggered!", StageHazardIntensity);
        }

        public virtual void AdvanceWeatherCycle()
        {
            ActiveWeatherCycle = (ActiveWeatherCycle + 1) % 4;
            OnWeatherCycleAdvanced?.Invoke(ActiveWeatherCycle);
        }

        public virtual void TriggerBoundaryCollapse()
        {
            IsBoundaryCollapsed = true;
            Definition.ArenaBounds = new Vector3D(Definition.ArenaBounds.X * 0.75f, Definition.ArenaBounds.Y, Definition.ArenaBounds.Z * 0.75f);
            OnEnvironmentalHazardAlert?.Invoke("Rift Observatory Outer Boundary Collapsed!", 2.0f);
        }

        public virtual void ProcessFighterEnvironmentalInteractions(FighterBase fighter, float deltaTime)
        {
            if (fighter == null || fighter.IsDead) return;

            // Check hazard zones
            foreach (var hazard in Hazards)
            {
                if (hazard.IsInside(fighter.Position))
                {
                    if (hazard.TickTimer >= hazard.TickInterval)
                    {
                        hazard.TickTimer = 0.0f;
                        float dmg = hazard.DamagePerSecond * hazard.TickInterval;
                        fighter.TakeDirectDamage(dmg, "Rift Observatory_Hazard");
                        if (hazard.InflictedStatus != StatusEffectType.None)
                        {
                            fighter.Status.ApplyStatus(hazard.InflictedStatus, hazard.StatusDuration, 15.0f, 0);
                        }
                    }
                }
            }

            // Apply surface friction modifier
            fighter.Velocity = new Vector3D(fighter.Velocity.X * Definition.GroundFriction, fighter.Velocity.Y, fighter.Velocity.Z * Definition.GroundFriction);
        }
    }
}
