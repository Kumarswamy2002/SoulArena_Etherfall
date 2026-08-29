using System;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Characters;

namespace SoulArena.Characters.Ultimates
{
    /// <summary>
    /// Cinematic Ultimate Finisher Sequence & Damage Pipeline for Drakor Thane (Iron Colossus).
    /// Element: Stone
    /// </summary>
    public class DrakorThaneUltimateFinisher
    {
        public string FighterId { get; } = "drakor_thane";
        public bool IsCinematicActive { get; private set; } = false;
        public float CinematicElapsedSeconds { get; private set; } = 0.0f;
        public const float CINEMATIC_TOTAL_DURATION = 3.2f;

        public event Action<string> OnCinematicStarted;
        public event Action<float> OnCinematicDamageTick;
        public event Action OnCinematicFinished;

        public void TriggerUltimateCinematic(FighterBase attacker, FighterBase defender)
        {
            IsCinematicActive = true;
            CinematicElapsedSeconds = 0.0f;
            OnCinematicStarted?.Invoke("drakor_thane_ultimate_cinematic");
        }

        public void UpdateCinematic(float deltaTime, FighterBase attacker, FighterBase defender)
        {
            if (!IsCinematicActive) return;

            CinematicElapsedSeconds += deltaTime;
            if (CinematicElapsedSeconds >= 1.5f && CinematicElapsedSeconds - deltaTime < 1.5f)
            {
                float damage = 280.0f;
                defender.TakeDirectDamage(damage, "drakor_thane_Ultimate_Impact");
                OnCinematicDamageTick?.Invoke(damage);
            }

            if (CinematicElapsedSeconds >= CINEMATIC_TOTAL_DURATION)
            {
                IsCinematicActive = false;
                OnCinematicFinished?.Invoke();
            }
        }
    }
}
