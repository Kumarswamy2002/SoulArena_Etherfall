using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenCardWidget
    {
        public string FighterId { get; } = "rokan_fen";
        public string FighterName { get; } = "Rokan Fen";
        public string ElementTitle { get; } = "Beast Soul";
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
