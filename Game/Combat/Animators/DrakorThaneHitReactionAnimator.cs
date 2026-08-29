using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Drakor Thane (Iron Colossus).
    /// </summary>
    public class DrakorThaneHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "DrakorThane_Hurt_Head" : "DrakorThane_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "DrakorThane_Hurt_Heavy";
                case HitReactionType.Crumple: return "DrakorThane_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "DrakorThane_Launch_Airborne";
                default: return "DrakorThane_Hurt_Gut";
            }
        }
    }
}
