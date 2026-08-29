using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideCardWidget
    {
        public string FighterId { get; } = "mira_tide";
        public string FighterName { get; } = "Mira Tide";
        public string ElementTitle { get; } = "Tideblade";
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
