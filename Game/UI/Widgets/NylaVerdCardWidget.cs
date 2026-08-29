using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Nyla Verd (Wild Caller).
    /// </summary>
    public class NylaVerdCardWidget
    {
        public string FighterId { get; } = "nyla_verd";
        public string FighterName { get; } = "Nyla Verd";
        public string ElementTitle { get; } = "Wild Caller";
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
