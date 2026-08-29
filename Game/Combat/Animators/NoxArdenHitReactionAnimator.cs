using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "NoxArden_Hurt_Head" : "NoxArden_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "NoxArden_Hurt_Heavy";
                case HitReactionType.Crumple: return "NoxArden_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "NoxArden_Launch_Airborne";
                default: return "NoxArden_Hurt_Gut";
            }
        }
    }
}
