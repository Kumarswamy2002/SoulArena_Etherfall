using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Combat;

namespace SoulArena.AI.DecisionTrees
{
    /// <summary>
    /// Individual AI Combat Strategy & Behavior Tree for Auren Zeth (First Soul).
    /// Custom evaluation for PrimeEther elemental abilities and BossAdvanced role spacing.
    /// </summary>
    public class AurenZethBehaviorTree
    {
        public FighterBase Fighter { get; private set; }
        public FighterBase Target { get; private set; }
        public float PreferredNeutralDistance { get; set; } = 2.8f;

        private readonly Random _rng = new Random();

        public AurenZethBehaviorTree(FighterBase fighter, FighterBase target)
        {
            Fighter = fighter ?? throw new ArgumentNullException(nameof(fighter));
            Target = target;
        }

        public InputFrame EvaluateBehaviorTick(long currentFrame)
        {
            var frame = new InputFrame
            {
                FrameNumber = currentFrame,
                MovementX = 0,
                MovementY = 0,
                ButtonsPressed = InputButton.None,
                ButtonsHeld = InputButton.None
            };

            if (Fighter == null || Fighter.IsDead || Target == null || Target.IsDead) return frame;

            float deltaX = Target.Position.X - Fighter.Position.X;
            float dist = Math.Abs(deltaX);
            bool targetRight = deltaX > 0;

            // 1. Evaluate Awakening State
            if (Fighter.Resonance.IsAwakeningReady && !Fighter.Awakening.IsAwakened)
            {
                frame.ButtonsPressed |= InputButton.Awaken;
                return frame;
            }

            // 2. Evaluate Ultimate on hitstun
            if (Fighter.Awakening.IsAwakened && Fighter.Awakening.CanExecuteUltimate(Fighter.Ether))
            {
                if (dist <= 3.8f && Target.HitstunDurationRemaining > 0.0f)
                {
                    frame.ButtonsPressed |= InputButton.Ultimate;
                    return frame;
                }
            }

            // 3. Defense against active enemy moves
            if (Target.ActiveMove != null && dist <= 3.2f)
            {
                if (Fighter.Defense.CurrentGuard > 25.0f)
                {
                    frame.ButtonsHeld |= InputButton.Block;
                }
                else
                {
                    frame.ButtonsPressed |= InputButton.Dodge;
                }
                return frame;
            }

            // 4. Attack or Spacing
            if (dist > PreferredNeutralDistance)
            {
                frame.MovementX = targetRight ? 1.0f : -1.0f;
            }
            else
            {
                // In range
                if (Fighter.ActiveMove == null)
                {
                    if (Fighter.Ether.CurrentEther >= 25.0f && _rng.NextDouble() < 0.40)
                    {
                        frame.ButtonsPressed |= InputButton.Special1;
                    }
                    else
                    {
                        frame.ButtonsPressed |= InputButton.LightAttack;
                    }
                }
            }

            return frame;
        }
    }
}
