using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkVictorySequencer
    {
        public string VictoryPoseClip { get; } = "SolanArk_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
