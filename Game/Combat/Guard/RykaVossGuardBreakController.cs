using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Guard
{
    /// <summary>
    /// Guard Break Stun Duration & Armor Shatter Controller for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossGuardBreakController
    {
        public string FighterId { get; } = "ryka_voss";
        public float GuardCrushStunSeconds { get; set; } = 2.5f;
        public int TotalGuardBreaksSuffered { get; private set; } = 0;

        public event Action<string> OnArmorShattered;

        public void TriggerGuardCrush()
        {
            TotalGuardBreaksSuffered++;
            OnArmorShattered?.Invoke("ryka_voss_guard_crushed");
        }
    }
}
