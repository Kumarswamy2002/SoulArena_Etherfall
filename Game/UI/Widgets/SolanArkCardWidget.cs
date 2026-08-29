using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkCardWidget
    {
        public string FighterId { get; } = "solan_ark";
        public string FighterName { get; } = "Solan Ark";
        public string ElementTitle { get; } = "Sunforged";
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
