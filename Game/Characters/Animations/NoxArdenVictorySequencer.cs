using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Nox Arden (Riftborn).
    /// </summary>
    public class NoxArdenVictorySequencer
    {
        public string VictoryPoseClip { get; } = "NoxArden_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
