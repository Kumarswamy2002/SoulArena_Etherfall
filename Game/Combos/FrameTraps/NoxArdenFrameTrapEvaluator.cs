using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combos.FrameTraps
{
    /// <summary>
    /// Frame Trap & Blockstring Gap Calculator for Nox Arden (Riftborn).
    /// Calculates intentional 2-to-4 frame gaps to counter-hit mashers.
    /// </summary>
    public class NoxArdenFrameTrapEvaluator
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
            StarterMove = "nox_arden_light2",
            TrapFollowup = "nox_arden_heavy",
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
