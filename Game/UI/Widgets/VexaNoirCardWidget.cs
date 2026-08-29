using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Vexa Noir (Void Walker).
    /// </summary>
    public class VexaNoirCardWidget
    {
        public string FighterId { get; } = "vexa_noir";
        public string FighterName { get; } = "Vexa Noir";
        public string ElementTitle { get; } = "Void Walker";
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
