using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Reactions
{
    /// <summary>
    /// Custom Damage Reaction & Hurt Physics Modifier for Kael Varyn (Stormbound).
    /// Calculates hitstun decay, launch angle damping, and get-up recovery frames.
    /// </summary>
    public class KaelVarynReactionHandler
    {
        public string FighterId { get; } = "kael_varyn";
        public float WeightMultiplier { get; set; } = 1.0f;
        public bool IsArmorActive { get; private set; } = false;

        public (float hitstun, Vector3D adjustedKnockback) CalculateReaction(HitResult hit)
        {
            float hitstun = hit.HitstunDuration;
            Vector3D knockback = hit.Knockback;

            if (IsArmorActive)
            {
                hitstun *= 0.5f;
                knockback = knockback * 0.4f;
            }

            // Weight affects vertical launch force
            knockback = new Vector3D(knockback.X, knockback.Y / WeightMultiplier, knockback.Z);
            return (hitstun, knockback);
        }
    }
}
