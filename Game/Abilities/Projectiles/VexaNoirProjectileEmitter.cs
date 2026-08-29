using System;
using SoulArena.Core;
using SoulArena.Abilities;

namespace SoulArena.Abilities.Projectiles
{
    /// <summary>
    /// Elemental Projectile Factory & Kinematics Runner for Vexa Noir (Void Walker).
    /// Element: Void
    /// </summary>
    public class VexaNoirProjectileEmitter
    {
        public string FighterId { get; } = "vexa_noir";
        public float ProjectileSpeed { get; set; } = 18.0f;
        public float ProjectileLifetime { get; set; } = 2.5f;
        public int ActiveProjectilesCount { get; private set; } = 0;

        public event Action<string, Vector3D, Vector3D> OnProjectileSpawned;

        public void SpawnProjectile(Vector3D origin, bool facingRight)
        {
            ActiveProjectilesCount++;
            float dir = facingRight ? 1.0f : -1.0f;
            Vector3D velocity = new Vector3D(dir * ProjectileSpeed, 0f, 0f);
            OnProjectileSpawned?.Invoke("vexa_noir_void_orb", origin, velocity);
        }
    }
}
