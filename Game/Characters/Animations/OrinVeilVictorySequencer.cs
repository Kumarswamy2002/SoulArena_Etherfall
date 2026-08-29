using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilVictorySequencer
    {
        public string VictoryPoseClip { get; } = "OrinVeil_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
