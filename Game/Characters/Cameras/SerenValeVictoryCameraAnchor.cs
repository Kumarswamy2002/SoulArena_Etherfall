using System;
using SoulArena.Core;

namespace SoulArena.Characters.Cameras
{
    /// <summary>
    /// Victory & Round Win Cinematic Camera Angle Anchor for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeVictoryCameraAnchor
    {
        public Vector3D CameraPositionOffset { get; set; } = new Vector3D(1.2f, 1.4f, 2.8f);
        public Vector3D LookAtOffset { get; set; } = new Vector3D(0f, 1.3f, 0f);
        public float FieldOfView { get; set; } = 45.0f;

        public (Vector3D camPos, Vector3D lookAt) GetCinematicTransform(Vector3D fighterPos, bool facingRight)
        {
            float dir = facingRight ? 1.0f : -1.0f;
            Vector3D p = fighterPos + new Vector3D(CameraPositionOffset.X * dir, CameraPositionOffset.Y, CameraPositionOffset.Z);
            Vector3D l = fighterPos + LookAtOffset;
            return (p, l);
        }
    }
}
