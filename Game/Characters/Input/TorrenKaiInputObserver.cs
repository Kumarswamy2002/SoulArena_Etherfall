using System;
using SoulArena.Core;

namespace SoulArena.Characters.Input
{
    /// <summary>
    /// Frame-by-Frame Input Queue Monitor for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiInputObserver
    {
        public int TotalInputsRecorded { get; private set; } = 0;
        public InputButton LastPressedButton { get; private set; } = InputButton.None;

        public void NotifyInput(InputFrame frame)
        {
            TotalInputsRecorded++;
            LastPressedButton = frame.ButtonsPressed;
        }
    }
}
