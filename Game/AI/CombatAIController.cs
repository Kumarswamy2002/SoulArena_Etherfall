using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.AI
{
    /// <summary>
    /// Utility-based Combat AI evaluating spatial range, frame advantage, resource levels, and opponent vulnerabilities.
    /// Generates frame-accurate virtual inputs for the FighterBase controller.
    /// </summary>
    public class CombatAIController
    {
        public FighterBase ControlledFighter { get; private set; }
        public FighterBase TargetOpponent { get; private set; }

        public AIPersonalityProfile Personality { get; set; }
        public AIDifficultyProfile Difficulty { get; set; }

        private readonly Random _rng = new Random();
        private int _actionCooldownFrames = 0;
        private int _reactionDelayRemaining = 0;

        public CombatAIController(FighterBase fighter, AIPersonality personality = AIPersonality.Tactical, AIDifficulty difficulty = AIDifficulty.Normal)
        {
            ControlledFighter = fighter ?? throw new ArgumentNullException(nameof(fighter));
            Personality = AIProfileDatabase.GetPersonality(personality);
            Difficulty = AIProfileDatabase.GetDifficulty(difficulty);
        }

        public void SetTarget(FighterBase opponent)
        {
            TargetOpponent = opponent;
        }

        public void UpdateDecision(long currentFrame)
        {
            if (ControlledFighter == null || ControlledFighter.IsDead) return;
            if (TargetOpponent == null || TargetOpponent.IsDead) return;

            if (_reactionDelayRemaining > 0)
            {
                _reactionDelayRemaining--;
                return;
            }

            if (_actionCooldownFrames > 0)
            {
                _actionCooldownFrames--;
            }

            // 1. Calculate spatial delta & direction to opponent
            float deltaX = TargetOpponent.Position.X - ControlledFighter.Position.X;
            float distance = Math.Abs(deltaX);
            bool opponentIsRight = deltaX > 0;
            ControlledFighter.FacingRight = opponentIsRight;

            var inputFrame = new InputFrame
            {
                FrameNumber = currentFrame,
                MovementX = 0,
                MovementY = 0,
                ButtonsPressed = InputButton.None,
                ButtonsHeld = InputButton.None
            };

            // 2. Evaluate Combo Breaker during opponent combo
            if (ControlledFighter.HitstunDurationRemaining > 0.1f && TargetOpponent.ComboTracker.CurrentComboHits >= 3)
            {
                if (_rng.NextDouble() < Personality.ComboBreakerReadiness)
                {
                    if (ControlledFighter.ComboTracker.TryExecuteComboBreaker(ControlledFighter.Ether.CurrentEther, ControlledFighter.Resonance.CurrentResonance, out float eCost, out float rCost))
                    {
                        ControlledFighter.Ether.TryConsume(eCost);
                        ControlledFighter.Resonance.TryConsumeResonance(rCost);
                        inputFrame.ButtonsPressed |= InputButton.BurstEscape;
                        ControlledFighter.Input.PushFrame(inputFrame);
                        return;
                    }
                }
            }

            // 3. Evaluate Awakening Activation
            if (ControlledFighter.Resonance.IsAwakeningReady && !ControlledFighter.Awakening.IsAwakened)
            {
                if (_rng.NextDouble() < Personality.AwakeningUrgencyWeight)
                {
                    ControlledFighter.Awakening.TryActivateAwakening(ControlledFighter.Resonance);
                    inputFrame.ButtonsPressed |= InputButton.Awaken;
                    ControlledFighter.Input.PushFrame(inputFrame);
                    return;
                }
            }

            // 4. Evaluate Ultimate Execution
            if (ControlledFighter.Awakening.IsAwakened && ControlledFighter.Awakening.CanExecuteUltimate(ControlledFighter.Ether))
            {
                if (distance <= 4.0f && TargetOpponent.HitstunDurationRemaining > 0.0f)
                {
                    // Confirm ultimate on hitstun
                    inputFrame.ButtonsPressed |= InputButton.Ultimate;
                    ControlledFighter.Input.PushFrame(inputFrame);
                    return;
                }
            }

            // 5. Evaluate Defense (Blocking / Dodging / Parrying when opponent is attacking)
            if (TargetOpponent.ActiveMove != null && distance <= 3.5f)
            {
                if (_rng.NextDouble() < Difficulty.DefenseSuccessRate)
                {
                    if (Difficulty.CanPerformPerfectParries && _rng.NextDouble() < Personality.ParryAttemptWeight)
                    {
                        ControlledFighter.Defense.StartParry();
                    }
                    else if (_rng.NextDouble() < Personality.DefensiveGuardWeight)
                    {
                        ControlledFighter.Defense.StartBlocking();
                        inputFrame.ButtonsHeld |= InputButton.Block;
                    }
                    else
                    {
                        ControlledFighter.Defense.StartDodge();
                        inputFrame.ButtonsPressed |= InputButton.Dodge;
                    }
                    ControlledFighter.Input.PushFrame(inputFrame);
                    return;
                }
            }
            else
            {
                ControlledFighter.Defense.StopBlocking();
            }

            // 6. Evaluate Offense & Spacing Movement
            if (_actionCooldownFrames <= 0 && ControlledFighter.ActiveMove == null)
            {
                if (distance > Personality.SpacingPreferredDistance)
                {
                    // Advance towards opponent
                    inputFrame.MovementX = opponentIsRight ? 1.0f : -1.0f;
                    ControlledFighter.Velocity = new Vector3D(inputFrame.MovementX * ControlledFighter.CurrentStats.MoveSpeed, ControlledFighter.Velocity.Y, 0);
                }
                else
                {
                    // In striking range -> Choose attack
                    if (_rng.NextDouble() < Personality.AggressivenessWeight)
                    {
                        string id = ControlledFighter.Definition.FighterId;
                        
                        // Decide between special ability or normal chain
                        if (_rng.NextDouble() < Personality.AbilityUsageWeight && ControlledFighter.Abilities.IsAbilityReady($"{id}_special1", ControlledFighter.Ether, ControlledFighter.Status))
                        {
                            if (ControlledFighter.Abilities.TryCastAbility($"{id}_special1", ControlledFighter.Ether, ControlledFighter.Awakening, ControlledFighter.Status, out var ability))
                            {
                                inputFrame.ButtonsPressed |= InputButton.Special1;
                                _actionCooldownFrames = Difficulty.ReactionLatencyFrames;
                            }
                        }
                        else
                        {
                            // Trigger Light Attack chain starter
                            var starterMove = ControlledFighter.Moves.GetMove($"{id}_light1");
                            if (starterMove != null)
                            {
                                ControlledFighter.StartMove(starterMove);
                                inputFrame.ButtonsPressed |= InputButton.LightAttack;
                                _actionCooldownFrames = Difficulty.ReactionLatencyFrames;
                            }
                        }
                    }
                }
            }

            ControlledFighter.Input.PushFrame(inputFrame);
        }
    }
}
