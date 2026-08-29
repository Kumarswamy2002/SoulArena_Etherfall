using System;
using SoulArena.Core;

namespace SoulArena.Characters.Camera
{
    /// <summary>
    /// Cinematic Focus & Viewport Target Controller for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeCameraFocus
    {
        public Vector3D EyeLevelOffset { get; } = new Vector3D(0.0f, 1.60f, 0.0f);
        public Vector3D WeaponFocusOffset { get; } = new Vector3D(0.40f, 1.20f, 0.0f);
        public float FocalLengthBias { get; set; } = 1.0f;

        public Vector3D GetFocusPoint(Vector3D fighterPos, bool isWeaponAction)
        {
            return fighterPos + (isWeaponAction ? WeaponFocusOffset : EyeLevelOffset);
        }
    }
}
