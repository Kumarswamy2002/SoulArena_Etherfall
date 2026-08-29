using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Rokan Fen (Beast Soul).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class RokanFenComboGraph
    {
        public string FighterId { get; } = "rokan_fen";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public RokanFenComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("rokan_fen_light1", new List<string> { "rokan_fen_light2", "rokan_fen_heavy", "rokan_fen_launcher" });
            RegisterRoute("rokan_fen_light2", new List<string> { "rokan_fen_light3", "rokan_fen_launcher", "rokan_fen_special1" });
            RegisterRoute("rokan_fen_light3", new List<string> { "rokan_fen_special1", "rokan_fen_special2", "rokan_fen_special3", "rokan_fen_ultimate" });

            // Heavy routes
            RegisterRoute("rokan_fen_heavy", new List<string> { "rokan_fen_special1", "rokan_fen_special2" });
            RegisterRoute("rokan_fen_launcher", new List<string> { "rokan_fen_air_strike" });
            RegisterRoute("rokan_fen_air_strike", new List<string> { "rokan_fen_special3" });

            // Special ability cancels
            RegisterRoute("rokan_fen_special1", new List<string> { "rokan_fen_special2", "rokan_fen_ultimate" });
            RegisterRoute("rokan_fen_special2", new List<string> { "rokan_fen_ultimate" });
            RegisterRoute("rokan_fen_special3", new List<string> { "rokan_fen_light1", "rokan_fen_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["rokan_fen_light1"] = 1.0f;
            _moveDamageProration["rokan_fen_light2"] = 0.95f;
            _moveDamageProration["rokan_fen_light3"] = 0.90f;
            _moveDamageProration["rokan_fen_heavy"] = 0.85f;
            _moveDamageProration["rokan_fen_launcher"] = 0.80f;
            _moveDamageProration["rokan_fen_air_strike"] = 0.85f;
            _moveDamageProration["rokan_fen_special1"] = 0.75f;
            _moveDamageProration["rokan_fen_special2"] = 0.70f;
            _moveDamageProration["rokan_fen_special3"] = 0.75f;
            _moveDamageProration["rokan_fen_ultimate"] = 0.60f;
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
