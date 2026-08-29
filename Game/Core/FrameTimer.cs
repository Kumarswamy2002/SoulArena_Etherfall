using System;

namespace SoulArena.Core
{
    /// <summary>
    /// Frame-accurate timer synchronized with the 60 FPS deterministic game loop.
    /// Provides exact frame counters, delta calculations, and hitstop freeze mechanics.
    /// </summary>
    public class FrameTimer
    {
        public long CurrentFrame { get; private set; }
        public float ElapsedTime => CurrentFrame * GameConstants.FIXED_DELTA_TIME;
        public int HitstopFramesRemaining { get; private set; }

        public bool IsInHitstop => HitstopFramesRemaining > 0;

        public event Action<long> OnFrameTicked;
        public event Action OnHitstopStarted;
        public event Action OnHitstopEnded;

        public void AdvanceFrame()
        {
            if (HitstopFramesRemaining > 0)
            {
                HitstopFramesRemaining--;
                if (HitstopFramesRemaining == 0)
                {
                    OnHitstopEnded?.Invoke();
                }
                return; // Freeze game simulation frame during hitstop
            }

            CurrentFrame++;
            OnFrameTicked?.Invoke(CurrentFrame);
        }

        public void ApplyHitstop(int frames)
        {
            if (frames <= 0) return;
            HitstopFramesRemaining = Math.Max(HitstopFramesRemaining, frames);
            OnHitstopStarted?.Invoke();
        }

        public void Reset()
        {
            CurrentFrame = 0;
            HitstopFramesRemaining = 0;
        }

        public static float FramesToSeconds(int frames)
        {
            return frames * GameConstants.FIXED_DELTA_TIME;
        }

        public static int SecondsToFrames(float seconds)
        {
            return (int)Math.Round(seconds * GameConstants.TARGET_FRAME_RATE);
        }
    }
}
