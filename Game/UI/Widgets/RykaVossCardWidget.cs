using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossCardWidget
    {
        public string FighterId { get; } = "ryka_voss";
        public string FighterName { get; } = "Ryka Voss";
        public string ElementTitle { get; } = "Ember Wolf";
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
