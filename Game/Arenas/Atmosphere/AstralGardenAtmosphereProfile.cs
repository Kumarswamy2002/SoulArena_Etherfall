using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for AstralGarden.
    /// Mood: Prismatic Rainbow | Exposure: 1.4 | Light Source: Celestial Corona
    /// </summary>
    public class AstralGardenAtmosphereProfile
    {
        public string PaletteName { get; } = "Prismatic Rainbow";
        public float ExposureMultiplier { get; set; } = 1.4f;
        public string ActiveLightingScheme { get; set; } = "Celestial Corona";
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
