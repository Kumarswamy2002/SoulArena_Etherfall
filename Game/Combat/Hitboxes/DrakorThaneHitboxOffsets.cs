using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Hitboxes
{
    /// <summary>
    /// Exact Spatial Offsets & Box Extents for Drakor Thane (Iron Colossus).
    /// </summary>
    public static class DrakorThaneHitboxOffsets
    {
        public static readonly Vector3D Light1Offset = new Vector3D(0.85f, 1.10f, 0.0f);
        public static readonly Vector3D Light2Offset = new Vector3D(0.95f, 1.05f, 0.0f);
        public static readonly Vector3D Light3Offset = new Vector3D(1.10f, 1.00f, 0.0f);
        public static readonly Vector3D HeavyOffset = new Vector3D(1.35f, 0.95f, 0.0f);
        public static readonly Vector3D LauncherOffset = new Vector3D(0.80f, 0.40f, 0.0f);
        public static readonly Vector3D AirOffset = new Vector3D(0.90f, 0.20f, 0.0f);

        public static Vector3D GetOffsetForMove(string moveKey)
        {
            switch (moveKey)
            {
                case "Light1": return Light1Offset;
                case "Light2": return Light2Offset;
                case "Light3": return Light3Offset;
                case "Heavy": return HeavyOffset;
                case "Launcher": return LauncherOffset;
                case "Air": return AirOffset;
                default: return Light1Offset;
            }
        }
    }
}
