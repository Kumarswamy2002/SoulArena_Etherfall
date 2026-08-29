using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Drakor Thane (Iron Colossus).
    /// </summary>
    public class DrakorThaneCardWidget
    {
        public string FighterId { get; } = "drakor_thane";
        public string FighterName { get; } = "Drakor Thane";
        public string ElementTitle { get; } = "Iron Colossus";
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
