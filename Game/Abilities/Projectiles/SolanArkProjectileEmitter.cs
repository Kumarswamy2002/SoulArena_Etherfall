using System;
using SoulArena.Core;
using SoulArena.Abilities;

namespace SoulArena.Abilities.Projectiles
{
    /// <summary>
    /// Elemental Projectile Factory & Kinematics Runner for Solan Ark (Sunforged).
    /// Element: Solar
    /// </summary>
    public class SolanArkProjectileEmitter
    {
        public string FighterId { get; } = "solan_ark";
        public float ProjectileSpeed { get; set; } = 18.0f;
        public float ProjectileLifetime { get; set; } = 2.5f;
        public int ActiveProjectilesCount { get; private set; } = 0;

        public event Action<string, Vector3D, Vector3D> OnProjectileSpawned;

        public void SpawnProjectile(Vector3D origin, bool facingRight)
        {
            ActiveProjectilesCount++;
            float dir = facingRight ? 1.0f : -1.0f;
            Vector3D velocity = new Vector3D(dir * ProjectileSpeed, 0f, 0f);
            OnProjectileSpawned?.Invoke("solan_ark_solar_orb", origin, velocity);
        }
    }
}
