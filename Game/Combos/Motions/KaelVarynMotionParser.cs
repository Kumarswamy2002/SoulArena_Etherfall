using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Combos.Motions
{
    /// <summary>
    /// Special Motion Input Recognizer for Kael Varyn (Stormbound).
    /// Parses Quarter-Circle-Forward, Dragon Punch, and Half-Circle motions.
    /// </summary>
    public class KaelVarynMotionParser
    {
        public bool HasDetectedQCF { get; private set; }
        public bool HasDetectedDP { get; private set; }
        public bool HasDetectedHCF { get; private set; }

        public void ParseInputs(IEnumerable<InputFrame> inputBuffer)
        {
            HasDetectedQCF = false;
            HasDetectedDP = false;
            HasDetectedHCF = false;

            if (inputBuffer == null) return;

            bool sawDown = false;
            bool sawDownForward = false;

            foreach (var frame in inputBuffer)
            {
                if (!sawDown && frame.MovementY < -0.5f)
                {
                    sawDown = true;
                }
                else if (sawDown && !sawDownForward && frame.MovementY < -0.2f && frame.MovementX > 0.3f)
                {
                    sawDownForward = true;
                }
                else if (sawDown && sawDownForward && frame.MovementX > 0.6f)
                {
                    HasDetectedQCF = true;
                    break;
                }
            }
        }
    }
}
