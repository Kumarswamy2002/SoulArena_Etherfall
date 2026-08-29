"""
Raid Combat Meter & DPS/HPS Analytics
"""
from typing import Dict, List, Any

class RaidCombatMeter:
    def __init__(self):
        self.events: List[Dict[str, Any]] = []

    def record_event(self, actor_id: str, event_type: str, amount: float, timestamp: float):
        self.events.append({"actor": actor_id, "type": event_type, "amount": amount, "time": timestamp})

    def get_actor_summary(self, actor_id: str, duration_sec: float) -> Dict[str, float]:
        duration = max(1.0, duration_sec)
        total_dmg = sum(e["amount"] for e in self.events if e["actor"] == actor_id and e["type"] == "DAMAGE")
        total_heal = sum(e["amount"] for e in self.events if e["actor"] == actor_id and e["type"] == "HEAL")
        return {
            "total_damage": total_dmg,
            "dps": round(total_dmg / duration, 2),
            "total_healing": total_heal,
            "hps": round(total_heal / duration, 2)
        }
