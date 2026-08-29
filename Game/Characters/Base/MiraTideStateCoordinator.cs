using System;
using SoulArena.Core;

namespace SoulArena.Characters.Base
{
    /// <summary>
    /// Stance & State Coordinator for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideStateCoordinator
    {
        public int FighterId { get; set; }
        public bool InSpecialStance { get; set; } = false;
        public float StanceTimer { get; set; } = 0.0f;

        public void ToggleStance(bool active, float duration)
        {
            InSpecialStance = active;
            StanceTimer = duration;
        }

        public void Update(float deltaTime)
        {
            if (InSpecialStance)
            {
                StanceTimer -= deltaTime;
                if (StanceTimer <= 0.0f)
                {
                    InSpecialStance = false;
                }
            }
        }
    }
}
