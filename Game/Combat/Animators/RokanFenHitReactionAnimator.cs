using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "RokanFen_Hurt_Head" : "RokanFen_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "RokanFen_Hurt_Heavy";
                case HitReactionType.Crumple: return "RokanFen_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "RokanFen_Launch_Airborne";
                default: return "RokanFen_Hurt_Gut";
            }
        }
    }
}
