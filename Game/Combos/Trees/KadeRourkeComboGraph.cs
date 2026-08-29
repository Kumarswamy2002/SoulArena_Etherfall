using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Kade Rourke (Iron Marauder).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class KadeRourkeComboGraph
    {
        public string FighterId { get; } = "kade_rourke";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public KadeRourkeComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("kade_rourke_light1", new List<string> { "kade_rourke_light2", "kade_rourke_heavy", "kade_rourke_launcher" });
            RegisterRoute("kade_rourke_light2", new List<string> { "kade_rourke_light3", "kade_rourke_launcher", "kade_rourke_special1" });
            RegisterRoute("kade_rourke_light3", new List<string> { "kade_rourke_special1", "kade_rourke_special2", "kade_rourke_special3", "kade_rourke_ultimate" });

            // Heavy routes
            RegisterRoute("kade_rourke_heavy", new List<string> { "kade_rourke_special1", "kade_rourke_special2" });
            RegisterRoute("kade_rourke_launcher", new List<string> { "kade_rourke_air_strike" });
            RegisterRoute("kade_rourke_air_strike", new List<string> { "kade_rourke_special3" });

            // Special ability cancels
            RegisterRoute("kade_rourke_special1", new List<string> { "kade_rourke_special2", "kade_rourke_ultimate" });
            RegisterRoute("kade_rourke_special2", new List<string> { "kade_rourke_ultimate" });
            RegisterRoute("kade_rourke_special3", new List<string> { "kade_rourke_light1", "kade_rourke_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["kade_rourke_light1"] = 1.0f;
            _moveDamageProration["kade_rourke_light2"] = 0.95f;
            _moveDamageProration["kade_rourke_light3"] = 0.90f;
            _moveDamageProration["kade_rourke_heavy"] = 0.85f;
            _moveDamageProration["kade_rourke_launcher"] = 0.80f;
            _moveDamageProration["kade_rourke_air_strike"] = 0.85f;
            _moveDamageProration["kade_rourke_special1"] = 0.75f;
            _moveDamageProration["kade_rourke_special2"] = 0.70f;
            _moveDamageProration["kade_rourke_special3"] = 0.75f;
            _moveDamageProration["kade_rourke_ultimate"] = 0.60f;
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
