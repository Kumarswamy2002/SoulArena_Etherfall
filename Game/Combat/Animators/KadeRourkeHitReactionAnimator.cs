using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "KadeRourke_Hurt_Head" : "KadeRourke_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "KadeRourke_Hurt_Heavy";
                case HitReactionType.Crumple: return "KadeRourke_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "KadeRourke_Launch_Airborne";
                default: return "KadeRourke_Hurt_Gut";
            }
        }
    }
}
