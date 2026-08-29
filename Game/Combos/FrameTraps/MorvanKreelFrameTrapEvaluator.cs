using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combos.FrameTraps
{
    /// <summary>
    /// Frame Trap & Blockstring Gap Calculator for Morvan Kreel (Grave King).
    /// Calculates intentional 2-to-4 frame gaps to counter-hit mashers.
    /// </summary>
    public class MorvanKreelFrameTrapEvaluator
    {
        public struct TrapSequence
        {
            public string StarterMove;
            public string TrapFollowup;
            public int GapFrames;
            public bool BeatsFastJab;
        }

        public static readonly TrapSequence LightToHeavyTrap = new TrapSequence
        {
            StarterMove = "morvan_kreel_light2",
            TrapFollowup = "morvan_kreel_heavy",
            GapFrames = 3,
            BeatsFastJab = true
        };

        public static bool IsValidFrameTrap(int onBlockAdvantage, int startupNextMove)
        {
            int gap = startupNextMove + onBlockAdvantage;
            return gap >= 2 && gap <= 4;
        }
    }
}
