using System;
using SoulArena.Core;

namespace SoulArena.Characters.Base
{
    /// <summary>
    /// Stance & State Coordinator for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilStateCoordinator
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
