using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.UI
{
    public class CombatHUDModel
    {
        public float P1HealthPercent;
        public float P1EtherPercent;
        public float P1GuardPercent;
        public float P1ResonancePercent;
        public bool P1Awakened;

        public float P2HealthPercent;
        public float P2EtherPercent;
        public float P2GuardPercent;
        public float P2ResonancePercent;
        public bool P2Awakened;

        public int RoundTimerSeconds;
        public int P1RoundsWon;
        public int P2RoundsWon;

        public int ComboCount;
        public float ComboDamage;
        public string AnnouncerText;
    }

    /// <summary>
    /// Presenter driving the in-match combat UI elements, health bars, ether meters, and combo counters.
    /// </summary>
    public class CombatHUDController
    {
        public CombatHUDModel ViewModel { get; private set; } = new CombatHUDModel();

        public void BindMatch(MatchCoordinator match)
        {
            EventManager.Subscribe<ComboCountUpdatedEvent>(OnComboUpdated);
            EventManager.Subscribe<GuardBreakEvent>(OnGuardBroken);
            EventManager.Subscribe<AwakeningActivatedEvent>(OnAwakeningActivated);
        }

        public void UpdateHUD(FighterBase p1, FighterBase p2, GameModeBase mode)
        {
            if (p1 != null)
            {
                ViewModel.P1HealthPercent = p1.CurrentHealth / p1.CurrentStats.MaxHealth;
                ViewModel.P1EtherPercent = p1.Ether.CurrentEther / p1.Ether.MaxEther;
                ViewModel.P1GuardPercent = p1.Defense.CurrentGuard / p1.Defense.MaxGuard;
                ViewModel.P1ResonancePercent = p1.Resonance.CurrentResonance / p1.Resonance.MaxResonance;
                ViewModel.P1Awakened = p1.Awakening.IsAwakened;
            }

            if (p2 != null)
            {
                ViewModel.P2HealthPercent = p2.CurrentHealth / p2.CurrentStats.MaxHealth;
                ViewModel.P2EtherPercent = p2.Ether.CurrentEther / p2.Ether.MaxEther;
                ViewModel.P2GuardPercent = p2.Defense.CurrentGuard / p2.Defense.MaxGuard;
                ViewModel.P2ResonancePercent = p2.Resonance.CurrentResonance / p2.Resonance.MaxResonance;
                ViewModel.P2Awakened = p2.Awakening.IsAwakened;
            }

            if (mode != null)
            {
                ViewModel.RoundTimerSeconds = (int)Math.Ceiling(mode.RoundTimer);
                ViewModel.P1RoundsWon = mode.Player1RoundsWon;
                ViewModel.P2RoundsWon = mode.Player2RoundsWon;
            }
        }

        private void OnComboUpdated(ComboCountUpdatedEvent e)
        {
            ViewModel.ComboCount = e.HitCount;
            ViewModel.ComboDamage = e.TotalDamage;
        }

        private void OnGuardBroken(GuardBreakEvent e)
        {
            ViewModel.AnnouncerText = "GUARD BREAK!";
        }

        private void OnAwakeningActivated(AwakeningActivatedEvent e)
        {
            ViewModel.AnnouncerText = $"{e.Element} AWAKENING!";
        }
    }
}
