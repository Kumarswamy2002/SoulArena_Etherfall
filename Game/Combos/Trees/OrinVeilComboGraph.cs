using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Orin Veil (Mind Weaver).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class OrinVeilComboGraph
    {
        public string FighterId { get; } = "orin_veil";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public OrinVeilComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("orin_veil_light1", new List<string> { "orin_veil_light2", "orin_veil_heavy", "orin_veil_launcher" });
            RegisterRoute("orin_veil_light2", new List<string> { "orin_veil_light3", "orin_veil_launcher", "orin_veil_special1" });
            RegisterRoute("orin_veil_light3", new List<string> { "orin_veil_special1", "orin_veil_special2", "orin_veil_special3", "orin_veil_ultimate" });

            // Heavy routes
            RegisterRoute("orin_veil_heavy", new List<string> { "orin_veil_special1", "orin_veil_special2" });
            RegisterRoute("orin_veil_launcher", new List<string> { "orin_veil_air_strike" });
            RegisterRoute("orin_veil_air_strike", new List<string> { "orin_veil_special3" });

            // Special ability cancels
            RegisterRoute("orin_veil_special1", new List<string> { "orin_veil_special2", "orin_veil_ultimate" });
            RegisterRoute("orin_veil_special2", new List<string> { "orin_veil_ultimate" });
            RegisterRoute("orin_veil_special3", new List<string> { "orin_veil_light1", "orin_veil_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["orin_veil_light1"] = 1.0f;
            _moveDamageProration["orin_veil_light2"] = 0.95f;
            _moveDamageProration["orin_veil_light3"] = 0.90f;
            _moveDamageProration["orin_veil_heavy"] = 0.85f;
            _moveDamageProration["orin_veil_launcher"] = 0.80f;
            _moveDamageProration["orin_veil_air_strike"] = 0.85f;
            _moveDamageProration["orin_veil_special1"] = 0.75f;
            _moveDamageProration["orin_veil_special2"] = 0.70f;
            _moveDamageProration["orin_veil_special3"] = 0.75f;
            _moveDamageProration["orin_veil_ultimate"] = 0.60f;
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
