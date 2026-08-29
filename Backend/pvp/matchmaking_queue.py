"""
PvP Arena ELO Matchmaking Queue & Rating System
"""
import math
from typing import Dict, Any, List

class ArenaMatchmakingQueue:
    K_FACTOR = 32

    @staticmethod
    def calculate_elo_change(winner_rating: int, loser_rating: int) -> int:
        expected_win = 1.0 / (1.0 + math.pow(10.0, (loser_rating - winner_rating) / 400.0))
        change = int(round(ArenaMatchmakingQueue.K_FACTOR * (1.0 - expected_win)))
        return max(1, change)

    @classmethod
    def match_players(cls, queue: List[Dict[str, Any]], max_rating_diff: int = 150) -> List[Tuple[Dict[str, Any], Dict[str, Any]]]:
        sorted_q = sorted(queue, key=lambda x: x["rating"])
        matches = []
        i = 0
        while i < len(sorted_q) - 1:
            p1 = sorted_q[i]
            p2 = sorted_q[i+1]
            if abs(p1["rating"] - p2["rating"]) <= max_rating_diff:
                matches.append((p1, p2))
                i += 2
            else:
                i += 1
        return matches
