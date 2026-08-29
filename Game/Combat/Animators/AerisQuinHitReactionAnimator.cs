using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Aeris Quin (Star Weaver).
    /// </summary>
    public class AerisQuinHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "AerisQuin_Hurt_Head" : "AerisQuin_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "AerisQuin_Hurt_Heavy";
                case HitReactionType.Crumple: return "AerisQuin_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "AerisQuin_Launch_Airborne";
                default: return "AerisQuin_Hurt_Gut";
            }
        }
    }
}
