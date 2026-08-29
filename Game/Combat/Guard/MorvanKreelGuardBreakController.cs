using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Guard
{
    /// <summary>
    /// Guard Break Stun Duration & Armor Shatter Controller for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelGuardBreakController
    {
        public string FighterId { get; } = "morvan_kreel";
        public float GuardCrushStunSeconds { get; set; } = 2.5f;
        public int TotalGuardBreaksSuffered { get; private set; } = 0;

        public event Action<string> OnArmorShattered;

        public void TriggerGuardCrush()
        {
            TotalGuardBreaksSuffered++;
            OnArmorShattered?.Invoke("morvan_kreel_guard_crushed");
        }
    }
}
