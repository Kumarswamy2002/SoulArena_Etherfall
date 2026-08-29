using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Ryka Voss (Ember Wolf).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class RykaVossComboGraph
    {
        public string FighterId { get; } = "ryka_voss";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public RykaVossComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("ryka_voss_light1", new List<string> { "ryka_voss_light2", "ryka_voss_heavy", "ryka_voss_launcher" });
            RegisterRoute("ryka_voss_light2", new List<string> { "ryka_voss_light3", "ryka_voss_launcher", "ryka_voss_special1" });
            RegisterRoute("ryka_voss_light3", new List<string> { "ryka_voss_special1", "ryka_voss_special2", "ryka_voss_special3", "ryka_voss_ultimate" });

            // Heavy routes
            RegisterRoute("ryka_voss_heavy", new List<string> { "ryka_voss_special1", "ryka_voss_special2" });
            RegisterRoute("ryka_voss_launcher", new List<string> { "ryka_voss_air_strike" });
            RegisterRoute("ryka_voss_air_strike", new List<string> { "ryka_voss_special3" });

            // Special ability cancels
            RegisterRoute("ryka_voss_special1", new List<string> { "ryka_voss_special2", "ryka_voss_ultimate" });
            RegisterRoute("ryka_voss_special2", new List<string> { "ryka_voss_ultimate" });
            RegisterRoute("ryka_voss_special3", new List<string> { "ryka_voss_light1", "ryka_voss_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["ryka_voss_light1"] = 1.0f;
            _moveDamageProration["ryka_voss_light2"] = 0.95f;
            _moveDamageProration["ryka_voss_light3"] = 0.90f;
            _moveDamageProration["ryka_voss_heavy"] = 0.85f;
            _moveDamageProration["ryka_voss_launcher"] = 0.80f;
            _moveDamageProration["ryka_voss_air_strike"] = 0.85f;
            _moveDamageProration["ryka_voss_special1"] = 0.75f;
            _moveDamageProration["ryka_voss_special2"] = 0.70f;
            _moveDamageProration["ryka_voss_special3"] = 0.75f;
            _moveDamageProration["ryka_voss_ultimate"] = 0.60f;
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
