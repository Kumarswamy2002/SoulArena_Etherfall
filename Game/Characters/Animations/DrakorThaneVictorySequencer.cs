using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Drakor Thane (Iron Colossus).
    /// </summary>
    public class DrakorThaneVictorySequencer
    {
        public string VictoryPoseClip { get; } = "DrakorThane_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
