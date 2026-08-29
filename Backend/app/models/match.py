import uuid
from datetime import datetime, timezone
from sqlalchemy import Column, String, Integer, Float, Boolean, DateTime, ForeignKey, Text
from sqlalchemy.orm import relationship
from Backend.app.core.database import Base

def generate_uuid() -> str:
    return str(uuid.uuid4())

class Match(Base):
    __tablename__ = "matches"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    game_mode = Column(String(50), default="OneVsOne", nullable=False)
    arena_id = Column(String(50), default="SkyforgeTemple", nullable=False)
    is_ranked = Column(Boolean, default=True, nullable=False)
    winner_user_id = Column(String(36), ForeignKey("users.id"), nullable=True)
    match_duration_seconds = Column(Float, default=0.0, nullable=False)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), nullable=False)

    participants = relationship("MatchParticipant", back_populates="match", cascade="all, delete-orphan")
    rounds = relationship("RoundDetail", back_populates="match", cascade="all, delete-orphan")
    replay = relationship("ReplayRecord", back_populates="match", uselist=False, cascade="all, delete-orphan")

class MatchParticipant(Base):
    __tablename__ = "match_participants"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    match_id = Column(String(36), ForeignKey("matches.id", ondelete="CASCADE"), nullable=False)
    user_id = Column(String(36), ForeignKey("users.id", ondelete="CASCADE"), nullable=False)
    slot_index = Column(Integer, default=1, nullable=False)
    fighter_id = Column(String(50), nullable=False)
    is_winner = Column(Boolean, default=False, nullable=False)
    damage_dealt = Column(Float, default=0.0, nullable=False)
    damage_taken = Column(Float, default=0.0, nullable=False)
    max_combo = Column(Integer, default=0, nullable=False)
    mmr_before = Column(Integer, default=1200, nullable=False)
    mmr_after = Column(Integer, default=1200, nullable=False)
    mmr_change = Column(Integer, default=0, nullable=False)

    match = relationship("Match", back_populates="participants")
    user = relationship("User", back_populates="participations")

class RoundDetail(Base):
    __tablename__ = "round_details"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    match_id = Column(String(36), ForeignKey("matches.id", ondelete="CASCADE"), nullable=False)
    round_number = Column(Integer, nullable=False)
    winner_slot = Column(Integer, nullable=False)
    duration_seconds = Column(Float, default=0.0, nullable=False)
    end_condition = Column(String(50), default="KO", nullable=False) # KO, TimeOut, DoubleKO

    match = relationship("Match", back_populates="rounds")
