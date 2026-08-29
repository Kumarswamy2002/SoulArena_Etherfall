using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Vexa Noir (Void Walker).
    /// </summary>
    public class VexaNoirHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "VexaNoir_Hurt_Head" : "VexaNoir_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "VexaNoir_Hurt_Heavy";
                case HitReactionType.Crumple: return "VexaNoir_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "VexaNoir_Launch_Airborne";
                default: return "VexaNoir_Hurt_Gut";
            }
        }
    }
}
