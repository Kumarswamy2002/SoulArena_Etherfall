using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeCardWidget
    {
        public string FighterId { get; } = "kade_rourke";
        public string FighterName { get; } = "Kade Rourke";
        public string ElementTitle { get; } = "Iron Marauder";
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
