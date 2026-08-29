using System;
using SoulArena.Core;

namespace SoulArena.UI.Widgets
{
    /// <summary>
    /// Dedicated Fighter HUD Card & Mini Portrait Widget for Aeris Quin (Star Weaver).
    /// </summary>
    public class AerisQuinCardWidget
    {
        public string FighterId { get; } = "aeris_quin";
        public string FighterName { get; } = "Aeris Quin";
        public string ElementTitle { get; } = "Star Weaver";
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
