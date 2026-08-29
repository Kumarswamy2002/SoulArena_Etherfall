using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Wakeup
{
    /// <summary>
    /// Wakeup Tech, Quick Stand & Invulnerable Roll Logic for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiWakeupSelector
    {
        public enum WakeupOption
        {
            NeutralGetup,
            QuickStand,
            BackwardRoll,
            ForwardRoll,
            InvulnerableReversal
        }

        public WakeupOption PreferredWakeup { get; set; } = WakeupOption.NeutralGetup;

        public Vector3D CalculateWakeupDisplacement(WakeupOption option, bool facingRight)
        {
            float dir = facingRight ? 1.0f : -1.0f;
            switch (option)
            {
                case WakeupOption.BackwardRoll: return new Vector3D(-dir * 2.5f, 0f, 0f);
                case WakeupOption.ForwardRoll: return new Vector3D(dir * 2.5f, 0f, 0f);
                default: return Vector3D.Zero;
            }
        }
    }
}
