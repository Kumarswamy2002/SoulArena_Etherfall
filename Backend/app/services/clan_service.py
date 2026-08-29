from typing import List, Dict, Optional
import uuid

class ClanService:
    @staticmethod
    def create_clan_record(name: str, tag: str, leader_id: str) -> Dict:
        return {
            "clan_id": f"clan_{uuid.uuid4().hex[:8]}",
            "name": name,
            "tag": tag.upper(),
            "leader_id": leader_id,
            "members": [leader_id],
            "total_points": 0,
            "level": 1
        }

    @staticmethod
    def calculate_clan_war_points(wins: int, perfect_guards: int, ultimates: int) -> int:
        return (wins * 100) + (perfect_guards * 10) + (ultimates * 25)
