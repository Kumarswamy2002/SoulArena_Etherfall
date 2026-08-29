from typing import List
from fastapi import APIRouter, Depends
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select, desc
from Backend.app.core.database import get_db
from Backend.app.models.user import User, PlayerProfile, PlayerRating
from Backend.app.schemas.models import LeaderboardResponse, LeaderboardEntry

router = APIRouter(prefix="/leaderboard", tags=["Leaderboard"])

@router.get("", response_model=LeaderboardResponse)
async def get_leaderboard(limit: int = 50, db: AsyncSession = Depends(get_db)):
    query = (
        select(PlayerRating, User, PlayerProfile)
        .join(User, PlayerRating.user_id == User.id)
        .join(PlayerProfile, PlayerProfile.user_id == User.id)
        .order_by(desc(PlayerRating.mmr))
        .limit(limit)
    )

    result = await db.execute(query)
    rows = result.all()

    entries = []
    for idx, (rating, user, profile) in enumerate(rows, start=1):
        total = profile.total_matches
        win_rate = (profile.total_wins / total * 100.0) if total > 0 else 0.0

        entries.append(LeaderboardEntry(
            rank=idx,
            user_id=user.id,
            username=user.username,
            display_title=profile.display_title,
            mmr=rating.mmr,
            tier_name=rating.tier_name,
            win_streak=rating.win_streak,
            total_wins=profile.total_wins,
            win_rate=round(win_rate, 2)
        ))

    return LeaderboardResponse(
        total_players=len(entries),
        entries=entries
    )
