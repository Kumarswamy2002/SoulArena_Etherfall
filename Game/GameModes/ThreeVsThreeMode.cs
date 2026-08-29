using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.GameModes
{
    /// <summary>
    /// ThreeVsThreeMode: 3v3 King of the Hill elimination tournament match format
    /// </summary>
    public class ThreeVsThreeMode : GameModeBase
    {
        public override GameModeType ModeType => GameModeType.OneVsOne;

        public ThreeVsThreeMode()
        {
            MaxRoundTime = 99.0f;
            MaxRounds = 3;
        }

        public override void Update(float deltaTime, FighterBase p1, FighterBase p2)
        {
            if (p1 == null || p2 == null) return;
            if (CurrentPhase == RoundPhase.CombatActive)
            {
                RoundTimer -= deltaTime;
                if (p1.IsDead || p2.IsDead || RoundTimer <= 0.0f)
                {
                    CurrentPhase = RoundPhase.MatchFinished;
                    int winner = p1.IsDead ? 2 : 1;
                    EventManager.Publish(new MatchEndedEvent
                    {
                        WinnerId = winner,
                        Result = winner == 1 ? MatchResult.Player1Victory : MatchResult.Player2Victory
                    });
                }
            }
        }
    }
}
