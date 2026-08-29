using System;
using System.Collections.Generic;
using SoulArena.Characters;
using SoulArena.Combos;
using SoulArena.Abilities;

namespace SoulArena.Tools
{
    /// <summary>
    /// In-engine/Editor Tool for real-time fighter balance adjustment, frame data tuning, and move set verification.
    /// </summary>
    public class CharacterEditor
    {
        public FighterDefinition ActiveDefinition { get; private set; }
        public List<ComboMoveData> EditedMoves { get; private set; } = new List<ComboMoveData>();

        public void LoadFighter(string fighterId)
        {
            ActiveDefinition = FighterRoster.GetFighter(fighterId);
        }

        public void ModifyHealth(float newHealth)
        {
            if (ActiveDefinition != null)
            {
                ActiveDefinition.BaseStats.MaxHealth = Math.Max(100.0f, newHealth);
            }
        }

        public void ModifyAttackPower(float newPower)
        {
            if (ActiveDefinition != null)
            {
                ActiveDefinition.BaseStats.AttackPower = Math.Max(10.0f, newPower);
            }
        }

        public void ModifySpeed(float newSpeed)
        {
            if (ActiveDefinition != null)
            {
                ActiveDefinition.BaseStats.MoveSpeed = Math.Max(1.0f, newSpeed);
            }
        }

        public string GenerateBalanceSummary()
        {
            if (ActiveDefinition == null) return "No fighter loaded.";
            return $"[{ActiveDefinition.Name} - {ActiveDefinition.Title}] Element: {ActiveDefinition.Element} | HP: {ActiveDefinition.BaseStats.MaxHealth} | Power: {ActiveDefinition.BaseStats.AttackPower} | Def: {ActiveDefinition.BaseStats.DefenseArmor} | Speed: {ActiveDefinition.BaseStats.MoveSpeed}";
        }
    }

    /// <summary>
    /// AI telemetry and utility debugging tool showing real-time utility scores, personality weights, and reaction lag.
    /// </summary>
    public class AIDebugger
    {
        public struct AIDecisionLog
        {
            public long Frame;
            public string ChosenAction;
            public float DistanceToTarget;
            public float TargetHealthPercent;
            public float OwnEtherPercent;
            public float OwnResonancePercent;
        }

        private readonly List<AIDecisionLog> _decisionHistory = new List<AIDecisionLog>();

        public void LogDecision(long frame, string action, float distance, float targetHp, float ether, float resonance)
        {
            _decisionHistory.Add(new AIDecisionLog
            {
                Frame = frame,
                ChosenAction = action,
                DistanceToTarget = distance,
                TargetHealthPercent = targetHp,
                OwnEtherPercent = ether,
                OwnResonancePercent = resonance
            });

            if (_decisionHistory.Count > 100)
            {
                _decisionHistory.RemoveAt(0);
            }
        }

        public IReadOnlyList<AIDecisionLog> GetHistory() => _decisionHistory;
    }
}
