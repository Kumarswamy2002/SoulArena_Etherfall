using System;
using SoulArena.Core;

namespace SoulArena.Combat.Anchors
{
    /// <summary>
    /// Visual FX Socket & Hit Spark Anchors for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenHitAnchor
    {
        public Vector3D ChestSocketOffset { get; } = new Vector3D(0f, 1.25f, 0.15f);
        public Vector3D WeaponTipSocketOffset { get; } = new Vector3D(0.6f, 1.10f, 0.40f);
        public Vector3D FeetSocketOffset { get; } = new Vector3D(0f, 0.05f, 0f);

        public Vector3D GetSocketWorldPosition(Vector3D rootPos, bool facingRight, string socketName)
        {
            float dir = facingRight ? 1.0f : -1.0f;
            Vector3D offset = socketName == "Weapon" ? WeaponTipSocketOffset : (socketName == "Feet" ? FeetSocketOffset : ChestSocketOffset);
            return rootPos + new Vector3D(offset.X * dir, offset.Y, offset.Z);
        }
    }
}
