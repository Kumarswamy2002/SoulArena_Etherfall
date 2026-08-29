using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Aeris Quin (Star Weaver).
    /// </summary>
    public class AerisQuinVictorySequencer
    {
        public string VictoryPoseClip { get; } = "AerisQuin_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
