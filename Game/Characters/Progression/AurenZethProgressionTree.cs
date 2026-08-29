using System;
using System.Collections.Generic;

namespace SoulArena.Characters.Progression
{
    /// <summary>
    /// Skill Tree & Level Mastery Progression for Auren Zeth (First Soul).
    /// </summary>
    public class AurenZethProgressionTree
    {
        public struct MasteryNode
        {
            public string NodeId;
            public string Name;
            public string Description;
            public int RequiredLevel;
            public bool IsUnlocked;
        }

        public int CurrentMasteryLevel { get; set; } = 1;
        public int TotalMasteryExperience { get; set; } = 0;
        private readonly List<MasteryNode> _nodes = new List<MasteryNode>();

        public AurenZethProgressionTree()
        {
            InitializeMasteryTree();
        }

        private void InitializeMasteryTree()
        {
            _nodes.Add(new MasteryNode { NodeId = "auren_zeth_node_1", Name = "First Soul Discipline", Description = "+5% Ether regen speed", RequiredLevel = 2, IsUnlocked = false });
            _nodes.Add(new MasteryNode { NodeId = "auren_zeth_node_2", Name = "Flow Resonance", Description = "+10% Resonance on counter hits", RequiredLevel = 5, IsUnlocked = false });
            _nodes.Add(new MasteryNode { NodeId = "auren_zeth_node_3", Name = "Ultimate Mastery", Description = "Reduces Ultimate Ether cost by 5", RequiredLevel = 10, IsUnlocked = false });
        }

        public void AddExperience(int exp)
        {
            TotalMasteryExperience += exp;
            if (TotalMasteryExperience >= CurrentMasteryLevel * 500)
            {
                CurrentMasteryLevel++;
                UnlockEligibleNodes();
            }
        }

        private void UnlockEligibleNodes()
        {
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].RequiredLevel <= CurrentMasteryLevel)
                {
                    var n = _nodes[i];
                    n.IsUnlocked = true;
                    _nodes[i] = n;
                }
            }
        }
    }
}
