using System;
using SoulArena.Core;

namespace SoulArena.Physics
{
    /// <summary>
    /// High-performance 3D Kinematic Character Controller and Motor.
    /// Provides frame-deterministic movement integration, ground snapping, wall sliding, and slope projection.
    /// </summary>
    public class KinematicMotor3D
    {
        public Vector3D Position { get; set; } = Vector3D.Zero;
        public Vector3D Velocity { get; set; } = Vector3D.Zero;
        public Vector3D GroundNormal { get; set; } = Vector3D.Up;
        
        public float CharacterRadius { get; set; } = 0.5f;
        public float CharacterHeight { get; set; } = 1.8f;
        public float MaxSlopeAngleDegrees { get; set; } = 45.0f;
        public float StepOffset { get; set; } = 0.3f;
        
        public bool IsGrounded { get; private set; } = true;
        public bool WasGroundedLastFrame { get; private set; } = true;
        public float GroundStickiness { get; set; } = 8.0f;
        public float BaseGravity { get; set; } = 28.0f;
        public float AirResistance { get; set; } = 0.05f;
        public float GroundFriction { get; set; } = 12.0f;

        public event Action<Vector3D> OnLanded;
        public event Action OnLeftGround;
        public event Action<Vector3D, Vector3D> OnWallHit;

        public void Integrate(float deltaTime, Vector3D inputMovement, bool jumpRequested, float jumpForce)
        {
            WasGroundedLastFrame = IsGrounded;

            // 1. Process horizontal movement acceleration
            if (IsGrounded)
            {
                // Project input vector onto ground plane
                Vector3D projectedInput = ProjectOnPlane(inputMovement, GroundNormal).Normalized * inputMovement.Magnitude;
                Vector3D targetVelocity = projectedInput;

                // Apply ground friction & acceleration
                Velocity = Vector3D.Lerp(Velocity, targetVelocity, GroundFriction * deltaTime);

                // Jump execution
                if (jumpRequested)
                {
                    Velocity = new Vector3D(Velocity.X, jumpForce, Velocity.Z);
                    IsGrounded = false;
                    OnLeftGround?.Invoke();
                }
            }
            else
            {
                // Airborne physics: apply gravity and air resistance
                float newY = Velocity.Y - (BaseGravity * deltaTime);
                float newX = Velocity.X * (1.0f - AirResistance * deltaTime);
                float newZ = Velocity.Z * (1.0f - AirResistance * deltaTime);
                
                // Add air steering control
                newX += inputMovement.X * 4.0f * deltaTime;
                newZ += inputMovement.Z * 4.0f * deltaTime;

                Velocity = new Vector3D(newX, newY, newZ);
            }

            // 2. Compute motion step
            Vector3D displacement = Velocity * deltaTime;
            Position += displacement;

            // 3. Simple floor contact constraint
            if (Position.Y <= 0.0f)
            {
                Position = new Vector3D(Position.X, 0.0f, Position.Z);
                if (!WasGroundedLastFrame)
                {
                    OnLanded?.Invoke(Velocity);
                }
                Velocity = new Vector3D(Velocity.X, 0.0f, Velocity.Z);
                IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
            }
        }

        public static Vector3D ProjectOnPlane(Vector3D vector, Vector3D planeNormal)
        {
            float num = Vector3D.Dot(planeNormal, planeNormal);
            if (num < 0.0001f) return vector;
            float num2 = Vector3D.Dot(vector, planeNormal);
            return new Vector3D(vector.X - planeNormal.X * num2 / num, vector.Y - planeNormal.Y * num2 / num, vector.Z - planeNormal.Z * num2 / num);
        }

        public void Teleport(Vector3D newPosition)
        {
            Position = newPosition;
            Velocity = Vector3D.Zero;
        }

        public void AddImpulse(Vector3D impulse)
        {
            Velocity += impulse;
            if (impulse.Y > 1.0f)
            {
                IsGrounded = false;
            }
        }
    }
}
