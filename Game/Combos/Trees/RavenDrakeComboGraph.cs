using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Raven Drake (Blood Knight).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class RavenDrakeComboGraph
    {
        public string FighterId { get; } = "raven_drake";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public RavenDrakeComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("raven_drake_light1", new List<string> { "raven_drake_light2", "raven_drake_heavy", "raven_drake_launcher" });
            RegisterRoute("raven_drake_light2", new List<string> { "raven_drake_light3", "raven_drake_launcher", "raven_drake_special1" });
            RegisterRoute("raven_drake_light3", new List<string> { "raven_drake_special1", "raven_drake_special2", "raven_drake_special3", "raven_drake_ultimate" });

            // Heavy routes
            RegisterRoute("raven_drake_heavy", new List<string> { "raven_drake_special1", "raven_drake_special2" });
            RegisterRoute("raven_drake_launcher", new List<string> { "raven_drake_air_strike" });
            RegisterRoute("raven_drake_air_strike", new List<string> { "raven_drake_special3" });

            // Special ability cancels
            RegisterRoute("raven_drake_special1", new List<string> { "raven_drake_special2", "raven_drake_ultimate" });
            RegisterRoute("raven_drake_special2", new List<string> { "raven_drake_ultimate" });
            RegisterRoute("raven_drake_special3", new List<string> { "raven_drake_light1", "raven_drake_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["raven_drake_light1"] = 1.0f;
            _moveDamageProration["raven_drake_light2"] = 0.95f;
            _moveDamageProration["raven_drake_light3"] = 0.90f;
            _moveDamageProration["raven_drake_heavy"] = 0.85f;
            _moveDamageProration["raven_drake_launcher"] = 0.80f;
            _moveDamageProration["raven_drake_air_strike"] = 0.85f;
            _moveDamageProration["raven_drake_special1"] = 0.75f;
            _moveDamageProration["raven_drake_special2"] = 0.70f;
            _moveDamageProration["raven_drake_special3"] = 0.75f;
            _moveDamageProration["raven_drake_ultimate"] = 0.60f;
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
