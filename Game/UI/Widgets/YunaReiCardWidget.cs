using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiCardWidget
    {
        public string FighterId { get; } = "yuna_rei";
        public string FighterName { get; } = "Yuna Rei";
        public string ElementTitle { get; } = "Spirit Dancer";
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
