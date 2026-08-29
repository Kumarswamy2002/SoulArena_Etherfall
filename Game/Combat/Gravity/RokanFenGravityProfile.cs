using System;
using SoulArena.Core;

namespace SoulArena.Combat.Gravity
{
    /// <summary>
    /// Airborne Juggle Gravity Scaling & Ground Bounce Restitution for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenGravityProfile
    {
        public float BaseJuggleGravity { get; set; } = 28.0f;
        public float JuggleDecayPerHit { get; set; } = 2.5f;
        public float GroundBounceRestitution { get; set; } = 0.65f;

        public float GetEffectiveJuggleGravity(int currentJuggleHits)
        {
            return BaseJuggleGravity + (currentJuggleHits * JuggleDecayPerHit);
        }
    }
}
