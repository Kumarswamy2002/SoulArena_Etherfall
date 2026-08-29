using System;
using SoulArena.Core;

namespace SoulArena.VFX.Emitters
{
    /// <summary>
    /// Elemental VFX Emitter & Particle Controller for Ryka Voss (Ember Wolf).
    /// Element: Ember
    /// </summary>
    public class RykaVossVFXEmitter
    {
        public string ElementTheme { get; set; } = "Ember";
        public bool IsEmittingAura { get; private set; } = false;
        public float ParticleDensity { get; set; } = 1.0f;

        public event Action<string, Vector3D> OnParticleSpawned;

        public void EmitHitSpark(Vector3D position, bool isCritical)
        {
            string vfxId = isCritical ? "ember_crit_spark" : "ember_normal_spark";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void EmitSpecialEffect(int abilityIndex, Vector3D position)
        {
            string vfxId = "ryka_voss_ability_" + abilityIndex + "_burst";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void SetAwakeningAura(bool active)
        {
            IsEmittingAura = active;
        }
    }
}
