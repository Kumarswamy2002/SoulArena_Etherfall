using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Phases
{
    /// <summary>
    /// 3-Phase Dynamic Stage Transition Manager for RiftObservatory.
    /// Phase 2 Event: Anti-Gravity Well Inverts
    /// Phase 3 Event: Quantum Rifts Multiply
    /// </summary>
    public class RiftObservatoryPhaseManager
    {
        public int CurrentStagePhase { get; private set; } = 1;
        public float PhaseTransitionTimer { get; private set; } = 0.0f;

        public event Action<int, string> OnStagePhaseAdvanced;

        public void CheckPhaseTransition(float player1HealthRatio, float player2HealthRatio)
        {
            float minHealth = Math.Min(player1HealthRatio, player2HealthRatio);

            if (CurrentStagePhase == 1 && minHealth <= 0.65f)
            {
                CurrentStagePhase = 2;
                OnStagePhaseAdvanced?.Invoke(2, "RiftObservatory Phase 2: Anti-Gravity Well Inverts");
            }
            else if (CurrentStagePhase == 2 && minHealth <= 0.30f)
            {
                CurrentStagePhase = 3;
                OnStagePhaseAdvanced?.Invoke(3, "RiftObservatory Phase 3 (Climax): Quantum Rifts Multiply");
            }
        }
    }
}
