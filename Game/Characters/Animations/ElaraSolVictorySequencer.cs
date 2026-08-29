using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Elara Sol (Dawn Saint).
    /// </summary>
    public class ElaraSolVictorySequencer
    {
        public string VictoryPoseClip { get; } = "ElaraSol_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
