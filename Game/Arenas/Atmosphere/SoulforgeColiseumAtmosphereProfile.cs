using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for SoulforgeColiseum.
    /// Mood: Primordial Solar Gold | Exposure: 1.6 | Light Source: Divine Core
    /// </summary>
    public class SoulforgeColiseumAtmosphereProfile
    {
        public string PaletteName { get; } = "Primordial Solar Gold";
        public float ExposureMultiplier { get; set; } = 1.6f;
        public string ActiveLightingScheme { get; set; } = "Divine Core";
        public float VolumetricFogDensity { get; set; } = 0.02f;

        public void ApplyPhaseShift(int stagePhase)
        {
            if (stagePhase == 2)
            {
                ExposureMultiplier *= 1.2f;
                VolumetricFogDensity *= 1.5f;
            }
            else if (stagePhase == 3)
            {
                ExposureMultiplier *= 1.4f;
                VolumetricFogDensity *= 2.0f;
            }
        }
    }
}
