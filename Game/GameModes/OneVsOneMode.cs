using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.GameModes
{
    public class OneVsOneMode : GameModeBase
    {
        public override GameModeType ModeType => GameModeType.OneVsOne;

        public OneVsOneMode(int roundsToWin = 2, float roundTime = 99.0f)
        {
            MaxRounds = (roundsToWin * 2) - 1;
            MaxRoundTime = roundTime;
        }

        public override void Update(float deltaTime, FighterBase p1, FighterBase p2)
        {
            if (p1 == null || p2 == null) return;

            if (CurrentPhase == RoundPhase.Intro)
            {
                // Simple 1.5s intro count
                RoundTimer -= deltaTime;
                if (RoundTimer <= MaxRoundTime - 1.5f)
                {
                    StartCombat();
                }
                return;
            }

            if (CurrentPhase == RoundPhase.CombatActive)
            {
                RoundTimer -= deltaTime;

                // Check KO
                if (p1.IsDead || p2.IsDead)
                {
                    EvaluateRoundWinner(p1, p2);
                    return;
                }

                // Check Time Out
                if (RoundTimer <= 0.0f)
                {
                    RoundTimer = 0.0f;
                    EvaluateTimeOutWinner(p1, p2);
                }
            }
        }

        private void EvaluateRoundWinner(FighterBase p1, FighterBase p2)
        {
            CurrentPhase = RoundPhase.RoundEnd;

            if (p1.IsDead && p2.IsDead)
            {
                // Double KO -> Draw, both get round
                Player1RoundsWon++;
                Player2RoundsWon++;
            }
            else if (p1.IsDead)
            {
                Player2RoundsWon++;
            }
            else
            {
                Player1RoundsWon++;
            }

            CheckMatchVictory();
        }

        private void EvaluateTimeOutWinner(FighterBase p1, FighterBase p2)
        {
            CurrentPhase = RoundPhase.RoundEnd;

            if (p1.CurrentHealth > p2.CurrentHealth)
            {
                Player1RoundsWon++;
            }
            else if (p2.CurrentHealth > p1.CurrentHealth)
            {
                Player2RoundsWon++;
            }
            else
            {
                // Equal health draw
                Player1RoundsWon++;
                Player2RoundsWon++;
            }

            CheckMatchVictory();
        }

        private void CheckMatchVictory()
        {
            int targetWins = (MaxRounds / 2) + 1;

            if (Player1RoundsWon >= targetWins && Player2RoundsWon >= targetWins)
            {
                CurrentPhase = RoundPhase.MatchFinished;
                EventManager.Publish(new MatchEndedEvent { WinnerId = 0, Result = MatchResult.Draw });
            }
            else if (Player1RoundsWon >= targetWins)
            {
                CurrentPhase = RoundPhase.MatchFinished;
                EventManager.Publish(new MatchEndedEvent { WinnerId = 1, Result = MatchResult.Player1Victory });
            }
            else if (Player2RoundsWon >= targetWins)
            {
                CurrentPhase = RoundPhase.MatchFinished;
                EventManager.Publish(new MatchEndedEvent { WinnerId = 2, Result = MatchResult.Player2Victory });
            }
        }
    }
}
