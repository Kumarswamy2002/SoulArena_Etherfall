using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Dialogue
{
    /// <summary>
    /// Interactive Match Dialogue & Taunt Sound Cues for Torren Kai (Wind Dancer).
    /// </summary>
    public static class TorrenKaiDialogueTree
    {
        public static readonly Dictionary<string, string> MatchupQuotes = new Dictionary<string, string>
        {
            ["vs_mirror"] = "Another reflection of the Gale? Let us see whose resolve burns brighter.",
            ["vs_rival"] = "Your techniques are predictable. Prepare yourself.",
            ["vs_boss"] = "Even the First Soul can fall to mortal conviction.",
            ["round_win"] = "The path of the Wind Dancer never falters.",
            ["match_climax"] = "This ends now! Etherfall!"
        };

        public static string GetMatchupQuote(string key)
        {
            if (MatchupQuotes.TryGetValue(key, out var quote))
            {
                return quote;
            }
            return "For the Soulforge!";
        }
    }
}
