"""
Elemental Ether Reaction & Combo Engine
"""
from typing import Dict, Any, Tuple

class EtherReactionEngine:
    REACTIONS = {
        ("PYRO", "HYDRO"): {"name": "VAPORIZE", "multiplier": 2.0},
        ("PYRO", "CRYO"): {"name": "MELT", "multiplier": 2.0},
        ("HYDRO", "CRYO"): {"name": "FREEZE", "multiplier": 1.0, "status": "FROZEN"},
        ("ELECTRO", "HYDRO"): {"name": "ELECTRO_CHARGED", "multiplier": 1.5, "status": "STUNNED"}
    }

    @classmethod
    def resolve_interaction(cls, base_element: str, incoming_element: str, base_damage: float) -> Dict[str, Any]:
        pair = (base_element.upper(), incoming_element.upper())
        rev_pair = (incoming_element.upper(), base_element.upper())

        reaction = cls.REACTIONS.get(pair) or cls.REACTIONS.get(rev_pair)
        if reaction:
            dmg = base_damage * reaction.get("multiplier", 1.0)
            return {
                "reaction": reaction["name"],
                "damage": dmg,
                "applied_status": reaction.get("status", "NONE")
            }
        return {"reaction": "NONE", "damage": base_damage, "applied_status": "NONE"}
