using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Kael Varyn (Stormbound).
    /// </summary>
    public class KaelVarynVictorySequencer
    {
        public string VictoryPoseClip { get; } = "KaelVaryn_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
