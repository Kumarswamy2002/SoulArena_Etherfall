"""
Character Talent Tree & Passive Node System
"""
from typing import Dict, List, Set, Any

class TalentTreeSystem:
    TALENT_NODES = {
        "tier1_power": {"prereq": None, "stat": "attack_power", "value": 15},
        "tier1_mana": {"prereq": None, "stat": "max_mana", "value": 50},
        "tier2_crit": {"prereq": "tier1_power", "stat": "crit_rate_pct", "value": 5.0},
        "tier2_cd_reduct": {"prereq": "tier1_mana", "stat": "cooldown_reduction_pct", "value": 8.0}
    }

    @classmethod
    def can_unlock_node(cls, node_id: str, unlocked_nodes: Set[str]) -> bool:
        if node_id not in cls.TALENT_NODES:
            return False
        prereq = cls.TALENT_NODES[node_id]["prereq"]
        return prereq is None or prereq in unlocked_nodes

    @classmethod
    def calculate_total_bonuses(cls, unlocked_nodes: Set[str]) -> Dict[str, float]:
        bonuses = {}
        for node in unlocked_nodes:
            if node in cls.TALENT_NODES:
                stat = cls.TALENT_NODES[node]["stat"]
                val = cls.TALENT_NODES[node]["value"]
                bonuses[stat] = bonuses.get(stat, 0.0) + val
        return bonuses
