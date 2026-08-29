using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "ElaraSol_Hurt_Head" : "ElaraSol_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "ElaraSol_Hurt_Heavy";
                case HitReactionType.Crumple: return "ElaraSol_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "ElaraSol_Launch_Airborne";
                default: return "ElaraSol_Hurt_Gut";
            }
        }
    }
}
