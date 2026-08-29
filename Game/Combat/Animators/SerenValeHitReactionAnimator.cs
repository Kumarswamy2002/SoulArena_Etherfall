using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "SerenVale_Hurt_Head" : "SerenVale_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "SerenVale_Hurt_Heavy";
                case HitReactionType.Crumple: return "SerenVale_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "SerenVale_Launch_Airborne";
                default: return "SerenVale_Hurt_Gut";
            }
        }
    }
}
