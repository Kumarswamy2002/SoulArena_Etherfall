using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for EmberfallCrater.
    /// Mood: Volcanic Crimson | Exposure: 1.5 | Light Source: Lava Glow
    /// </summary>
    public class EmberfallCraterAtmosphereProfile
    {
        public string PaletteName { get; } = "Volcanic Crimson";
        public float ExposureMultiplier { get; set; } = 1.5f;
        public string ActiveLightingScheme { get; set; } = "Lava Glow";
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
