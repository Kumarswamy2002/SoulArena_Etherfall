using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for FrostveilSanctuary.
    /// Mood: Glacial Cyan | Exposure: 0.9 | Light Source: Crystal Aurora
    /// </summary>
    public class FrostveilSanctuaryAtmosphereProfile
    {
        public string PaletteName { get; } = "Glacial Cyan";
        public float ExposureMultiplier { get; set; } = 0.9f;
        public string ActiveLightingScheme { get; set; } = "Crystal Aurora";
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
