using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "RavenDrake_Hurt_Head" : "RavenDrake_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "RavenDrake_Hurt_Heavy";
                case HitReactionType.Crumple: return "RavenDrake_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "RavenDrake_Launch_Airborne";
                default: return "RavenDrake_Hurt_Gut";
            }
        }
    }
}
