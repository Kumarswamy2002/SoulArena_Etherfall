using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Counters
{
    /// <summary>
    /// Counter-Hit Detection & Extra Hitstun Scaler for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiCounterHandler
    {
        public float CounterHitDamageMultiplier { get; set; } = 1.25f;
        public float CounterHitstunExtraSeconds { get; set; } = 0.20f;

        public (float finalDmg, float finalStun) EvaluateCounter(HitResult hit, bool opponentInStartup)
        {
            float dmg = hit.Damage;
            float stun = hit.HitstunDuration;

            if (opponentInStartup)
            {
                dmg *= CounterHitDamageMultiplier;
                stun += CounterHitstunExtraSeconds;
            }

            return (dmg, stun);
        }
    }
}
