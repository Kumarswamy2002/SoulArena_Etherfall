using System;
using SoulArena.Core;
using SoulArena.Ether;

namespace SoulArena.Ether.Burnout
{
    /// <summary>
    /// Burnout Recovery Curve & Defense Penalties for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenBurnoutHandler
    {
        public string FighterId { get; } = "rokan_fen";
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
