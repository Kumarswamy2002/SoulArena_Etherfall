using System;
using SoulArena.Core;

namespace SoulArena.Combat.Scales
{
    /// <summary>
    /// Hurtbox Dynamic Scaling Multiplier on Duck / Jump for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelHurtboxScale
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
