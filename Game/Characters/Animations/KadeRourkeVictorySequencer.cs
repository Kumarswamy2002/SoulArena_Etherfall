using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Kade Rourke (Iron Marauder).
    /// </summary>
    public class KadeRourkeVictorySequencer
    {
        public string VictoryPoseClip { get; } = "KadeRourke_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
