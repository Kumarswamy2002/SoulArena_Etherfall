using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Elara Sol (Dawn Saint).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class ElaraSolComboGraph
    {
        public string FighterId { get; } = "elara_sol";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public ElaraSolComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("elara_sol_light1", new List<string> { "elara_sol_light2", "elara_sol_heavy", "elara_sol_launcher" });
            RegisterRoute("elara_sol_light2", new List<string> { "elara_sol_light3", "elara_sol_launcher", "elara_sol_special1" });
            RegisterRoute("elara_sol_light3", new List<string> { "elara_sol_special1", "elara_sol_special2", "elara_sol_special3", "elara_sol_ultimate" });

            // Heavy routes
            RegisterRoute("elara_sol_heavy", new List<string> { "elara_sol_special1", "elara_sol_special2" });
            RegisterRoute("elara_sol_launcher", new List<string> { "elara_sol_air_strike" });
            RegisterRoute("elara_sol_air_strike", new List<string> { "elara_sol_special3" });

            // Special ability cancels
            RegisterRoute("elara_sol_special1", new List<string> { "elara_sol_special2", "elara_sol_ultimate" });
            RegisterRoute("elara_sol_special2", new List<string> { "elara_sol_ultimate" });
            RegisterRoute("elara_sol_special3", new List<string> { "elara_sol_light1", "elara_sol_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["elara_sol_light1"] = 1.0f;
            _moveDamageProration["elara_sol_light2"] = 0.95f;
            _moveDamageProration["elara_sol_light3"] = 0.90f;
            _moveDamageProration["elara_sol_heavy"] = 0.85f;
            _moveDamageProration["elara_sol_launcher"] = 0.80f;
            _moveDamageProration["elara_sol_air_strike"] = 0.85f;
            _moveDamageProration["elara_sol_special1"] = 0.75f;
            _moveDamageProration["elara_sol_special2"] = 0.70f;
            _moveDamageProration["elara_sol_special3"] = 0.75f;
            _moveDamageProration["elara_sol_ultimate"] = 0.60f;
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
