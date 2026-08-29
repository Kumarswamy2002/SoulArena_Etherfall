using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Kael Varyn (Stormbound).
    /// </summary>
    public class KaelVarynCardWidget
    {
        public string FighterId { get; } = "kael_varyn";
        public string FighterName { get; } = "Kael Varyn";
        public string ElementTitle { get; } = "Stormbound";
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
