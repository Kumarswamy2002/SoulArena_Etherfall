using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Auren Zeth (First Soul).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class AurenZethComboGraph
    {
        public string FighterId { get; } = "auren_zeth";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public AurenZethComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("auren_zeth_light1", new List<string> { "auren_zeth_light2", "auren_zeth_heavy", "auren_zeth_launcher" });
            RegisterRoute("auren_zeth_light2", new List<string> { "auren_zeth_light3", "auren_zeth_launcher", "auren_zeth_special1" });
            RegisterRoute("auren_zeth_light3", new List<string> { "auren_zeth_special1", "auren_zeth_special2", "auren_zeth_special3", "auren_zeth_ultimate" });

            // Heavy routes
            RegisterRoute("auren_zeth_heavy", new List<string> { "auren_zeth_special1", "auren_zeth_special2" });
            RegisterRoute("auren_zeth_launcher", new List<string> { "auren_zeth_air_strike" });
            RegisterRoute("auren_zeth_air_strike", new List<string> { "auren_zeth_special3" });

            // Special ability cancels
            RegisterRoute("auren_zeth_special1", new List<string> { "auren_zeth_special2", "auren_zeth_ultimate" });
            RegisterRoute("auren_zeth_special2", new List<string> { "auren_zeth_ultimate" });
            RegisterRoute("auren_zeth_special3", new List<string> { "auren_zeth_light1", "auren_zeth_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["auren_zeth_light1"] = 1.0f;
            _moveDamageProration["auren_zeth_light2"] = 0.95f;
            _moveDamageProration["auren_zeth_light3"] = 0.90f;
            _moveDamageProration["auren_zeth_heavy"] = 0.85f;
            _moveDamageProration["auren_zeth_launcher"] = 0.80f;
            _moveDamageProration["auren_zeth_air_strike"] = 0.85f;
            _moveDamageProration["auren_zeth_special1"] = 0.75f;
            _moveDamageProration["auren_zeth_special2"] = 0.70f;
            _moveDamageProration["auren_zeth_special3"] = 0.75f;
            _moveDamageProration["auren_zeth_ultimate"] = 0.60f;
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
