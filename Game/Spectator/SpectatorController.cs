using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Spectator
{
    /// <summary>
    /// Dynamic broadcast director camera calculating optimal viewport zoom, focal midpoints, and dramatic slow-motion framing.
    /// </summary>
    public class SpectatorDirectorCamera
    {
        public Vector3D CameraPosition { get; private set; }
        public Vector3D TargetLookAt { get; private set; }
        public float CurrentFOV { get; private set; } = 60.0f;

        public float MinDistance = 6.0f;
        public float MaxDistance = 14.0f;
        public float BaseHeight = 2.2f;
        public float DampingSpeed = 8.0f;

        public void UpdateCamera(float deltaTime, FighterBase p1, FighterBase p2, bool isHitstopOrUltimate)
        {
            if (p1 == null || p2 == null) return;

            // 1. Calculate midpoint between both fighters
            Vector3D midPoint = (p1.Position + p2.Position) * 0.5f;
            TargetLookAt = midPoint + new Vector3D(0, BaseHeight, 0);

            // 2. Calculate distance between fighters to drive dynamic camera depth
            float fighterDistance = (p1.Position - p2.Position).Magnitude;
            float desiredZ = -MathUtility.Clamp(fighterDistance * 1.1f + 4.0f, MinDistance, MaxDistance);

            // 3. Cinematic close-up on Ultimate / heavy hitstop
            if (isHitstopOrUltimate)
            {
                desiredZ *= 0.65f;
                CurrentFOV = MathUtility.Lerp(CurrentFOV, 48.0f, deltaTime * DampingSpeed * 2);
            }
            else
            {
                CurrentFOV = MathUtility.Lerp(CurrentFOV, 60.0f, deltaTime * DampingSpeed);
            }

            Vector3D desiredPosition = new Vector3D(midPoint.X, midPoint.Y + BaseHeight, desiredZ);
            CameraPosition = MathUtility.Lerp(CameraPosition, desiredPosition, deltaTime * DampingSpeed);
        }
    }
}
