using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Zayn Rheo (Lightning Phantom).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class ZaynRheoComboGraph
    {
        public string FighterId { get; } = "zayn_rheo";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public ZaynRheoComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("zayn_rheo_light1", new List<string> { "zayn_rheo_light2", "zayn_rheo_heavy", "zayn_rheo_launcher" });
            RegisterRoute("zayn_rheo_light2", new List<string> { "zayn_rheo_light3", "zayn_rheo_launcher", "zayn_rheo_special1" });
            RegisterRoute("zayn_rheo_light3", new List<string> { "zayn_rheo_special1", "zayn_rheo_special2", "zayn_rheo_special3", "zayn_rheo_ultimate" });

            // Heavy routes
            RegisterRoute("zayn_rheo_heavy", new List<string> { "zayn_rheo_special1", "zayn_rheo_special2" });
            RegisterRoute("zayn_rheo_launcher", new List<string> { "zayn_rheo_air_strike" });
            RegisterRoute("zayn_rheo_air_strike", new List<string> { "zayn_rheo_special3" });

            // Special ability cancels
            RegisterRoute("zayn_rheo_special1", new List<string> { "zayn_rheo_special2", "zayn_rheo_ultimate" });
            RegisterRoute("zayn_rheo_special2", new List<string> { "zayn_rheo_ultimate" });
            RegisterRoute("zayn_rheo_special3", new List<string> { "zayn_rheo_light1", "zayn_rheo_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["zayn_rheo_light1"] = 1.0f;
            _moveDamageProration["zayn_rheo_light2"] = 0.95f;
            _moveDamageProration["zayn_rheo_light3"] = 0.90f;
            _moveDamageProration["zayn_rheo_heavy"] = 0.85f;
            _moveDamageProration["zayn_rheo_launcher"] = 0.80f;
            _moveDamageProration["zayn_rheo_air_strike"] = 0.85f;
            _moveDamageProration["zayn_rheo_special1"] = 0.75f;
            _moveDamageProration["zayn_rheo_special2"] = 0.70f;
            _moveDamageProration["zayn_rheo_special3"] = 0.75f;
            _moveDamageProration["zayn_rheo_ultimate"] = 0.60f;
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
