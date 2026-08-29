using System;
using SoulArena.Core;

namespace SoulArena.VFX.Emitters
{
    /// <summary>
    /// Elemental VFX Emitter & Particle Controller for Aeris Quin (Star Weaver).
    /// Element: Astral
    /// </summary>
    public class AerisQuinVFXEmitter
    {
        public string ElementTheme { get; set; } = "Astral";
        public bool IsEmittingAura { get; private set; } = false;
        public float ParticleDensity { get; set; } = 1.0f;

        public event Action<string, Vector3D> OnParticleSpawned;

        public void EmitHitSpark(Vector3D position, bool isCritical)
        {
            string vfxId = isCritical ? "astral_crit_spark" : "astral_normal_spark";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void EmitSpecialEffect(int abilityIndex, Vector3D position)
        {
            string vfxId = "aeris_quin_ability_" + abilityIndex + "_burst";
            OnParticleSpawned?.Invoke(vfxId, position);
        }

        public void SetAwakeningAura(bool active)
        {
            IsEmittingAura = active;
        }
    }
}
