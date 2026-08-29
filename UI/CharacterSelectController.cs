using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.UI
{
    public class CharacterSelectController
    {
        public List<FighterDefinition> AvailableFighters { get; private set; } = new List<FighterDefinition>();
        
        public int P1SelectedIndex { get; private set; } = 0;
        public int P2SelectedIndex { get; private set; } = 1;
        
        public bool P1LockedIn { get; private set; } = false;
        public bool P2LockedIn { get; private set; } = false;

        public event Action<FighterDefinition, int> OnFighterHovered;
        public event Action<FighterDefinition, int> OnFighterLocked;
        public event Action<string, string> OnBothFightersSelected;

        public CharacterSelectController()
        {
            AvailableFighters.AddRange(FighterRoster.GetAllFighters());
        }

        public void MoveP1Cursor(int direction)
        {
            if (P1LockedIn || AvailableFighters.Count == 0) return;
            P1SelectedIndex = (P1SelectedIndex + direction + AvailableFighters.Count) % AvailableFighters.Count;
            OnFighterHovered?.Invoke(AvailableFighters[P1SelectedIndex], 1);
        }

        public void MoveP2Cursor(int direction)
        {
            if (P2LockedIn || AvailableFighters.Count == 0) return;
            P2SelectedIndex = (P2SelectedIndex + direction + AvailableFighters.Count) % AvailableFighters.Count;
            OnFighterHovered?.Invoke(AvailableFighters[P2SelectedIndex], 2);
        }

        public void ConfirmP1Selection()
        {
            if (P1LockedIn) return;
            P1LockedIn = true;
            OnFighterLocked?.Invoke(AvailableFighters[P1SelectedIndex], 1);
            CheckBothConfirmed();
        }

        public void ConfirmP2Selection()
        {
            if (P2LockedIn) return;
            P2LockedIn = true;
            OnFighterLocked?.Invoke(AvailableFighters[P2SelectedIndex], 2);
            CheckBothConfirmed();
        }

        private void CheckBothConfirmed()
        {
            if (P1LockedIn && P2LockedIn)
            {
                OnBothFightersSelected?.Invoke(
                    AvailableFighters[P1SelectedIndex].FighterId,
                    AvailableFighters[P2SelectedIndex].FighterId
                );
            }
        }
    }
}
