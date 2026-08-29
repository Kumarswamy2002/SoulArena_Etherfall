using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelVictorySequencer
    {
        public string VictoryPoseClip { get; } = "MorvanKreel_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
