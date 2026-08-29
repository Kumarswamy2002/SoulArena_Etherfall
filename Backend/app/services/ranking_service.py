import math
from typing import Tuple

TIER_THRESHOLDS = [
    (0, "Bronze I"),
    (1300, "Silver I"),
    (1500, "Gold I"),
    (1700, "Platinum I"),
    (1900, "Diamond I"),
    (2100, "Master"),
    (2400, "Grandmaster"),
    (2700, "First Soul Sovereign")
]

class RankingService:
    @staticmethod
    def get_tier_name(mmr: int) -> str:
        current_tier = "Bronze I"
        for threshold, tier in TIER_THRESHOLDS:
            if mmr >= threshold:
                current_tier = tier
            else:
                break
        return current_tier

    @staticmethod
    def calculate_elo_change(winner_mmr: int, loser_mmr: int, k_factor: int = 32) -> Tuple[int, int]:
        """
        Standard Elo formula calculating rating delta based on expected vs actual outcome.
        """
        # Expected scores
        expected_winner = 1.0 / (1.0 + math.pow(10.0, (loser_mmr - winner_mmr) / 400.0))
        expected_loser = 1.0 / (1.0 + math.pow(10.0, (winner_mmr - loser_mmr) / 400.0))

        winner_delta = int(round(k_factor * (1.0 - expected_winner)))
        loser_delta = int(round(k_factor * (0.0 - expected_loser)))

        # Ensure minimum 10 points gain/loss for decisive ranked combat
        winner_delta = max(10, winner_delta)
        loser_delta = min(-10, loser_delta)

        return winner_delta, loser_delta

class MatchmakingService:
    @staticmethod
    def format_ticket_key(user_id: str) -> str:
        return f"mm:ticket:{user_id}"

    @staticmethod
    def format_queue_key(game_mode: str) -> str:
        return f"mm:queue:{game_mode}"

class ValidationService:
    @staticmethod
    def validate_match_payload(
        match_duration: float,
        p1_damage_dealt: float,
        p2_damage_dealt: float,
        p1_max_combo: int,
        p2_max_combo: int,
        total_rounds: int
    ) -> Tuple[bool, str]:
        """
        Server-side validation to reject cheated/impossible match results.
        """
        if match_duration <= 3.0:
            return False, "Match duration is impossibly short (< 3.0s)."

        if match_duration > 600.0:
            return False, "Match duration exceeds maximum allowed limit (600s)."

        # Maximum possible DPS check across realistic combos (~300 DPS theoretical maximum)
        max_possible_damage = match_duration * 350.0
        if p1_damage_dealt > max_possible_damage or p2_damage_dealt > max_possible_damage:
            return False, "Damage dealt exceeds theoretical maximum DPS limits."

        # Maximum combo streak sanity check
        if p1_max_combo > 80 or p2_max_combo > 80:
            return False, "Combo count exceeds engine maximum juggle limits."

        if total_rounds < 1 or total_rounds > 5:
            return False, "Invalid number of rounds reported."

        return True, "Valid"
