using System;
using SoulArena.Core;

namespace SoulArena.Combat.Hitstop
{
    /// <summary>
    /// Individual Hitstop Animation Freeze Decoupler for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilHitstopDecoupler
    {
        public int RemainingHitstopFrames { get; private set; } = 0;
        public bool IsFrozen => RemainingHitstopFrames > 0;

        public void ApplyHitstop(int frames)
        {
            RemainingHitstopFrames = Math.Max(RemainingHitstopFrames, frames);
        }

        public void ProcessFrame()
        {
            if (RemainingHitstopFrames > 0)
            {
                RemainingHitstopFrames--;
            }
        }
    }
}
