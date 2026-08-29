using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "OrinVeil_Hurt_Head" : "OrinVeil_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "OrinVeil_Hurt_Heavy";
                case HitReactionType.Crumple: return "OrinVeil_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "OrinVeil_Launch_Airborne";
                default: return "OrinVeil_Hurt_Gut";
            }
        }
    }
}
