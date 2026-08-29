using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "SolanArk_Hurt_Head" : "SolanArk_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "SolanArk_Hurt_Heavy";
                case HitReactionType.Crumple: return "SolanArk_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "SolanArk_Launch_Airborne";
                default: return "SolanArk_Hurt_Gut";
            }
        }
    }
}
