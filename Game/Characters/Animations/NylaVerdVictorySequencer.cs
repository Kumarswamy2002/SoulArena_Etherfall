using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Nyla Verd (Wild Caller).
    /// </summary>
    public class NylaVerdVictorySequencer
    {
        public string VictoryPoseClip { get; } = "NylaVerd_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
