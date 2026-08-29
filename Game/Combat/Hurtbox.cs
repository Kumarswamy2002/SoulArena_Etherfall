using System;
using SoulArena.Core;

namespace SoulArena.Combat
{
    public enum BodyPart
    {
        Head,
        Torso,
        UpperLimbs,
        LowerLimbs,
        FullBody
    }

    public class Hurtbox
    {
        public int OwnerFighterId { get; set; }
        public BodyPart Region { get; set; } = BodyPart.Torso;
        public Vector3D RelativeOffset { get; set; } = new Vector3D(0, 1.0f, 0);
        public float Radius { get; set; } = 0.6f;
        public float Height { get; set; } = 1.8f; // For capsule hurtboxes

        public bool IsInvulnerable { get; set; } = false;
        public bool IsIntangible { get; set; } = false; // Cannot even be detected
        public float DamageMultiplier { get; set; } = 1.0f; // Headshot/Weak point multiplier

        public Vector3D GetWorldPosition(Vector3D ownerPosition, bool facingRight = true)
        {
            float dir = facingRight ? 1.0f : -1.0f;
            return ownerPosition + new Vector3D(RelativeOffset.X * dir, RelativeOffset.Y, RelativeOffset.Z);
        }

        public (Vector3D bottom, Vector3D top) GetCapsuleEndpoints(Vector3D ownerPosition, bool facingRight = true)
        {
            Vector3D center = GetWorldPosition(ownerPosition, facingRight);
            float halfHeight = Math.Max(0.0f, (Height * 0.5f) - Radius);
            Vector3D bottom = center - new Vector3D(0, halfHeight, 0);
            Vector3D top = center + new Vector3D(0, halfHeight, 0);
            return (bottom, top);
        }
    }
}
