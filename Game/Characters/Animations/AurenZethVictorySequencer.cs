using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethVictorySequencer
    {
        public string VictoryPoseClip { get; } = "AurenZeth_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
