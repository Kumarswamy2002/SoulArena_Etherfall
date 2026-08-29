using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenVictorySequencer
    {
        public string VictoryPoseClip { get; } = "RokanFen_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
