using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Kael Varyn (Stormbound).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class KaelVarynComboGraph
    {
        public string FighterId { get; } = "kael_varyn";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public KaelVarynComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("kael_varyn_light1", new List<string> { "kael_varyn_light2", "kael_varyn_heavy", "kael_varyn_launcher" });
            RegisterRoute("kael_varyn_light2", new List<string> { "kael_varyn_light3", "kael_varyn_launcher", "kael_varyn_special1" });
            RegisterRoute("kael_varyn_light3", new List<string> { "kael_varyn_special1", "kael_varyn_special2", "kael_varyn_special3", "kael_varyn_ultimate" });

            // Heavy routes
            RegisterRoute("kael_varyn_heavy", new List<string> { "kael_varyn_special1", "kael_varyn_special2" });
            RegisterRoute("kael_varyn_launcher", new List<string> { "kael_varyn_air_strike" });
            RegisterRoute("kael_varyn_air_strike", new List<string> { "kael_varyn_special3" });

            // Special ability cancels
            RegisterRoute("kael_varyn_special1", new List<string> { "kael_varyn_special2", "kael_varyn_ultimate" });
            RegisterRoute("kael_varyn_special2", new List<string> { "kael_varyn_ultimate" });
            RegisterRoute("kael_varyn_special3", new List<string> { "kael_varyn_light1", "kael_varyn_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["kael_varyn_light1"] = 1.0f;
            _moveDamageProration["kael_varyn_light2"] = 0.95f;
            _moveDamageProration["kael_varyn_light3"] = 0.90f;
            _moveDamageProration["kael_varyn_heavy"] = 0.85f;
            _moveDamageProration["kael_varyn_launcher"] = 0.80f;
            _moveDamageProration["kael_varyn_air_strike"] = 0.85f;
            _moveDamageProration["kael_varyn_special1"] = 0.75f;
            _moveDamageProration["kael_varyn_special2"] = 0.70f;
            _moveDamageProration["kael_varyn_special3"] = 0.75f;
            _moveDamageProration["kael_varyn_ultimate"] = 0.60f;
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
