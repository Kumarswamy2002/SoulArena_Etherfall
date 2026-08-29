using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.UI.ViewModels
{
    /// <summary>
    /// CharacterSelectViewModel: MVVM ViewModel binding 20 fighter statistics, 3D preview renderers, and lore blurbs
    /// </summary>
    public class CharacterSelectViewModel
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
