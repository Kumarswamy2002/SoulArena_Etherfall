from typing import Optional, List
from datetime import datetime
from pydantic import BaseModel, EmailStr, Field, ConfigDict

# Auth Schemas
class UserCreate(BaseModel):
    email: EmailStr
    username: str = Field(..., min_length=3, max_length=30)
    password: str = Field(..., min_length=6, max_length=100)

class UserLogin(BaseModel):
    username_or_email: str
    password: str

class Token(BaseModel):
    access_token: str
    token_type: str = "bearer"

class TokenPayload(BaseModel):
    sub: Optional[str] = None
    exp: Optional[int] = None

class UserResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    id: str
    email: str
    username: str
    is_active: bool
    created_at: datetime

# Player Profile Schemas
class ProfileUpdate(BaseModel):
    display_title: Optional[str] = Field(None, max_length=100)
    avatar_url: Optional[str] = Field(None, max_length=500)
    favorite_fighter_id: Optional[str] = Field(None, max_length=50)

class ProfileResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    user_id: str
    username: str
    display_title: str
    avatar_url: Optional[str]
    favorite_fighter_id: str
    total_matches: int
    total_wins: int
    total_losses: int
    win_rate: float
    highest_combo_streak: int
    total_damage_dealt: float
    total_perfect_guards: int
    total_awakenings: int

class RatingResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    user_id: str
    username: str
    mmr: int
    tier_name: str
    league_points: int
    win_streak: int
    best_rank_tier: str

# Match & Replay Schemas
class ParticipantReport(BaseModel):
    user_id: str
    slot_index: int
    fighter_id: str
    is_winner: bool
    damage_dealt: float
    damage_taken: float
    max_combo: int

class RoundReport(BaseModel):
    round_number: int
    winner_slot: int
    duration_seconds: float
    end_condition: str

class MatchReportRequest(BaseModel):
    game_mode: str = "OneVsOne"
    arena_id: str = "SkyforgeTemple"
    is_ranked: bool = True
    match_duration_seconds: float
    participants: List[ParticipantReport]
    rounds: List[RoundReport]
    replay_json_payload: Optional[str] = None

class MatchResponse(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    id: str
    game_mode: str
    arena_id: str
    is_ranked: bool
    winner_user_id: Optional[str]
    match_duration_seconds: float
    created_at: datetime
    participants: List[ParticipantReport]

class LeaderboardEntry(BaseModel):
    rank: int
    user_id: str
    username: str
    display_title: str
    mmr: int
    tier_name: str
    win_streak: int
    total_wins: int
    win_rate: float

class LeaderboardResponse(BaseModel):
    total_players: int
    entries: List[LeaderboardEntry]

class MatchmakingTicket(BaseModel):
    ticket_id: str
    status: str # queuing, matched, cancelled
    match_id: Optional[str] = None
    server_address: Optional[str] = None
