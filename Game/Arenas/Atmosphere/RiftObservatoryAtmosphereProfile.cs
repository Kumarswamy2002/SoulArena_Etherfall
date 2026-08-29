using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Atmosphere
{
    /// <summary>
    /// Post-Processing, Volumetric Fog & Atmospheric Lighting Profile for RiftObservatory.
    /// Mood: Cosmic Violet | Exposure: 0.8 | Light Source: Starlight
    /// </summary>
    public class RiftObservatoryAtmosphereProfile
    {
        public string PaletteName { get; } = "Cosmic Violet";
        public float ExposureMultiplier { get; set; } = 0.8f;
        public string ActiveLightingScheme { get; set; } = "Starlight";
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
