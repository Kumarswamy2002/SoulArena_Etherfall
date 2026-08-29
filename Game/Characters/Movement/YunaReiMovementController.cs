using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Movement
{
    /// <summary>
    /// Specialized Dash Velocity, Air Dash, and Wave-Dashing for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiMovementController
    {
        public float ForwardDashSpeed { get; set; } = 16.5f;
        public float BackDashSpeed { get; set; } = 14.0f;
        public int DashInvulnerabilityFrames { get; set; } = 6;
        public bool CanAirDash { get; set; } = true;

        public Vector3D CalculateDashVelocity(bool forward, bool facingRight)
        {
            float dir = (forward == facingRight) ? 1.0f : -1.0f;
            float speed = forward ? ForwardDashSpeed : BackDashSpeed;
            return new Vector3D(dir * speed, 0f, 0f);
        }
    }
}
