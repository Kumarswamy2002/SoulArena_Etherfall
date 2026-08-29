using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilCardWidget
    {
        public string FighterId { get; } = "orin_veil";
        public string FighterName { get; } = "Orin Veil";
        public string ElementTitle { get; } = "Mind Weaver";
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
