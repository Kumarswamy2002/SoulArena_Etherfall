using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Replay
{
    /// <summary>
    /// ReplayMetadataCatalog: Indexed local storage catalog of match replays with fighter and arena metadata
    /// Part of the core Soul Arena: Etherfall deterministic replay architecture.
    /// </summary>
    public class ReplayMetadataCatalog
    {
        public bool IsActive { get; set; } = true;
        public long CurrentRecordedFrame { get; private set; } = 0;
        public int TotalSnapshotsCaptured { get; private set; } = 0;
        private readonly List<byte[]> _streamChunks = new List<byte[]>();

        public event Action<long, string> OnReplayEventLogged;

        public void InitializeSession(string matchId)
        {
            CurrentRecordedFrame = 0;
            TotalSnapshotsCaptured = 0;
            _streamChunks.Clear();
            OnReplayEventLogged?.Invoke(0, "Session initialized for match " + matchId);
        }

        public void RecordFrameData(long frameNumber, InputFrame p1Input, InputFrame p2Input, uint stateChecksum)
        {
            if (!IsActive) return;
            CurrentRecordedFrame = frameNumber;
            TotalSnapshotsCaptured++;

            // Pack frame delta
            byte[] chunk = new byte[16];
            BitConverter.GetBytes(frameNumber).CopyTo(chunk, 0);
            BitConverter.GetBytes((ushort)p1Input.ButtonsPressed).CopyTo(chunk, 8);
            BitConverter.GetBytes((ushort)p2Input.ButtonsPressed).CopyTo(chunk, 10);
            BitConverter.GetBytes(stateChecksum).CopyTo(chunk, 12);
            _streamChunks.Add(chunk);
        }

        public IReadOnlyList<byte[]> GetSerializedStream() => _streamChunks;
    }
}
