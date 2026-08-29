using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Phases
{
    /// <summary>
    /// 3-Phase Dynamic Stage Transition Manager for IronHarbor.
    /// Phase 2 Event: Cargo Crane Drops Container
    /// Phase 3 Event: High-Voltage Cables Sever
    /// </summary>
    public class IronHarborPhaseManager
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
                OnStagePhaseAdvanced?.Invoke(2, "IronHarbor Phase 2: Cargo Crane Drops Container");
            }
            else if (CurrentStagePhase == 2 && minHealth <= 0.30f)
            {
                CurrentStagePhase = 3;
                OnStagePhaseAdvanced?.Invoke(3, "IronHarbor Phase 3 (Climax): High-Voltage Cables Sever");
            }
        }
    }
}
