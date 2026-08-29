using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "ZaynRheo_Hurt_Head" : "ZaynRheo_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "ZaynRheo_Hurt_Heavy";
                case HitReactionType.Crumple: return "ZaynRheo_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "ZaynRheo_Launch_Airborne";
                default: return "ZaynRheo_Hurt_Gut";
            }
        }
    }
}
