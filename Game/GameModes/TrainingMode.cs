using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Match;

namespace SoulArena.GameModes
{
    public enum DummyState
    {
        StandStill,
        CrouchBlock,
        JumpInPlace,
        AutoGuardAfterFirstHit,
        RandomDodge,
        AggressiveCounter
    }

    public class TrainingMode : GameModeBase
    {
        public override GameModeType ModeType => GameModeType.Training;
        public DummyState DummyAction { get; set; } = DummyState.StandStill;
        public bool InfiniteEther { get; set; } = true;
        public bool InfiniteResonance { get; set; } = true;
        public bool AutoRecoverHealth { get; set; } = true;

        public override void Update(float deltaTime, FighterBase p1, FighterBase p2)
        {
            if (p1 == null || p2 == null) return;
            CurrentPhase = RoundPhase.CombatActive;
            RoundTimer = 999.0f; // Infinite time

            if (InfiniteEther)
            {
                p1.Ether.AddEther(100.0f);
            }

            if (InfiniteResonance)
            {
                p1.Resonance.AddResonance(100.0f);
            }

            if (AutoRecoverHealth && p2.ComboTracker.CurrentComboHits == 0 && p2.HitstunDurationRemaining <= 0.0f)
            {
                // Reset dummy health when combo ends
                if (p2.CurrentHealth < p2.CurrentStats.MaxHealth)
                {
                    p2.ResetFighterForNewRound(p2.Position, p2.FacingRight);
                }
            }
        }
    }

    public class SurvivalMode : GameModeBase
    {
        public override GameModeType ModeType => GameModeType.Survival;
        public int CurrentWave { get; private set; } = 1;
        public int EnemiesDefeated { get; private set; } = 0;
        public float Score { get; private set; } = 0.0f;

        public override void Update(float deltaTime, FighterBase p1, FighterBase p2)
        {
            if (p1 == null || p2 == null) return;

            if (p1.IsDead)
            {
                CurrentPhase = RoundPhase.MatchFinished;
                EventManager.Publish(new MatchEndedEvent { WinnerId = 2, Result = MatchResult.Player2Victory });
                return;
            }

            if (p2.IsDead)
            {
                EnemiesDefeated++;
                Score += (1000 * CurrentWave) + (p1.CurrentHealth * 2);
                CurrentWave++;
                
                // Heal player for 20% max health on wave clear
                float heal = p1.CurrentStats.MaxHealth * 0.20f;
                p1.TakeDirectDamage(-heal, "WaveClearHeal");

                // Spawn next enemy wave
                p2.ResetFighterForNewRound(new Vector3D(8.0f, 0, 0), facingRight: false);
            }
        }
    }

    public class TournamentMode : GameModeBase
    {
        public override GameModeType ModeType => GameModeType.Tournament;
        public int BracketRound { get; private set; } = 1; // 1 = Quarterfinals, 2 = Semifinals, 3 = Grand Finals
        public string[] BracketFighters { get; private set; } = new string[8];

        public TournamentMode(string[] rosterIds)
        {
            if (rosterIds != null && rosterIds.Length >= 8)
            {
                Array.Copy(rosterIds, BracketFighters, 8);
            }
        }

        public override void Update(float deltaTime, FighterBase p1, FighterBase p2)
        {
            if (p1 == null || p2 == null) return;

            if (p1.IsDead || p2.IsDead)
            {
                CurrentPhase = RoundPhase.MatchFinished;
                int winner = p1.IsDead ? 2 : 1;
                EventManager.Publish(new MatchEndedEvent { WinnerId = winner, Result = winner == 1 ? MatchResult.Player1Victory : MatchResult.Player2Victory });
            }
        }
    }
}
