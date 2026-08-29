using System;
using SoulArena.Core;

namespace SoulArena.Combat.Pushback
{
    /// <summary>
    /// Blockstring Pushback & Corner Spacing Decoupler for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValePushbackDecoupler
    {
        public float BaseBlockPushbackForce { get; set; } = 4.2f;
        public float CornerSelfPushbackRatio { get; set; } = 0.85f;

        public (float defenderPush, float attackerPush) CalculatePushback(bool defenderInCorner)
        {
            if (defenderInCorner)
            {
                return (0.0f, BaseBlockPushbackForce * CornerSelfPushbackRatio);
            }
            return (BaseBlockPushbackForce, 0.0f);
        }
    }
}
