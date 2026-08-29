using System;
using SoulArena.Core;

namespace SoulArena.VFX.Emitters
{
    /// <summary>
    /// Elemental VFX Emitter & Particle Controller for Torren Kai (Wind Dancer).
    /// Element: Gale
    /// </summary>
    public class TorrenKaiVFXEmitter
    {
        public string ElementTheme { get; set; } = "Gale";
        public bool IsEmittingAura { get; private set; } = false;
        public float ParticleDensity { get; set; } = 1.0f;

        public event Action<string, Vector3D> OnParticleSpawned;

        public void EmitHitSpark(Vector3D position, bool isCritical)
        {
            string vfxId = isCritical ? "gale_crit_spark" : "gale_normal_spark";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void EmitSpecialEffect(int abilityIndex, Vector3D position)
        {
            string vfxId = "torren_kai_ability_" + abilityIndex + "_burst";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void SetAwakeningAura(bool active)
        {
            IsEmittingAura = active;
        }
    }
}
