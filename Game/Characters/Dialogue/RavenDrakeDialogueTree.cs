using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Dialogue
{
    /// <summary>
    /// Interactive Match Dialogue & Taunt Sound Cues for Raven Drake (Blood Knight).
    /// </summary>
    public static class RavenDrakeDialogueTree
    {
        public static readonly Dictionary<string, string> MatchupQuotes = new Dictionary<string, string>
        {
            ["vs_mirror"] = "Another reflection of the Crimson? Let us see whose resolve burns brighter.",
            ["vs_rival"] = "Your techniques are predictable. Prepare yourself.",
            ["vs_boss"] = "Even the First Soul can fall to mortal conviction.",
            ["round_win"] = "The path of the Blood Knight never falters.",
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
