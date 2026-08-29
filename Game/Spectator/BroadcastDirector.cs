using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Spectator
{
    /// <summary>
    /// BroadcastDirector: Automated esports camera angle switcher switching between wide neutral shots and close-up impact cameras
    /// </summary>
    public class BroadcastDirector
    {
        public bool IsBroadcasting { get; set; } = true;
        public float CameraSmoothingSpeed { get; set; } = 6.5f;
        public int ConnectedSpectatorCount { get; private set; } = 0;

        public event Action<string> OnBroadcastViewSwitched;

        public void UpdateCameraTracking(FighterBase p1, FighterBase p2, float deltaTime)
        {
            if (!IsBroadcasting || p1 == null || p2 == null) return;

            Vector3D midPoint = (p1.Position + p2.Position) * 0.5f;
            float distance = (p1.Position - p2.Position).Magnitude;

            if (distance > 8.0f)
            {
                OnBroadcastViewSwitched?.Invoke("Wide_Overview_Camera");
            }
            else if (p1.Awakening.IsAwakened || p2.Awakening.IsAwakened)
            {
                OnBroadcastViewSwitched?.Invoke("Awakening_Dynamic_CloseUp");
            }
        }

        public void AddSpectator(string observerId)
        {
            ConnectedSpectatorCount++;
        }

        public void RemoveSpectator(string observerId)
        {
            ConnectedSpectatorCount = Math.Max(0, ConnectedSpectatorCount - 1);
        }
    }
}
