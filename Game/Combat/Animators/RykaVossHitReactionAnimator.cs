using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "RykaVoss_Hurt_Head" : "RykaVoss_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "RykaVoss_Hurt_Heavy";
                case HitReactionType.Crumple: return "RykaVoss_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "RykaVoss_Launch_Airborne";
                default: return "RykaVoss_Hurt_Gut";
            }
        }
    }
}
