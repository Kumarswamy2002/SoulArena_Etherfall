using System;
using SoulArena.Core;

namespace SoulArena.VFX.Emitters
{
    /// <summary>
    /// Elemental VFX Emitter & Particle Controller for Kade Rourke (Iron Marauder).
    /// Element: Metal
    /// </summary>
    public class KadeRourkeVFXEmitter
    {
        public string ElementTheme { get; set; } = "Metal";
        public bool IsEmittingAura { get; private set; } = false;
        public float ParticleDensity { get; set; } = 1.0f;

        public event Action<string, Vector3D> OnParticleSpawned;

        public void EmitHitSpark(Vector3D position, bool isCritical)
        {
            string vfxId = isCritical ? "metal_crit_spark" : "metal_normal_spark";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void EmitSpecialEffect(int abilityIndex, Vector3D position)
        {
            string vfxId = "kade_rourke_ability_" + abilityIndex + "_burst";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void SetAwakeningAura(bool active)
        {
            IsEmittingAura = active;
        }
    }
}
