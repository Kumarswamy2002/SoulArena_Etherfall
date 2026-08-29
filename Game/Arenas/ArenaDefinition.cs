using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Arenas
{
    [Serializable]
    public class ArenaDefinition
    {
        public ArenaId Id;
        public string Name;
        public string Description;
        public string KeyFeatures;
        public Vector3D ArenaBounds = new Vector3D(40.0f, 20.0f, 20.0f);
        public Vector3D Player1Spawn = new Vector3D(-8.0f, 0.0f, 0.0f);
        public Vector3D Player2Spawn = new Vector3D(8.0f, 0.0f, 0.0f);
        
        public float GravityModifier = 1.0f;
        public float GroundFriction = 0.85f;
        public bool HasRingOutBoundaries = false;
        public float AmbientEtherRegenBoost = 0.0f;
    }

    public class DestructibleObject
    {
        public string ObjectId;
        public Vector3D Position;
        public float Health = 150.0f;
        public float MaxHealth = 150.0f;
        public bool IsDestroyed => Health <= 0.0f;
        public float Radius = 1.2f;

        public event Action<string, Vector3D> OnObjectDestroyed;

        public void TakeDamage(float damage)
        {
            if (IsDestroyed) return;
            Health -= damage;
            if (Health <= 0.0f)
            {
                Health = 0.0f;
                OnObjectDestroyed?.Invoke(ObjectId, Position);
            }
        }
    }

    public class HazardZone
    {
        public string HazardId;
        public Vector3D Center;
        public float Radius = 4.0f;
        public float DamagePerSecond = 20.0f;
        public StatusEffectType InflictedStatus = StatusEffectType.None;
        public float StatusDuration = 2.0f;
        public float TickInterval = 0.5f;
        public float TickTimer = 0.0f;
        public bool IsActive = true;

        public bool IsInside(Vector3D targetPos)
        {
            if (!IsActive) return false;
            return (targetPos - Center).SqrMagnitude <= (Radius * Radius);
        }
    }

    public class ArenaController
    {
        public ArenaDefinition Definition { get; private set; }
        public List<DestructibleObject> Destructibles { get; private set; } = new List<DestructibleObject>();
        public List<HazardZone> Hazards { get; private set; } = new List<HazardZone>();
        public float DynamicEventTimer { get; private set; } = 0.0f;
        public int DynamicPhase { get; private set; } = 1;

        public event Action<int, string> OnDynamicStageEvent;

        public ArenaController(ArenaDefinition definition)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
        }

        public void AddDestructible(DestructibleObject obj)
        {
            Destructibles.Add(obj);
        }

        public void AddHazard(HazardZone hazard)
        {
            Hazards.Add(hazard);
        }

        public void Update(float deltaTime)
        {
            DynamicEventTimer += deltaTime;

            // Trigger dynamic stage transformations at 30s and 60s
            if (DynamicPhase == 1 && DynamicEventTimer >= 30.0f)
            {
                DynamicPhase = 2;
                OnDynamicStageEvent?.Invoke(DynamicPhase, $"{Definition.Name} Phase 2: Environmental Hazard Surge");
            }
            else if (DynamicPhase == 2 && DynamicEventTimer >= 60.0f)
            {
                DynamicPhase = 3;
                OnDynamicStageEvent?.Invoke(DynamicPhase, $"{Definition.Name} Phase 3: Stage Boundary Collapse");
            }

            // Update hazards
            foreach (var hazard in Hazards)
            {
                hazard.TickTimer += deltaTime;
            }
        }
    }
}
