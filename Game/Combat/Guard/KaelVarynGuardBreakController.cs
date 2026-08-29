using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Guard
{
    /// <summary>
    /// Guard Break Stun Duration & Armor Shatter Controller for Kael Varyn (Stormbound).
    /// </summary>
    public class KaelVarynGuardBreakController
    {
        public string FighterId { get; } = "kael_varyn";
        public float GuardCrushStunSeconds { get; set; } = 2.5f;
        public int TotalGuardBreaksSuffered { get; private set; } = 0;

        public event Action<string> OnArmorShattered;

        public void TriggerGuardCrush()
        {
            TotalGuardBreaksSuffered++;
            OnArmorShattered?.Invoke("kael_varyn_guard_crushed");
        }
    }
}
