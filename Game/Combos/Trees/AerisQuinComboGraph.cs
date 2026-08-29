using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Aeris Quin (Star Weaver).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class AerisQuinComboGraph
    {
        public string FighterId { get; } = "aeris_quin";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public AerisQuinComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("aeris_quin_light1", new List<string> { "aeris_quin_light2", "aeris_quin_heavy", "aeris_quin_launcher" });
            RegisterRoute("aeris_quin_light2", new List<string> { "aeris_quin_light3", "aeris_quin_launcher", "aeris_quin_special1" });
            RegisterRoute("aeris_quin_light3", new List<string> { "aeris_quin_special1", "aeris_quin_special2", "aeris_quin_special3", "aeris_quin_ultimate" });

            // Heavy routes
            RegisterRoute("aeris_quin_heavy", new List<string> { "aeris_quin_special1", "aeris_quin_special2" });
            RegisterRoute("aeris_quin_launcher", new List<string> { "aeris_quin_air_strike" });
            RegisterRoute("aeris_quin_air_strike", new List<string> { "aeris_quin_special3" });

            // Special ability cancels
            RegisterRoute("aeris_quin_special1", new List<string> { "aeris_quin_special2", "aeris_quin_ultimate" });
            RegisterRoute("aeris_quin_special2", new List<string> { "aeris_quin_ultimate" });
            RegisterRoute("aeris_quin_special3", new List<string> { "aeris_quin_light1", "aeris_quin_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["aeris_quin_light1"] = 1.0f;
            _moveDamageProration["aeris_quin_light2"] = 0.95f;
            _moveDamageProration["aeris_quin_light3"] = 0.90f;
            _moveDamageProration["aeris_quin_heavy"] = 0.85f;
            _moveDamageProration["aeris_quin_launcher"] = 0.80f;
            _moveDamageProration["aeris_quin_air_strike"] = 0.85f;
            _moveDamageProration["aeris_quin_special1"] = 0.75f;
            _moveDamageProration["aeris_quin_special2"] = 0.70f;
            _moveDamageProration["aeris_quin_special3"] = 0.75f;
            _moveDamageProration["aeris_quin_ultimate"] = 0.60f;
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
