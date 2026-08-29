using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Torren Kai (Wind Dancer).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class TorrenKaiComboGraph
    {
        public string FighterId { get; } = "torren_kai";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public TorrenKaiComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("torren_kai_light1", new List<string> { "torren_kai_light2", "torren_kai_heavy", "torren_kai_launcher" });
            RegisterRoute("torren_kai_light2", new List<string> { "torren_kai_light3", "torren_kai_launcher", "torren_kai_special1" });
            RegisterRoute("torren_kai_light3", new List<string> { "torren_kai_special1", "torren_kai_special2", "torren_kai_special3", "torren_kai_ultimate" });

            // Heavy routes
            RegisterRoute("torren_kai_heavy", new List<string> { "torren_kai_special1", "torren_kai_special2" });
            RegisterRoute("torren_kai_launcher", new List<string> { "torren_kai_air_strike" });
            RegisterRoute("torren_kai_air_strike", new List<string> { "torren_kai_special3" });

            // Special ability cancels
            RegisterRoute("torren_kai_special1", new List<string> { "torren_kai_special2", "torren_kai_ultimate" });
            RegisterRoute("torren_kai_special2", new List<string> { "torren_kai_ultimate" });
            RegisterRoute("torren_kai_special3", new List<string> { "torren_kai_light1", "torren_kai_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["torren_kai_light1"] = 1.0f;
            _moveDamageProration["torren_kai_light2"] = 0.95f;
            _moveDamageProration["torren_kai_light3"] = 0.90f;
            _moveDamageProration["torren_kai_heavy"] = 0.85f;
            _moveDamageProration["torren_kai_launcher"] = 0.80f;
            _moveDamageProration["torren_kai_air_strike"] = 0.85f;
            _moveDamageProration["torren_kai_special1"] = 0.75f;
            _moveDamageProration["torren_kai_special2"] = 0.70f;
            _moveDamageProration["torren_kai_special3"] = 0.75f;
            _moveDamageProration["torren_kai_ultimate"] = 0.60f;
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
