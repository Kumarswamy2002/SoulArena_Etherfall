using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossVictorySequencer
    {
        public string VictoryPoseClip { get; } = "RykaVoss_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
