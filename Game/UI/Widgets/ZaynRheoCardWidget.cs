using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoCardWidget
    {
        public string FighterId { get; } = "zayn_rheo";
        public string FighterName { get; } = "Zayn Rheo";
        public string ElementTitle { get; } = "Lightning Phantom";
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
