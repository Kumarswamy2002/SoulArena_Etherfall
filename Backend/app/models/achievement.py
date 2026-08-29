import uuid
from datetime import datetime, timezone
from sqlalchemy import Column, String, Integer, Boolean, DateTime, ForeignKey, Text
from sqlalchemy.orm import relationship
from Backend.app.core.database import Base

def generate_uuid() -> str:
    return str(uuid.uuid4())

class Achievement(Base):
    __tablename__ = "achievements"

    id = Column(String(50), primary_key=True)
    name = Column(String(100), nullable=False)
    description = Column(String(255), nullable=False)
    icon_name = Column(String(100), nullable=False)
    reward_points = Column(Integer, default=10, nullable=False)

    player_achievements = relationship("PlayerAchievement", back_populates="achievement")

class PlayerAchievement(Base):
    __tablename__ = "player_achievements"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    user_id = Column(String(36), ForeignKey("users.id", ondelete="CASCADE"), nullable=False)
    achievement_id = Column(String(50), ForeignKey("achievements.id", ondelete="CASCADE"), nullable=False)
    unlocked_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), nullable=False)

    user = relationship("User", back_populates="achievements")
    achievement = relationship("Achievement", back_populates="player_achievements")

class ReplayRecord(Base):
    __tablename__ = "replays"

    id = Column(String(36), primary_key=True, default=generate_uuid)
    match_id = Column(String(36), ForeignKey("matches.id", ondelete="CASCADE"), unique=True, nullable=False)
    total_frames = Column(Integer, default=0, nullable=False)
    replay_json_payload = Column(Text, nullable=False)
    file_size_bytes = Column(Integer, default=0, nullable=False)
    created_at = Column(DateTime(timezone=True), default=lambda: datetime.now(timezone.utc), nullable=False)

    match = relationship("Match", back_populates="replay")
