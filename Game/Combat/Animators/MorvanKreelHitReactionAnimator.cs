using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Animators
{
    /// <summary>
    /// Directional Hurt Animation Blending & Flinch Angles for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelHitReactionAnimator
    {
        public float UpperBodyWeight { get; set; } = 0.85f;
        public float LowerBodyWeight { get; set; } = 0.40f;
        public string ActiveHurtAnimation { get; private set; } = "None";

        public string SelectHurtClip(HitReactionType reaction, Vector3D hitDirection)
        {
            bool isHigh = hitDirection.Y > 1.2f;
            switch (reaction)
            {
                case HitReactionType.LightStagger: return isHigh ? "MorvanKreel_Hurt_Head" : "MorvanKreel_Hurt_Gut";
                case HitReactionType.HeavyStagger: return "MorvanKreel_Hurt_Heavy";
                case HitReactionType.Crumple: return "MorvanKreel_Crumple_Collapse";
                case HitReactionType.LaunchUp: return "MorvanKreel_Launch_Airborne";
                default: return "MorvanKreel_Hurt_Gut";
            }
        }
    }
}
