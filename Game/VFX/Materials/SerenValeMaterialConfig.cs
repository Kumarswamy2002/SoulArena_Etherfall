using System;
using SoulArena.Core;

namespace SoulArena.VFX.Materials
{
    /// <summary>
    /// Shader Material Properties & Elemental Tinting for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeMaterialConfig
    {
        public string ElementName { get; } = "Frost";
        public Vector3D PrimaryTint { get; set; } = new Vector3D(1.0f, 0.8f, 0.2f);
        public Vector3D EmissionColor { get; set; } = new Vector3D(0.8f, 0.5f, 0.1f);
        public float BloomIntensity { get; set; } = 2.5f;

        public void ApplyAwakeningAuraGlow()
        {
            BloomIntensity = 5.0f;
        }
    }
}
