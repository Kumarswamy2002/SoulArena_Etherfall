using System;
using SoulArena.Core;

namespace SoulArena.VFX.Emitters
{
    /// <summary>
    /// Elemental VFX Emitter & Particle Controller for Elara Sol (Dawn Saint).
    /// Element: Radiance
    /// </summary>
    public class ElaraSolVFXEmitter
    {
        public string ElementTheme { get; set; } = "Radiance";
        public bool IsEmittingAura { get; private set; } = false;
        public float ParticleDensity { get; set; } = 1.0f;

        public event Action<string, Vector3D> OnParticleSpawned;

        public void EmitHitSpark(Vector3D position, bool isCritical)
        {
            string vfxId = isCritical ? "radiance_crit_spark" : "radiance_normal_spark";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void EmitSpecialEffect(int abilityIndex, Vector3D position)
        {
            string vfxId = "elara_sol_ability_" + abilityIndex + "_burst";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void SetAwakeningAura(bool active)
        {
            IsEmittingAura = active;
        }
    }
}
