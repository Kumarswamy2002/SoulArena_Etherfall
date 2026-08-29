using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Guard
{
    /// <summary>
    /// Guard Break Stun Duration & Armor Shatter Controller for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoGuardBreakController
    {
        public string FighterId { get; } = "zayn_rheo";
        public float GuardCrushStunSeconds { get; set; } = 2.5f;
        public int TotalGuardBreaksSuffered { get; private set; } = 0;

        public event Action<string> OnArmorShattered;

        public void TriggerGuardCrush()
        {
            TotalGuardBreaksSuffered++;
            OnArmorShattered?.Invoke("zayn_rheo_guard_crushed");
        }
    }
}
