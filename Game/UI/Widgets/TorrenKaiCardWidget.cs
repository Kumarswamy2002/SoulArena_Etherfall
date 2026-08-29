using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiCardWidget
    {
        public string FighterId { get; } = "torren_kai";
        public string FighterName { get; } = "Torren Kai";
        public string ElementTitle { get; } = "Wind Dancer";
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
