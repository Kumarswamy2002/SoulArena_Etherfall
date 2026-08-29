using System;
using SoulArena.Core;

namespace SoulArena.Combat.Pushback
{
    /// <summary>
    /// Blockstring Pushback & Corner Spacing Decoupler for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenPushbackDecoupler
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
