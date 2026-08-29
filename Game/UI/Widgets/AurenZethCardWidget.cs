using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethCardWidget
    {
        public string FighterId { get; } = "auren_zeth";
        public string FighterName { get; } = "Auren Zeth";
        public string ElementTitle { get; } = "First Soul";
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
