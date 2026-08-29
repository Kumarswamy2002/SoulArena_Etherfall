using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelCardWidget
    {
        public string FighterId { get; } = "morvan_kreel";
        public string FighterName { get; } = "Morvan Kreel";
        public string ElementTitle { get; } = "Grave King";
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
