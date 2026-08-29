"""
Loot Drop Probability Table & Pity Counter
"""
from typing import Dict, Any

class LootRoller:
    BASE_MYTHIC_CHANCE = 0.02
    PITY_THRESHOLD = 50

    @classmethod
    def roll_drop(cls, roll_random_val: float, pity_count: int) -> Dict[str, Any]:
        if pity_count >= cls.PITY_THRESHOLD:
            return {"rarity": "MYTHIC", "pity_triggered": True, "new_pity_count": 0}
        
        if roll_random_val <= cls.BASE_MYTHIC_CHANCE:
            return {"rarity": "MYTHIC", "pity_triggered": False, "new_pity_count": 0}
        elif roll_random_val <= 0.15:
            return {"rarity": "LEGENDARY", "pity_triggered": False, "new_pity_count": pity_count + 1}
        else:
            return {"rarity": "RARE", "pity_triggered": False, "new_pity_count": pity_count + 1}
