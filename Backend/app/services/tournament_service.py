from typing import List, Dict, Optional
import uuid

class TournamentService:
    @staticmethod
    def generate_single_elimination_bracket(player_ids: List[str]) -> List[Dict]:
        if len(player_ids) < 2:
            return []
        
        matches = []
        for i in range(0, len(player_ids), 2):
            p1 = player_ids[i]
            p2 = player_ids[i+1] if i+1 < len(player_ids) else None
            matches.append({
                "match_id": f"tourney_match_{uuid.uuid4().hex[:8]}",
                "round": 1,
                "player1_id": p1,
                "player2_id": p2,
                "winner_id": None,
                "status": "pending"
            })
        return matches

    @staticmethod
    def resolve_tournament_match(match: Dict, winner_id: str) -> Dict:
        match["winner_id"] = winner_id
        match["status"] = "completed"
        return match
