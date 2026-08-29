using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SoulArena.Core
{
    [Serializable]
    public class GameSettingsData
    {
        public int ResolutionWidth = 1920;
        public int ResolutionHeight = 1080;
        public bool Fullscreen = true;
        public int TargetFramerate = 60;
        public bool VSync = true;

        public float MasterVolume = 1.0f;
        public float MusicVolume = 0.8f;
        public float SfxVolume = 0.9f;
        public float VoiceVolume = 1.0f;

        public float CameraSensitivity = 1.0f;
        public bool ScreenShakeEnabled = true;
        public bool DamageNumbersEnabled = true;
        public bool InputDisplayEnabled = true;

        public int MaxRollbackFrames = 8;
        public int NetworkInterpolationDelayMs = 20;
    }

    [Serializable]
    public class PlayerSaveData
    {
        public string PlayerId;
        public string Username;
        public int Level = 1;
        public int Experience = 0;
        public int RankedRating = 1200; // Starting MMR
        public int MatchesPlayed = 0;
        public int MatchesWon = 0;
        public int HighestComboStreak = 0;
        public float TotalDamageDealt = 0.0f;
        
        public string[] UnlockedFighterIds = new string[0];
        public string[] UnlockedArenaIds = new string[0];
        public string[] UnlockedAchievementIds = new string[0];
        public string Checksum = string.Empty;
    }

    /// <summary>
    /// Save system with HMAC SHA-256 tamper-proof verification for game progression.
    /// </summary>
    public static class SaveSystem
    {
        private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("SoulArenaEtherfallSecretKey2026!");

        public static string ComputeChecksum(string data)
        {
            using (var hmac = new HMACSHA256(EncryptionKey))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hash);
            }
        }

        public static bool ValidateSave(PlayerSaveData data, string rawJsonWithoutChecksum)
        {
            string expected = ComputeChecksum(rawJsonWithoutChecksum);
            return string.Equals(expected, data.Checksum, StringComparison.Ordinal);
        }
    }
}
