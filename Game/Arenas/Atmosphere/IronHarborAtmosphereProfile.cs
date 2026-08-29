using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for IronHarbor.
    /// Mood: Industrial Amber | Exposure: 1.1 | Light Source: Floodlights
    /// </summary>
    public class IronHarborAtmosphereProfile
    {
        public string PaletteName { get; } = "Industrial Amber";
        public float ExposureMultiplier { get; set; } = 1.1f;
        public string ActiveLightingScheme { get; set; } = "Floodlights";
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
