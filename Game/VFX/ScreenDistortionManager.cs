using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.VFX
{
    /// <summary>
    /// ScreenDistortionManager: Radial blur, chromatic aberration, and screen shake impulse controller on Ultimates
    /// </summary>
    public class ScreenDistortionManager
    {
        public bool IsActive { get; set; } = true;
        public float MasterVolume { get; set; } = 1.0f;
        public int ActiveInstanceCount { get; private set; } = 0;

        public void Initialize()
        {
            ActiveInstanceCount = 0;
        }

        public void TriggerEffect(string effectId, Vector3D position, float intensity = 1.0f)
        {
            if (!IsActive) return;
            ActiveInstanceCount++;
        }

        public void Update(float deltaTime)
        {
            if (!IsActive) return;
        }
    }
}
