using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for GraveCathedral.
    /// Mood: Gothic Slate Shadow | Exposure: 0.7 | Light Source: Moonlight
    /// </summary>
    public class GraveCathedralAtmosphereProfile
    {
        public string PaletteName { get; } = "Gothic Slate Shadow";
        public float ExposureMultiplier { get; set; } = 0.7f;
        public string ActiveLightingScheme { get; set; } = "Moonlight";
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
