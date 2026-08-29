using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Seren Vale (Frozen Blade).
    /// </summary>
    public class SerenValeVictorySequencer
    {
        public string VictoryPoseClip { get; } = "SerenVale_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
