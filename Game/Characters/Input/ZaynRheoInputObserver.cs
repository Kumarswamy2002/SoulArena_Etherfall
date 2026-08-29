using System;
using SoulArena.Core;

namespace SoulArena.Characters.Input
{
    /// <summary>
    /// Frame-by-Frame Input Queue Monitor for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoInputObserver
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
