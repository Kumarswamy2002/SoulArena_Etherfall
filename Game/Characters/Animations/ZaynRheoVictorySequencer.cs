using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Zayn Rheo (Lightning Phantom).
    /// </summary>
    public class ZaynRheoVictorySequencer
    {
        public string VictoryPoseClip { get; } = "ZaynRheo_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
