using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SoulArena.Core;

namespace SoulArena.Replay
{
    [Serializable]
    public class ReplayMetadata
    {
        public string MatchId;
        public string Player1Name;
        public string Player2Name;
        public string Player1FighterId;
        public string Player2FighterId;
        public ArenaId Arena;
        public int RandomSeed;
        public long TotalFrames;
        public string RecordedTimestamp;
        public string GameVersion = "1.0.0";
    }

    [Serializable]
    public class ReplayInputEntry
    {
        public long FrameNumber;
        public InputFrame P1Input;
        public InputFrame P2Input;
    }

    [Serializable]
    public class ReplayData
    {
        public ReplayMetadata Metadata = new ReplayMetadata();
        public List<ReplayInputEntry> RecordedFrames = new List<ReplayInputEntry>();
    }

    /// <summary>
    /// Frame-accurate deterministic replay recorder and playback engine.
    /// Captures raw input frames for instant rollback re-simulation and lightweight sharing.
    /// </summary>
    public class ReplaySystem
    {
        public ReplayData ActiveReplay { get; private set; }
        public bool IsRecording { get; private set; }
        public bool IsPlayingBack { get; private set; }
        public int PlaybackIndex { get; private set; }

        public void StartRecording(string matchId, string p1Name, string p2Name, string p1Fighter, string p2Fighter, ArenaId arena, int seed)
        {
            ActiveReplay = new ReplayData
            {
                Metadata = new ReplayMetadata
                {
                    MatchId = matchId,
                    Player1Name = p1Name,
                    Player2Name = p2Name,
                    Player1FighterId = p1Fighter,
                    Player2FighterId = p2Fighter,
                    Arena = arena,
                    RandomSeed = seed,
                    RecordedTimestamp = DateTime.UtcNow.ToString("o")
                }
            };
            IsRecording = true;
            IsPlayingBack = false;
        }

        public void RecordFrame(long frameNumber, InputFrame p1Input, InputFrame p2Input)
        {
            if (!IsRecording || ActiveReplay == null) return;

            ActiveReplay.RecordedFrames.Add(new ReplayInputEntry
            {
                FrameNumber = frameNumber,
                P1Input = p1Input,
                P2Input = p2Input
            });
            ActiveReplay.Metadata.TotalFrames = frameNumber;
        }

        public void StopRecording()
        {
            IsRecording = false;
        }

        public void StartPlayback(ReplayData replay)
        {
            ActiveReplay = replay ?? throw new ArgumentNullException(nameof(replay));
            IsRecording = false;
            IsPlayingBack = true;
            PlaybackIndex = 0;
        }

        public bool GetNextPlaybackFrame(out InputFrame p1Input, out InputFrame p2Input)
        {
            p1Input = default;
            p2Input = default;

            if (!IsPlayingBack || ActiveReplay == null) return false;
            if (PlaybackIndex >= ActiveReplay.RecordedFrames.Count)
            {
                IsPlayingBack = false;
                return false;
            }

            var entry = ActiveReplay.RecordedFrames[PlaybackIndex];
            p1Input = entry.P1Input;
            p2Input = entry.P2Input;
            PlaybackIndex++;
            return true;
        }

        public string SerializeToJson()
        {
            if (ActiveReplay == null) return "{}";
            // Simple structured serializer representation
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\"match_id\":\"{ActiveReplay.Metadata.MatchId}\",");
            sb.Append($"\"p1_fighter\":\"{ActiveReplay.Metadata.Player1FighterId}\",");
            sb.Append($"\"p2_fighter\":\"{ActiveReplay.Metadata.Player2FighterId}\",");
            sb.Append($"\"arena\":\"{ActiveReplay.Metadata.Arena}\",");
            sb.Append($"\"total_frames\":{ActiveReplay.Metadata.TotalFrames},");
            sb.Append($"\"frame_count\":{ActiveReplay.RecordedFrames.Count}");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
