using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Training
{
    /// <summary>
    /// Frame Data & Reversal Action Training Bot for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideTrainingBot
    {
        public enum ReversalActionType
        {
            None,
            WakeupReversal,
            GuardCancelSpecial,
            AutoParry
        }

        public ReversalActionType ActiveReversal { get; set; } = ReversalActionType.None;

        public void ExecuteWakeupReversal(FighterBase fighter)
        {
            if (fighter == null) return;
            if (ActiveReversal == ReversalActionType.WakeupReversal)
            {
                fighter.Ether.AddEther(20.0f);
            }
        }
    }
}
