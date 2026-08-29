using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Guard
{
    /// <summary>
    /// Guard Break Stun Duration & Armor Shatter Controller for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeGuardBreakController
    {
        public string FighterId { get; } = "seren_vale";
        public float GuardCrushStunSeconds { get; set; } = 2.5f;
        public int TotalGuardBreaksSuffered { get; private set; } = 0;

        public event Action<string> OnArmorShattered;

        public void TriggerGuardCrush()
        {
            TotalGuardBreaksSuffered++;
            OnArmorShattered?.Invoke("seren_vale_guard_crushed");
        }
    }
}
