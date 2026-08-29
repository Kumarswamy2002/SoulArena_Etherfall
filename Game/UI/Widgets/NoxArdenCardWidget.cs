using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenCardWidget
    {
        public string FighterId { get; } = "nox_arden";
        public string FighterName { get; } = "Nox Arden";
        public string ElementTitle { get; } = "Riftborn";
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
