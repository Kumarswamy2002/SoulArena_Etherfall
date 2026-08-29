using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for SunkenCitadel.
    /// Mood: Oceanic Deep Teal | Exposure: 0.9 | Light Source: Bioluminescence
    /// </summary>
    public class SunkenCitadelAtmosphereProfile
    {
        public string PaletteName { get; } = "Oceanic Deep Teal";
        public float ExposureMultiplier { get; set; } = 0.9f;
        public string ActiveLightingScheme { get; set; } = "Bioluminescence";
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
