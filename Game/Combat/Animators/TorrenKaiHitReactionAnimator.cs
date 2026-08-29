using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "TorrenKai_Hurt_Head" : "TorrenKai_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "TorrenKai_Hurt_Heavy";
                case HitReactionType.Crumple: return "TorrenKai_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "TorrenKai_Launch_Airborne";
                default: return "TorrenKai_Hurt_Gut";
            }
        }
    }
}
