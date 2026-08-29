using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "YunaRei_Hurt_Head" : "YunaRei_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "YunaRei_Hurt_Heavy";
                case HitReactionType.Crumple: return "YunaRei_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "YunaRei_Launch_Airborne";
                default: return "YunaRei_Hurt_Gut";
            }
        }
    }
}
