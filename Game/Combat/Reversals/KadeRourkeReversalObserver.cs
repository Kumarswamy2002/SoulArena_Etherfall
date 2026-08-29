using System;
using SoulArena.Core;

namespace SoulArena.Combat.Reversals
{
    /// <summary>
    /// Frame-Perfect Wakeup & Reversal Action Buffer for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeReversalObserver
    {
        public int ReversalBufferFrames { get; set; } = 4;
        public string QueuedReversalAction { get; private set; } = null;
        public int FramesBuffered { get; private set; } = 0;

        public void BufferReversal(string actionKey)
        {
            QueuedReversalAction = actionKey;
            FramesBuffered = ReversalBufferFrames;
        }

        public void ProcessTick()
        {
            if (FramesBuffered > 0)
            {
                FramesBuffered--;
                if (FramesBuffered == 0)
                {
                    QueuedReversalAction = null;
                }
            }
        }

        public string ConsumeReversal()
        {
            string act = QueuedReversalAction;
            QueuedReversalAction = null;
            FramesBuffered = 0;
            return act;
        }
    }
}
