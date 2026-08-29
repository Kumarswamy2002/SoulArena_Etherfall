using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Guard
{
    /// <summary>
    /// Guard Break Stun Duration & Armor Shatter Controller for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeGuardBreakController
    {
        public string FighterId { get; } = "kade_rourke";
        public float GuardCrushStunSeconds { get; set; } = 2.5f;
        public int TotalGuardBreaksSuffered { get; private set; } = 0;

        public event Action<string> OnArmorShattered;

        public void TriggerGuardCrush()
        {
            TotalGuardBreaksSuffered++;
            OnArmorShattered?.Invoke("kade_rourke_guard_crushed");
        }
    }
}
