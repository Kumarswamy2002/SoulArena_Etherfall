using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Abilities
{
    public enum AbilityCastType
    {
        Instant,
        Channeled,
        Chargeable,
        Projectile,
        AreaOfEffect,
        DashStrike,
        GrabTakedown,
        BuffStance
    }

    [Serializable]
    public class AbilityData
    {
        public string AbilityId;
        public string Name;
        public string Description;
        public AbilityCastType CastType;
        public EtherElement Element;

        // Resource & Timings
        public float EtherCost = 25.0f;
        public float CooldownSeconds = 6.0f;
        public int StartupFrames = 12;
        public int ActiveFrames = 6;
        public int RecoveryFrames = 18;
        public float ChannelMaxDuration = 0.0f;

        // Hitbox & Damage
        public HitboxData HitboxData;
        public float ProjectileSpeed = 0.0f;
        public float ProjectileLifetime = 0.0f;
        public float AoERadius = 0.0f;

        // Status Effects
        public StatusEffectType StatusEffect = StatusEffectType.None;
        public float StatusDuration = 0.0f;
        public float StatusPotency = 0.0f;

        // Awakening Variation
        public bool HasAwakeningUpgrade = false;
        public float AwakeningDamageBoost = 1.30f;
    }

    public class Projectile : IPoolable
    {
        public bool IsActive { get; set; }
        public int OwnerFighterId { get; private set; }
        public Vector3D Position { get; private set; }
        public Vector3D Velocity { get; private set; }
        public float Radius { get; private set; }
        public float LifetimeRemaining { get; private set; }
        public HitboxData HitboxData { get; private set; }
        public int MaxPierces { get; private set; } = 1;
        public int CurrentPierces { get; private set; } = 0;

        public void Spawn(int ownerId, Vector3D spawnPos, Vector3D direction, float speed, float lifetime, HitboxData hitboxData, int maxPierces = 1)
        {
            OwnerFighterId = ownerId;
            Position = spawnPos;
            Velocity = direction.Normalized * speed;
            Radius = hitboxData != null ? hitboxData.Radius : 0.5f;
            LifetimeRemaining = lifetime;
            HitboxData = hitboxData;
            MaxPierces = maxPierces;
            CurrentPierces = 0;
            IsActive = true;
        }

        public void Update(float deltaTime)
        {
            if (!IsActive) return;

            Position += Velocity * deltaTime;
            LifetimeRemaining -= deltaTime;

            if (LifetimeRemaining <= 0.0f)
            {
                IsActive = false;
            }
        }

        public void OnSpawn() { }
        public void OnDespawn()
        {
            IsActive = false;
            HitboxData = null;
        }
    }
}
