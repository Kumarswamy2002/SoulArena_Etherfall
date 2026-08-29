using System;
using SoulArena.Core;

namespace SoulArena.Arenas.Phases
{
    /// <summary>
    /// 3-Phase Dynamic Stage Transition Manager for SoulforgeColiseum.
    /// Phase 2 Event: Core Ring Fractures
    /// Phase 3 Event: Primordial Ether Erupts
    /// </summary>
    public class SoulforgeColiseumPhaseManager
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
                OnStagePhaseAdvanced?.Invoke(2, "SoulforgeColiseum Phase 2: Core Ring Fractures");
            }
            else if (CurrentStagePhase == 2 && minHealth <= 0.30f)
            {
                CurrentStagePhase = 3;
                OnStagePhaseAdvanced?.Invoke(3, "SoulforgeColiseum Phase 3 (Climax): Primordial Ether Erupts");
            }
        }
    }
}
