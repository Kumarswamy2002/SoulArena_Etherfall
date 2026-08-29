using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiVictorySequencer
    {
        public string VictoryPoseClip { get; } = "TorrenKai_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
