import uuid
from datetime import datetime, timezone
from sqlalchemy import Column, String, Integer, Float, Boolean, DateTime, ForeignKey, Index
from sqlalchemy.orm import relationship
from Backend.app.core.database import Base

def generate_uuid() -> str:
    return str(uuid.uuid4())

class User(Base):
    __tablename__ = "users"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    email = Column(String(255), unique=True, nullable=False, index=True)
    username = Column(String(50), unique=True, nullable=False, index=True)
    hashed_password = Column(String(255), nullable=False)
    is_active = Column(Boolean, default=True, nullable=False)
    is_admin = Column(Boolean, default=False, nullable=False)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), nullable=False)
    updated_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), onupdate=lambda: datetime.now(timezone.utc), nullable=False)

    profile = relationship("PlayerProfile", back_populates="user", uselist=False, cascade="all, delete-orphan")
    rating = relationship("PlayerRating", back_populates="user", uselist=False, cascade="all, delete-orphan")
    participations = relationship("MatchParticipant", back_populates="user")
    achievements = relationship("PlayerAchievement", back_populates="user")

class PlayerProfile(Base):
    __tablename__ = "player_profiles"

    user_id = Column(String(36), ForeignKey("users.id", ondelete="CASCADE"), primary_key=True)
    display_title = Column(String(100), default="Novice Soulforged", nullable=False)
    avatar_url = Column(String(500), nullable=True)
    favorite_fighter_id = Column(String(50), default="kael_varyn", nullable=False)
    total_matches = Column(Integer, default=0, nullable=False)
    total_wins = Column(Integer, default=0, nullable=False)
    total_losses = Column(Integer, default=0, nullable=False)
    highest_combo_streak = Column(Integer, default=0, nullable=False)
    total_damage_dealt = Column(Float, default=0.0, nullable=False)
    total_perfect_guards = Column(Integer, default=0, nullable=False)
    total_awakenings = Column(Integer, default=0, nullable=False)

    user = relationship("User", back_populates="profile")

class PlayerRating(Base):
    __tablename__ = "player_ratings"

    user_id = Column(String(36), ForeignKey("users.id", ondelete="CASCADE"), primary_key=True)
    mmr = Column(Integer, default=1200, nullable=False, index=True)
    tier_name = Column(String(50), default="Bronze I", nullable=False)
    league_points = Column(Integer, default=0, nullable=False)
    win_streak = Column(Integer, default=0, nullable=False)
    best_rank_tier = Column(String(50), default="Bronze I", nullable=False)
    updated_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), onupdate=lambda: datetime.now(timezone.utc), nullable=False)

    user = relationship("User", back_populates="rating")
