using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Arenas;
using SoulArena.Combat;

namespace SoulArena.Match
{
    public enum RoundPhase
    {
        Intro,
        CombatActive,
        RoundEnd,
        MatchFinished
    }

    public abstract class GameModeBase
    {
        public abstract GameModeType ModeType { get; }
        public RoundPhase CurrentPhase { get; protected set; } = RoundPhase.Intro;
        
        public int CurrentRound { get; protected set; } = 1;
        public int MaxRounds { get; protected set; } = 3;
        public float RoundTimer { get; protected set; } = 99.0f;
        public float MaxRoundTime { get; protected set; } = 99.0f;
        
        public int Player1RoundsWon { get; protected set; } = 0;
        public int Player2RoundsWon { get; protected set; } = 0;

        public event Action<RoundPhase> OnPhaseChanged;
        public event Action<int, float> OnRoundTimerUpdated;
        public event Action<MatchResult> OnMatchCompleted;

        public virtual void Initialize(ArenaController arena)
        {
            CurrentRound = 1;
            Player1RoundsWon = 0;
            Player2RoundsWon = 0;
            StartIntro();
        }

        public virtual void StartIntro()
        {
            CurrentPhase = RoundPhase.Intro;
            RoundTimer = MaxRoundTime;
            OnPhaseChanged?.Invoke(CurrentPhase);
        }

        public virtual void StartCombat()
        {
            CurrentPhase = RoundPhase.CombatActive;
            OnPhaseChanged?.Invoke(CurrentPhase);
        }

        public abstract void Update(float deltaTime, FighterBase p1, FighterBase p2);
        
        public virtual void ResetRound(FighterBase p1, FighterBase p2, ArenaController arena)
        {
            RoundTimer = MaxRoundTime;
            CurrentPhase = RoundPhase.Intro;
            p1?.ResetFighterForNewRound(arena.Definition.Player1Spawn, facingRight: true);
            p2?.ResetFighterForNewRound(arena.Definition.Player2Spawn, facingRight: false);
            OnPhaseChanged?.Invoke(CurrentPhase);
        }
    }
}
