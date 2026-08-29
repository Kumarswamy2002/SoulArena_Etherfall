using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolCardWidget
    {
        public string FighterId { get; } = "elara_sol";
        public string FighterName { get; } = "Elara Sol";
        public string ElementTitle { get; } = "Dawn Saint";
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
