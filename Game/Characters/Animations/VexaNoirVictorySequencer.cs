using System;
using SoulArena.Core;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Victory Pose & Match Outro Sequencer for Vexa Noir (Void Walker).
    /// </summary>
    public class VexaNoirVictorySequencer
    {
        public string VictoryPoseClip { get; } = "VexaNoir_Victory_Pose";
        public float SequenceDuration { get; set; } = 4.0f;

        public void PlayVictorySequence()
        {
        }
    }
}
