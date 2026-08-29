using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeCardWidget
    {
        public string FighterId { get; } = "raven_drake";
        public string FighterName { get; } = "Raven Drake";
        public string ElementTitle { get; } = "Blood Knight";
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
