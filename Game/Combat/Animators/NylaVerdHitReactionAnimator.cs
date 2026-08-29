using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Nyla Verd (Wild Caller).
    /// </summary>
    public class NylaVerdHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "NylaVerd_Hurt_Head" : "NylaVerd_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "NylaVerd_Hurt_Heavy";
                case HitReactionType.Crumple: return "NylaVerd_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "NylaVerd_Launch_Airborne";
                default: return "NylaVerd_Hurt_Gut";
            }
        }
    }
}
