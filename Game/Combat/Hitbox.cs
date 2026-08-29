using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Combat
{
    public class HitboxData
    {
        public string HitboxId;
        public int OwnerFighterId;
        public Vector3D RelativeOffset;
        public float Radius = 0.8f;
        public int ActiveStartFrame;
        public int ActiveEndFrame;

        // Damage & Properties
        public float BaseDamage = 50.0f;
        public float GuardDamage = 20.0f;
        public float HitstunSeconds = 0.35f;
        public float BlockstunSeconds = 0.20f;
        public int HitstopFrames = GameConstants.HITSTOP_DEFAULT_FRAMES;
        
        public AttackType AttackType = AttackType.Light;
        public AttackProperty Property = AttackProperty.Mid;
        public HitReactionType HitReaction = HitReactionType.LightStagger;
        public Vector3D KnockbackTrajectory = new Vector3D(2.0f, 0.0f, 0.0f);
        
        public StatusEffectType InflictedStatus = StatusEffectType.None;
        public float StatusDuration = 0.0f;
        public float StatusPotency = 0.0f;

        public bool CanBeParried = true;
        public bool ArmorPierce = false;
        public bool WallSplatTrigger = false;
        public bool GroundBounceTrigger = false;
    }

    public class Hitbox : IPoolable
    {
        public bool IsActive { get; set; }
        public HitboxData Data { get; private set; }
        public Vector3D WorldPosition { get; private set; }
        
        // Track targets already struck by this active hitbox during a single swing
        private readonly HashSet<int> _struckTargetIds = new HashSet<int>();

        public void Initialize(HitboxData data, Vector3D ownerWorldPosition, bool facingRight = true)
        {
            Data = data;
            float directionMultiplier = facingRight ? 1.0f : -1.0f;
            WorldPosition = ownerWorldPosition + new Vector3D(data.RelativeOffset.X * directionMultiplier, data.RelativeOffset.Y, data.RelativeOffset.Z);
            _struckTargetIds.Clear();
        }

        public void UpdatePosition(Vector3D ownerWorldPosition, bool facingRight = true)
        {
            if (Data == null) return;
            float directionMultiplier = facingRight ? 1.0f : -1.0f;
            WorldPosition = ownerWorldPosition + new Vector3D(Data.RelativeOffset.X * directionMultiplier, Data.RelativeOffset.Y, Data.RelativeOffset.Z);
        }

        public bool HasStruckTarget(int targetId)
        {
            return _struckTargetIds.Contains(targetId);
        }

        public void RegisterHit(int targetId)
        {
            _struckTargetIds.Add(targetId);
        }

        public void ResetHitHistory()
        {
            _struckTargetIds.Clear();
        }

        public void OnSpawn()
        {
            _struckTargetIds.Clear();
        }

        public void OnDespawn()
        {
            _struckTargetIds.Clear();
            Data = null;
        }
    }
}
