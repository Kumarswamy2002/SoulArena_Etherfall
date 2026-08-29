using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Mira Tide (Tideblade).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class MiraTideComboGraph
    {
        public string FighterId { get; } = "mira_tide";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public MiraTideComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("mira_tide_light1", new List<string> { "mira_tide_light2", "mira_tide_heavy", "mira_tide_launcher" });
            RegisterRoute("mira_tide_light2", new List<string> { "mira_tide_light3", "mira_tide_launcher", "mira_tide_special1" });
            RegisterRoute("mira_tide_light3", new List<string> { "mira_tide_special1", "mira_tide_special2", "mira_tide_special3", "mira_tide_ultimate" });

            // Heavy routes
            RegisterRoute("mira_tide_heavy", new List<string> { "mira_tide_special1", "mira_tide_special2" });
            RegisterRoute("mira_tide_launcher", new List<string> { "mira_tide_air_strike" });
            RegisterRoute("mira_tide_air_strike", new List<string> { "mira_tide_special3" });

            // Special ability cancels
            RegisterRoute("mira_tide_special1", new List<string> { "mira_tide_special2", "mira_tide_ultimate" });
            RegisterRoute("mira_tide_special2", new List<string> { "mira_tide_ultimate" });
            RegisterRoute("mira_tide_special3", new List<string> { "mira_tide_light1", "mira_tide_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["mira_tide_light1"] = 1.0f;
            _moveDamageProration["mira_tide_light2"] = 0.95f;
            _moveDamageProration["mira_tide_light3"] = 0.90f;
            _moveDamageProration["mira_tide_heavy"] = 0.85f;
            _moveDamageProration["mira_tide_launcher"] = 0.80f;
            _moveDamageProration["mira_tide_air_strike"] = 0.85f;
            _moveDamageProration["mira_tide_special1"] = 0.75f;
            _moveDamageProration["mira_tide_special2"] = 0.70f;
            _moveDamageProration["mira_tide_special3"] = 0.75f;
            _moveDamageProration["mira_tide_ultimate"] = 0.60f;
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
