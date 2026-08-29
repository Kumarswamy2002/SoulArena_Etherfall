using System;
using SoulArena.Core;

namespace SoulArena.Combat.Scales
{
    /// <summary>
    /// Hurtbox Dynamic Scaling Multiplier on Duck / Jump for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeHurtboxScale
    {
        public float StandingHeightScale { get; set; } = 1.0f;
        public float CrouchingHeightScale { get; set; } = 0.65f;
        public float JumpingWidthScale { get; set; } = 0.85f;

        public float GetHeightModifier(bool isCrouching, bool isJumping)
        {
            if (isCrouching) return CrouchingHeightScale;
            if (isJumping) return 0.9f;
            return StandingHeightScale;
        }
    }
}
