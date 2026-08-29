using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideVictorySequencer
    {
        public string VictoryPoseClip { get; } = "MiraTide_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
