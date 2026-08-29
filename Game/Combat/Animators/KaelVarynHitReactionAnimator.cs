using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Kael Varyn (Stormbound).
    /// </summary>
    public class KaelVarynHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "KaelVaryn_Hurt_Head" : "KaelVaryn_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "KaelVaryn_Hurt_Heavy";
                case HitReactionType.Crumple: return "KaelVaryn_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "KaelVaryn_Launch_Airborne";
                default: return "KaelVaryn_Hurt_Gut";
            }
        }
    }
}
