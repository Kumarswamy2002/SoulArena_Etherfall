using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Solan Ark (Sunforged).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class SolanArkComboGraph
    {
        public string FighterId { get; } = "solan_ark";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public SolanArkComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("solan_ark_light1", new List<string> { "solan_ark_light2", "solan_ark_heavy", "solan_ark_launcher" });
            RegisterRoute("solan_ark_light2", new List<string> { "solan_ark_light3", "solan_ark_launcher", "solan_ark_special1" });
            RegisterRoute("solan_ark_light3", new List<string> { "solan_ark_special1", "solan_ark_special2", "solan_ark_special3", "solan_ark_ultimate" });

            // Heavy routes
            RegisterRoute("solan_ark_heavy", new List<string> { "solan_ark_special1", "solan_ark_special2" });
            RegisterRoute("solan_ark_launcher", new List<string> { "solan_ark_air_strike" });
            RegisterRoute("solan_ark_air_strike", new List<string> { "solan_ark_special3" });

            // Special ability cancels
            RegisterRoute("solan_ark_special1", new List<string> { "solan_ark_special2", "solan_ark_ultimate" });
            RegisterRoute("solan_ark_special2", new List<string> { "solan_ark_ultimate" });
            RegisterRoute("solan_ark_special3", new List<string> { "solan_ark_light1", "solan_ark_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["solan_ark_light1"] = 1.0f;
            _moveDamageProration["solan_ark_light2"] = 0.95f;
            _moveDamageProration["solan_ark_light3"] = 0.90f;
            _moveDamageProration["solan_ark_heavy"] = 0.85f;
            _moveDamageProration["solan_ark_launcher"] = 0.80f;
            _moveDamageProration["solan_ark_air_strike"] = 0.85f;
            _moveDamageProration["solan_ark_special1"] = 0.75f;
            _moveDamageProration["solan_ark_special2"] = 0.70f;
            _moveDamageProration["solan_ark_special3"] = 0.75f;
            _moveDamageProration["solan_ark_ultimate"] = 0.60f;
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
