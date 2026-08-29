using System;
using System.Collections.Generic;

namespace SoulArena.Core
{
    [Flags]
    public enum InputButton
    {
        None = 0,
        LightAttack = 1 << 0,
        HeavyAttack = 1 << 1,
        Special1 = 1 << 2,
        Special2 = 1 << 3,
        Special3 = 1 << 4,
        Special4 = 1 << 5,
        Block = 1 << 6,
        Dodge = 1 << 7,
        Jump = 1 << 8,
        Awaken = 1 << 9,
        Ultimate = 1 << 10,
        BurstEscape = 1 << 11,
        Grab = 1 << 12
    }

    public struct InputFrame
    {
        public long FrameNumber;
        public float MovementX; // -1 to 1
        public float MovementY; // -1 to 1 (Forward / Backward)
        public InputButton ButtonsPressed;
        public InputButton ButtonsHeld;
        public InputButton ButtonsReleased;

        public bool HasButtonPressed(InputButton button) => (ButtonsPressed & button) != 0;
        public bool HasButtonHeld(InputButton button) => (ButtonsHeld & button) != 0;
        public bool HasButtonReleased(InputButton button) => (ButtonsReleased & button) != 0;
    }

    /// <summary>
    /// Frame-accurate input buffer supporting move buffering, button priority resolution, and special motion parsing.
    /// </summary>
    public class InputBuffer
    {
        private readonly Queue<InputFrame> _history = new Queue<InputFrame>();
        private readonly int _bufferWindowFrames;
        
        public InputFrame CurrentFrameInput { get; private set; }

        public InputBuffer(int bufferWindowFrames = GameConstants.INPUT_BUFFER_MAX_FRAMES)
        {
            _bufferWindowFrames = bufferWindowFrames;
        }

        public void PushFrame(InputFrame frame)
        {
            CurrentFrameInput = frame;
            _history.Enqueue(frame);

            while (_history.Count > _bufferWindowFrames)
            {
                _history.Dequeue();
            }
        }

        public bool CheckBufferedButtonPress(InputButton button, out long consumedFrame)
        {
            consumedFrame = -1;
            foreach (var frame in _history)
            {
                if (frame.HasButtonPressed(button))
                {
                    consumedFrame = frame.FrameNumber;
                    return true;
                }
            }
            return false;
        }

        public bool CheckQuarterCircleForward()
        {
            // Parses Down -> Down-Forward -> Forward motion across recent frames
            bool sawDown = false;
            bool sawDownForward = false;

            foreach (var frame in _history)
            {
                if (!sawDown && frame.MovementY < -0.5f)
                {
                    sawDown = true;
                }
                else if (sawDown && !sawDownForward && frame.MovementY < -0.3f && frame.MovementX > 0.3f)
                {
                    sawDownForward = true;
                }
                else if (sawDown && sawDownForward && frame.MovementX > 0.6f && Math.Abs(frame.MovementY) < 0.4f)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckDragonPunchMotion()
        {
            // Parses Forward -> Down -> Down-Forward motion across recent frames
            bool sawForward = false;
            bool sawDown = false;

            foreach (var frame in _history)
            {
                if (!sawForward && frame.MovementX > 0.6f && Math.Abs(frame.MovementY) < 0.4f)
                {
                    sawForward = true;
                }
                else if (sawForward && !sawDown && frame.MovementY < -0.5f)
                {
                    sawDown = true;
                }
                else if (sawForward && sawDown && frame.MovementX > 0.4f && frame.MovementY < -0.3f)
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _history.Clear();
            CurrentFrameInput = default;
        }
    }
}
