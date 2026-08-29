using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Combos;

namespace SoulArena.Combos.Trees
{
    /// <summary>
    /// Branching Combo Route Matrix & Cancel Engine for Yuna Rei (Spirit Dancer).
    /// Validates optimal routes, wall splat conversions, and super cancels.
    /// </summary>
    public class YunaReiComboGraph
    {
        public string FighterId { get; } = "yuna_rei";
        private readonly Dictionary<string, List<string>> _routeAdjacencyList = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, float> _moveDamageProration = new Dictionary<string, float>();

        public event Action<string, string> OnComboTransitionExecuted;

        public YunaReiComboGraph()
        {
            BuildComboRoutingGraph();
            InitializeDamageProration();
        }

        private void BuildComboRoutingGraph()
        {
            // Light chain routes
            RegisterRoute("yuna_rei_light1", new List<string> { "yuna_rei_light2", "yuna_rei_heavy", "yuna_rei_launcher" });
            RegisterRoute("yuna_rei_light2", new List<string> { "yuna_rei_light3", "yuna_rei_launcher", "yuna_rei_special1" });
            RegisterRoute("yuna_rei_light3", new List<string> { "yuna_rei_special1", "yuna_rei_special2", "yuna_rei_special3", "yuna_rei_ultimate" });

            // Heavy routes
            RegisterRoute("yuna_rei_heavy", new List<string> { "yuna_rei_special1", "yuna_rei_special2" });
            RegisterRoute("yuna_rei_launcher", new List<string> { "yuna_rei_air_strike" });
            RegisterRoute("yuna_rei_air_strike", new List<string> { "yuna_rei_special3" });

            // Special ability cancels
            RegisterRoute("yuna_rei_special1", new List<string> { "yuna_rei_special2", "yuna_rei_ultimate" });
            RegisterRoute("yuna_rei_special2", new List<string> { "yuna_rei_ultimate" });
            RegisterRoute("yuna_rei_special3", new List<string> { "yuna_rei_light1", "yuna_rei_special1" });
        }

        private void InitializeDamageProration()
        {
            _moveDamageProration["yuna_rei_light1"] = 1.0f;
            _moveDamageProration["yuna_rei_light2"] = 0.95f;
            _moveDamageProration["yuna_rei_light3"] = 0.90f;
            _moveDamageProration["yuna_rei_heavy"] = 0.85f;
            _moveDamageProration["yuna_rei_launcher"] = 0.80f;
            _moveDamageProration["yuna_rei_air_strike"] = 0.85f;
            _moveDamageProration["yuna_rei_special1"] = 0.75f;
            _moveDamageProration["yuna_rei_special2"] = 0.70f;
            _moveDamageProration["yuna_rei_special3"] = 0.75f;
            _moveDamageProration["yuna_rei_ultimate"] = 0.60f;
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
