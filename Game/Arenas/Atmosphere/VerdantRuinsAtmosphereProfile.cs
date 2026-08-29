using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for VerdantRuins.
    /// Mood: Forest Emerald | Exposure: 1.0 | Light Source: Dappled Sun
    /// </summary>
    public class VerdantRuinsAtmosphereProfile
    {
        public string PaletteName { get; } = "Forest Emerald";
        public float ExposureMultiplier { get; set; } = 1.0f;
        public string ActiveLightingScheme { get; set; } = "Dappled Sun";
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
