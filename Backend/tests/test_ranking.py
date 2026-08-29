import pytest
from Backend.app.services.ranking_service import RankingService, ValidationService

def test_elo_calculation_standard():
    winner_mmr = 1200
    loser_mmr = 1200
    w_delta, l_delta = RankingService.calculate_elo_change(winner_mmr, loser_mmr)
    assert w_delta == 16
    assert l_delta == -16

def test_elo_calculation_underdog_win():
    winner_mmr = 1000
    loser_mmr = 1400
    w_delta, l_delta = RankingService.calculate_elo_change(winner_mmr, loser_mmr)
    assert w_delta > 25
    assert l_delta < -25

def test_tier_naming():
    assert RankingService.get_tier_name(500) == "Bronze I"
    assert RankingService.get_tier_name(1350) == "Silver I"
    assert RankingService.get_tier_name(1550) == "Gold I"
    assert RankingService.get_tier_name(2200) == "Master"
    assert RankingService.get_tier_name(2800) == "First Soul Sovereign"

def test_match_validation_success():
    is_valid, msg = ValidationService.validate_match_payload(
        match_duration=65.0,
        p1_damage_dealt=950.0,
        p2_damage_dealt=600.0,
        p1_max_combo=12,
        p2_max_combo=8,
        total_rounds=2
    )
    assert is_valid
    assert msg == "Valid"

def test_match_validation_impossible_speed():
    is_valid, msg = ValidationService.validate_match_payload(
        match_duration=1.5, # Impossible 1.5s match
        p1_damage_dealt=1000.0,
        p2_damage_dealt=0.0,
        p1_max_combo=10,
        p2_max_combo=0,
        total_rounds=2
    )
    assert not is_valid
    assert "short" in msg

def test_match_validation_impossible_dps():
    is_valid, msg = ValidationService.validate_match_payload(
        match_duration=10.0,
        p1_damage_dealt=50000.0, # Impossible hack DPS
        p2_damage_dealt=0.0,
        p1_max_combo=10,
        p2_max_combo=0,
        total_rounds=2
    )
    assert not is_valid
    assert "DPS" in msg
