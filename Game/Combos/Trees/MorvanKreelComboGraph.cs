using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Morvan Kreel (Grave King).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class MorvanKreelComboGraph
    {
        public string FighterId { get; } = "morvan_kreel";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public MorvanKreelComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("morvan_kreel_light1", new List<string> { "morvan_kreel_light2", "morvan_kreel_heavy", "morvan_kreel_launcher" });
            RegisterRoute("morvan_kreel_light2", new List<string> { "morvan_kreel_light3", "morvan_kreel_launcher", "morvan_kreel_special1" });
            RegisterRoute("morvan_kreel_light3", new List<string> { "morvan_kreel_special1", "morvan_kreel_special2", "morvan_kreel_special3", "morvan_kreel_ultimate" });

            // Heavy routes
            RegisterRoute("morvan_kreel_heavy", new List<string> { "morvan_kreel_special1", "morvan_kreel_special2" });
            RegisterRoute("morvan_kreel_launcher", new List<string> { "morvan_kreel_air_strike" });
            RegisterRoute("morvan_kreel_air_strike", new List<string> { "morvan_kreel_special3" });

            // Special ability cancels
            RegisterRoute("morvan_kreel_special1", new List<string> { "morvan_kreel_special2", "morvan_kreel_ultimate" });
            RegisterRoute("morvan_kreel_special2", new List<string> { "morvan_kreel_ultimate" });
            RegisterRoute("morvan_kreel_special3", new List<string> { "morvan_kreel_light1", "morvan_kreel_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["morvan_kreel_light1"] = 1.0f;
            _moveDamageProration["morvan_kreel_light2"] = 0.95f;
            _moveDamageProration["morvan_kreel_light3"] = 0.90f;
            _moveDamageProration["morvan_kreel_heavy"] = 0.85f;
            _moveDamageProration["morvan_kreel_launcher"] = 0.80f;
            _moveDamageProration["morvan_kreel_air_strike"] = 0.85f;
            _moveDamageProration["morvan_kreel_special1"] = 0.75f;
            _moveDamageProration["morvan_kreel_special2"] = 0.70f;
            _moveDamageProration["morvan_kreel_special3"] = 0.75f;
            _moveDamageProration["morvan_kreel_ultimate"] = 0.60f;
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
