using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Combat.Buffers
{
    /// <summary>
    /// Precise Frame Buffer & Input Reversal Window for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiMoveBuffer
    {
        public int BufferWindowFrames { get; set; } = 6;
        public string QueuedMoveId { get; private set; } = null;
        public int QueuedFrameCount { get; private set; } = 0;

        public void EnqueueMove(string moveId)
        {
            QueuedMoveId = moveId;
            QueuedFrameCount = BufferWindowFrames;
        }

        public void Tick()
        {
            if (QueuedFrameCount > 0)
            {
                QueuedFrameCount--;
                if (QueuedFrameCount == 0)
                {
                    QueuedMoveId = null;
                }
            }
        }

        public string ConsumeBufferedMove()
        {
            string move = QueuedMoveId;
            QueuedMoveId = null;
            QueuedFrameCount = 0;
            return move;
        }
    }
}
