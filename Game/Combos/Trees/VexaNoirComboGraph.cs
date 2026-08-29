using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Vexa Noir (Void Walker).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class VexaNoirComboGraph
    {
        public string FighterId { get; } = "vexa_noir";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public VexaNoirComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("vexa_noir_light1", new List<string> { "vexa_noir_light2", "vexa_noir_heavy", "vexa_noir_launcher" });
            RegisterRoute("vexa_noir_light2", new List<string> { "vexa_noir_light3", "vexa_noir_launcher", "vexa_noir_special1" });
            RegisterRoute("vexa_noir_light3", new List<string> { "vexa_noir_special1", "vexa_noir_special2", "vexa_noir_special3", "vexa_noir_ultimate" });

            // Heavy routes
            RegisterRoute("vexa_noir_heavy", new List<string> { "vexa_noir_special1", "vexa_noir_special2" });
            RegisterRoute("vexa_noir_launcher", new List<string> { "vexa_noir_air_strike" });
            RegisterRoute("vexa_noir_air_strike", new List<string> { "vexa_noir_special3" });

            // Special ability cancels
            RegisterRoute("vexa_noir_special1", new List<string> { "vexa_noir_special2", "vexa_noir_ultimate" });
            RegisterRoute("vexa_noir_special2", new List<string> { "vexa_noir_ultimate" });
            RegisterRoute("vexa_noir_special3", new List<string> { "vexa_noir_light1", "vexa_noir_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["vexa_noir_light1"] = 1.0f;
            _moveDamageProration["vexa_noir_light2"] = 0.95f;
            _moveDamageProration["vexa_noir_light3"] = 0.90f;
            _moveDamageProration["vexa_noir_heavy"] = 0.85f;
            _moveDamageProration["vexa_noir_launcher"] = 0.80f;
            _moveDamageProration["vexa_noir_air_strike"] = 0.85f;
            _moveDamageProration["vexa_noir_special1"] = 0.75f;
            _moveDamageProration["vexa_noir_special2"] = 0.70f;
            _moveDamageProration["vexa_noir_special3"] = 0.75f;
            _moveDamageProration["vexa_noir_ultimate"] = 0.60f;
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
