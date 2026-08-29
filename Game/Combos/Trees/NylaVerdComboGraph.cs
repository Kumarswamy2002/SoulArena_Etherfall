using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Nyla Verd (Wild Caller).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class NylaVerdComboGraph
    {
        public string FighterId { get; } = "nyla_verd";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public NylaVerdComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("nyla_verd_light1", new List<string> { "nyla_verd_light2", "nyla_verd_heavy", "nyla_verd_launcher" });
            RegisterRoute("nyla_verd_light2", new List<string> { "nyla_verd_light3", "nyla_verd_launcher", "nyla_verd_special1" });
            RegisterRoute("nyla_verd_light3", new List<string> { "nyla_verd_special1", "nyla_verd_special2", "nyla_verd_special3", "nyla_verd_ultimate" });

            // Heavy routes
            RegisterRoute("nyla_verd_heavy", new List<string> { "nyla_verd_special1", "nyla_verd_special2" });
            RegisterRoute("nyla_verd_launcher", new List<string> { "nyla_verd_air_strike" });
            RegisterRoute("nyla_verd_air_strike", new List<string> { "nyla_verd_special3" });

            // Special ability cancels
            RegisterRoute("nyla_verd_special1", new List<string> { "nyla_verd_special2", "nyla_verd_ultimate" });
            RegisterRoute("nyla_verd_special2", new List<string> { "nyla_verd_ultimate" });
            RegisterRoute("nyla_verd_special3", new List<string> { "nyla_verd_light1", "nyla_verd_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["nyla_verd_light1"] = 1.0f;
            _moveDamageProration["nyla_verd_light2"] = 0.95f;
            _moveDamageProration["nyla_verd_light3"] = 0.90f;
            _moveDamageProration["nyla_verd_heavy"] = 0.85f;
            _moveDamageProration["nyla_verd_launcher"] = 0.80f;
            _moveDamageProration["nyla_verd_air_strike"] = 0.85f;
            _moveDamageProration["nyla_verd_special1"] = 0.75f;
            _moveDamageProration["nyla_verd_special2"] = 0.70f;
            _moveDamageProration["nyla_verd_special3"] = 0.75f;
            _moveDamageProration["nyla_verd_ultimate"] = 0.60f;
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
