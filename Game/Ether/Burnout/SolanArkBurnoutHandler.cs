using System;
using SoulArena.Core;
using SoulArena.Ether;

namespace SoulArena.Ether.Burnout
{
    /// <summary>
    /// Burnout Recovery Curve & Defense Penalties for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkBurnoutHandler
    {
        public string FighterId { get; } = "solan_ark";
        public float BurnoutDefensePenalty { get; set; } = 0.30f;
        public float BurnoutSpeedPenalty { get; set; } = 0.20f;

        public float CalculateEffectiveArmor(float baseArmor, bool isBurnout)
        {
            return isBurnout ? baseArmor * (1.0f - BurnoutDefensePenalty) : baseArmor;
        }

        public float CalculateEffectiveMoveSpeed(float baseSpeed, bool isBurnout)
        {
            return isBurnout ? baseSpeed * (1.0f - BurnoutSpeedPenalty) : baseSpeed;
        }
    }
}
