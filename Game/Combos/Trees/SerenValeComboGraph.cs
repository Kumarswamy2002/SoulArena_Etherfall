using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Seren Vale (Frozen Blade).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class SerenValeComboGraph
    {
        public string FighterId { get; } = "seren_vale";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public SerenValeComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("seren_vale_light1", new List<string> { "seren_vale_light2", "seren_vale_heavy", "seren_vale_launcher" });
            RegisterRoute("seren_vale_light2", new List<string> { "seren_vale_light3", "seren_vale_launcher", "seren_vale_special1" });
            RegisterRoute("seren_vale_light3", new List<string> { "seren_vale_special1", "seren_vale_special2", "seren_vale_special3", "seren_vale_ultimate" });

            // Heavy routes
            RegisterRoute("seren_vale_heavy", new List<string> { "seren_vale_special1", "seren_vale_special2" });
            RegisterRoute("seren_vale_launcher", new List<string> { "seren_vale_air_strike" });
            RegisterRoute("seren_vale_air_strike", new List<string> { "seren_vale_special3" });

            // Special ability cancels
            RegisterRoute("seren_vale_special1", new List<string> { "seren_vale_special2", "seren_vale_ultimate" });
            RegisterRoute("seren_vale_special2", new List<string> { "seren_vale_ultimate" });
            RegisterRoute("seren_vale_special3", new List<string> { "seren_vale_light1", "seren_vale_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["seren_vale_light1"] = 1.0f;
            _moveDamageProration["seren_vale_light2"] = 0.95f;
            _moveDamageProration["seren_vale_light3"] = 0.90f;
            _moveDamageProration["seren_vale_heavy"] = 0.85f;
            _moveDamageProration["seren_vale_launcher"] = 0.80f;
            _moveDamageProration["seren_vale_air_strike"] = 0.85f;
            _moveDamageProration["seren_vale_special1"] = 0.75f;
            _moveDamageProration["seren_vale_special2"] = 0.70f;
            _moveDamageProration["seren_vale_special3"] = 0.75f;
            _moveDamageProration["seren_vale_ultimate"] = 0.60f;
        }

        public void RegisterRoute(string fromMove, List<string> toMoves)
        {
            _routeAdjacencyList[fromMove] = toMoves;
        }

        public bool CanExecuteRoute(string currentMove, string targetMove, bool hitConnected)
        {
            if (!hitConnected) return false;
            if (_routeAdjacencyList.TryGetValue(currentMove, out var validNext))
            {
                bool isValid = validNext.Contains(targetMove);
                if (isValid)
                {
                    OnComboTransitionExecuted?.Invoke(currentMove, targetMove);
                }
                return isValid;
            }
            return false;
        }

        public float GetMoveProration(string moveId)
        {
            if (_moveDamageProration.TryGetValue(moveId, out float proration))
            {
                return proration;
            }
            return 1.0f;
        }
    }
}
