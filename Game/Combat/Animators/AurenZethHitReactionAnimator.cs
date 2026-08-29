using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "AurenZeth_Hurt_Head" : "AurenZeth_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "AurenZeth_Hurt_Heavy";
                case HitReactionType.Crumple: return "AurenZeth_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "AurenZeth_Launch_Airborne";
                default: return "AurenZeth_Hurt_Gut";
            }
        }
    }
}
