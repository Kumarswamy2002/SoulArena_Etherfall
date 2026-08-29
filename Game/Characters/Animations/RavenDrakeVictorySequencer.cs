using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeVictorySequencer
    {
        public string VictoryPoseClip { get; } = "RavenDrake_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
