using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Arenas;
using SoulArena.AI;
using SoulArena.Combat;

namespace SoulArena.Match
{
    /// <summary>
    /// Master coordinator running active matches, updating fighters, processing AI, and evaluating game mode rules.
    /// </summary>
    public class MatchCoordinator
    {
        public ArenaController CurrentArena { get; private set; }
        public GameModeBase ActiveGameMode { get; private set; }
        
        public FighterBase Player1 { get; private set; }
        public FighterBase Player2 { get; private set; }
        
        public CombatAIController AIPlayer1 { get; private set; }
        public CombatAIController AIPlayer2 { get; private set; }

        public FrameTimer MatchTimer { get; private set; } = new FrameTimer();
        public MatchResult Result { get; private set; } = MatchResult.InProgress;

        public event Action<HitResult> OnCombatHitProcessed;

        public void SetupMatch(string p1FighterId, string p2FighterId, ArenaId arenaId, GameModeBase gameMode, bool p1IsAI = false, bool p2IsAI = true)
        {
            CurrentArena = ArenaFactory.CreateArenaInstance(arenaId);
            ActiveGameMode = gameMode;

            Player1 = FighterRoster.CreateFighterInstance(1, p1FighterId);
            Player2 = FighterRoster.CreateFighterInstance(2, p2FighterId);

            Player1.Position = CurrentArena.Definition.Player1Spawn;
            Player1.FacingRight = true;

            Player2.Position = CurrentArena.Definition.Player2Spawn;
            Player2.FacingRight = false;

            if (p1IsAI)
            {
                AIPlayer1 = new CombatAIController(Player1, AIPersonality.Balanced.ToString() == "Balanced" ? AIPersonality.Tactical : AIPersonality.Aggressive, AIDifficulty.Normal);
                AIPlayer1.SetTarget(Player2);
            }

            if (p2IsAI)
            {
                AIPlayer2 = new CombatAIController(Player2, AIPersonality.Aggressive, AIDifficulty.Normal);
                AIPlayer2.SetTarget(Player1);
            }

            ActiveGameMode.Initialize(CurrentArena);
            MatchTimer.Reset();
        }

        public void Update(float deltaTime)
        {
            if (ActiveGameMode == null || CurrentArena == null) return;

            MatchTimer.AdvanceFrame();
            if (MatchTimer.IsInHitstop) return; // Simulation frozen during hitstop

            // 1. Update Arena dynamics and hazards
            CurrentArena.Update(deltaTime);

            // 2. AI Decisions
            AIPlayer1?.UpdateDecision(MatchTimer.CurrentFrame);
            AIPlayer2?.UpdateDecision(MatchTimer.CurrentFrame);

            // 3. Update Fighters
            Player1?.Update(deltaTime);
            Player2?.Update(deltaTime);

            // 4. Hitbox & Hurtbox Collision Resolution
            if (ActiveGameMode.CurrentPhase == RoundPhase.CombatActive)
            {
                ProcessCombatCollisions(Player1, Player2);
                ProcessCombatCollisions(Player2, Player1);
            }

            // 5. Update Game Mode state
            ActiveGameMode.Update(deltaTime, Player1, Player2);
        }

        private void ProcessCombatCollisions(FighterBase attacker, FighterBase defender)
        {
            if (attacker == null || defender == null) return;
            if (attacker.ActiveMove == null) return;

            var activeMove = attacker.ActiveMove;
            if (attacker.CurrentMoveFrame >= activeMove.HitboxDefinition.ActiveStartFrame &&
                attacker.CurrentMoveFrame <= activeMove.HitboxDefinition.ActiveEndFrame)
            {
                var hitbox = new Hitbox();
                hitbox.Initialize(activeMove.HitboxDefinition, attacker.Position, attacker.FacingRight);

                foreach (var hurtbox in defender.Hurtboxes)
                {
                    if (HitResolver.CheckHitboxIntersection(hitbox, hurtbox, defender.Position, defender.FacingRight))
                    {
                        if (!hitbox.HasStruckTarget(defender.FighterId))
                        {
                            hitbox.RegisterHit(defender.FighterId);

                            var hitResult = HitResolver.ResolveHit(
                                hitbox,
                                hurtbox,
                                defender.Defense,
                                attacker.Status,
                                defender.Status,
                                attacker.CurrentStats.AttackPower,
                                defender.CurrentStats.DefenseArmor,
                                attacker.ComboTracker.CurrentComboHits,
                                isDefenderCounterState: defender.ActiveMove != null && defender.CurrentMoveFrame < defender.ActiveMove.HitboxDefinition.ActiveStartFrame,
                                isAttackerAwakened: attacker.Awakening.IsAwakened,
                                isDefenderAwakened: defender.Awakening.IsAwakened
                            );

                            if (hitResult.HitConnected)
                            {
                                defender.ApplyDamage(hitResult);
                                attacker.Ether.AddEther(hitResult.EtherGainedAttacker);
                                attacker.Resonance.AddResonance(hitResult.ResonanceGainedAttacker);
                                attacker.ComboTracker.RegisterHit(hitResult);

                                if (hitResult.HitstopFrames > 0)
                                {
                                    MatchTimer.ApplyHitstop(hitResult.HitstopFrames);
                                }

                                OnCombatHitProcessed?.Invoke(hitResult);
                            }
                        }
                    }
                }
            }
        }
    }
}
