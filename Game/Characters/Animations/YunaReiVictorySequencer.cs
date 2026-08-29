using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Yuna Rei (Spirit Dancer).
    /// </summary>
    public class YunaReiVictorySequencer
    {
        public string VictoryPoseClip { get; } = "YunaRei_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
