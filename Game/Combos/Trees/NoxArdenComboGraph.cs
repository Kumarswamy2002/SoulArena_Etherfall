using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Nox Arden (Riftborn).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class NoxArdenComboGraph
    {
        public string FighterId { get; } = "nox_arden";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public NoxArdenComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("nox_arden_light1", new List<string> { "nox_arden_light2", "nox_arden_heavy", "nox_arden_launcher" });
            RegisterRoute("nox_arden_light2", new List<string> { "nox_arden_light3", "nox_arden_launcher", "nox_arden_special1" });
            RegisterRoute("nox_arden_light3", new List<string> { "nox_arden_special1", "nox_arden_special2", "nox_arden_special3", "nox_arden_ultimate" });

            // Heavy routes
            RegisterRoute("nox_arden_heavy", new List<string> { "nox_arden_special1", "nox_arden_special2" });
            RegisterRoute("nox_arden_launcher", new List<string> { "nox_arden_air_strike" });
            RegisterRoute("nox_arden_air_strike", new List<string> { "nox_arden_special3" });

            // Special ability cancels
            RegisterRoute("nox_arden_special1", new List<string> { "nox_arden_special2", "nox_arden_ultimate" });
            RegisterRoute("nox_arden_special2", new List<string> { "nox_arden_ultimate" });
            RegisterRoute("nox_arden_special3", new List<string> { "nox_arden_light1", "nox_arden_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["nox_arden_light1"] = 1.0f;
            _moveDamageProration["nox_arden_light2"] = 0.95f;
            _moveDamageProration["nox_arden_light3"] = 0.90f;
            _moveDamageProration["nox_arden_heavy"] = 0.85f;
            _moveDamageProration["nox_arden_launcher"] = 0.80f;
            _moveDamageProration["nox_arden_air_strike"] = 0.85f;
            _moveDamageProration["nox_arden_special1"] = 0.75f;
            _moveDamageProration["nox_arden_special2"] = 0.70f;
            _moveDamageProration["nox_arden_special3"] = 0.75f;
            _moveDamageProration["nox_arden_ultimate"] = 0.60f;
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
