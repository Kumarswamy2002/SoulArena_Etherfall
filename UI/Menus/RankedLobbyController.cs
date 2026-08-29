using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.UI.Menus
{
    /// <summary>
    /// RankedLobbyController: Competitive ranked matchmaking screen displaying current tier badge, LP, and queue timer
    /// </summary>
    public class RankedLobbyController
    {
        public bool IsVisible { get; set; } = true;
        public float AnimationProgress { get; private set; } = 0.0f;

        public event Action OnWidgetUpdated;

        public virtual void Show()
        {
            IsVisible = true;
            AnimationProgress = 0.0f;
        }

        public virtual void Hide()
        {
            IsVisible = false;
        }

        public virtual void UpdateWidget(float deltaTime)
        {
            if (!IsVisible) return;
            AnimationProgress = MathUtility.Clamp01(AnimationProgress + (deltaTime * 4.0f));
            OnWidgetUpdated?.Invoke();
        }
    }
}
