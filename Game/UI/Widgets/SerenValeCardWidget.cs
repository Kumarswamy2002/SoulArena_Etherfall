using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeCardWidget
    {
        public string FighterId { get; } = "seren_vale";
        public string FighterName { get; } = "Seren Vale";
        public string ElementTitle { get; } = "Frozen Blade";
        public bool IsSelected { get; set; } = false;

        public event Action<string> OnCardClicked;

        public void Select()
        {
            IsSelected = true;
            OnCardClicked?.Invoke(FighterId);
        }

        public void Deselect()
        {
            IsSelected = false;
        }
    }
}
