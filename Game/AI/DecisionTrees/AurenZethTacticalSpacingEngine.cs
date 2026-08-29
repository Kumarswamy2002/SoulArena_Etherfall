using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.AI.DecisionTrees
{
    /// <summary>
    /// Tactical Spacing & Counter-Hit Decision Engine for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethTacticalSpacingEngine
    {
        public float OptimalRange { get; set; } = 3.0f;
        public float RetreatThreshold { get; set; } = 1.2f;

        public Vector3D CalculateTargetVelocity(Vector3D selfPos, Vector3D enemyPos, float currentSpeed)
        {
            float deltaX = enemyPos.X - selfPos.X;
            float dist = Math.Abs(deltaX);

            if (dist < RetreatThreshold)
            {
                // Step back
                float dir = deltaX > 0 ? -1.0f : 1.0f;
                return new Vector3D(dir * currentSpeed * 0.8f, 0, 0);
            }
            else if (dist > OptimalRange)
            {
                // Advance forward
                float dir = deltaX > 0 ? 1.0f : -1.0f;
                return new Vector3D(dir * currentSpeed, 0, 0);
            }

            return Vector3D.Zero;
        }
    }
}
