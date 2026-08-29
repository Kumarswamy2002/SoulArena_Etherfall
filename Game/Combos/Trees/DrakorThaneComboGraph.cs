using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Drakor Thane (Iron Colossus).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class DrakorThaneComboGraph
    {
        public string FighterId { get; } = "drakor_thane";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public DrakorThaneComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("drakor_thane_light1", new List<string> { "drakor_thane_light2", "drakor_thane_heavy", "drakor_thane_launcher" });
            RegisterRoute("drakor_thane_light2", new List<string> { "drakor_thane_light3", "drakor_thane_launcher", "drakor_thane_special1" });
            RegisterRoute("drakor_thane_light3", new List<string> { "drakor_thane_special1", "drakor_thane_special2", "drakor_thane_special3", "drakor_thane_ultimate" });

            // Heavy routes
            RegisterRoute("drakor_thane_heavy", new List<string> { "drakor_thane_special1", "drakor_thane_special2" });
            RegisterRoute("drakor_thane_launcher", new List<string> { "drakor_thane_air_strike" });
            RegisterRoute("drakor_thane_air_strike", new List<string> { "drakor_thane_special3" });

            // Special ability cancels
            RegisterRoute("drakor_thane_special1", new List<string> { "drakor_thane_special2", "drakor_thane_ultimate" });
            RegisterRoute("drakor_thane_special2", new List<string> { "drakor_thane_ultimate" });
            RegisterRoute("drakor_thane_special3", new List<string> { "drakor_thane_light1", "drakor_thane_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["drakor_thane_light1"] = 1.0f;
            _moveDamageProration["drakor_thane_light2"] = 0.95f;
            _moveDamageProration["drakor_thane_light3"] = 0.90f;
            _moveDamageProration["drakor_thane_heavy"] = 0.85f;
            _moveDamageProration["drakor_thane_launcher"] = 0.80f;
            _moveDamageProration["drakor_thane_air_strike"] = 0.85f;
            _moveDamageProration["drakor_thane_special1"] = 0.75f;
            _moveDamageProration["drakor_thane_special2"] = 0.70f;
            _moveDamageProration["drakor_thane_special3"] = 0.75f;
            _moveDamageProration["drakor_thane_ultimate"] = 0.60f;
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
