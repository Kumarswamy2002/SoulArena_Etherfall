from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select
from Backend.app.core.database import get_db
from Backend.app.models.user import User, PlayerProfile, PlayerRating
from Backend.app.schemas.models import ProfileUpdate, ProfileResponse, RatingResponse
from Backend.app.api.v1.endpoints.auth import get_current_user

router = APIRouter(prefix="/player", tags=["Player"])

@router.get("/profile", response_model=ProfileResponse)
async def get_profile(current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(PlayerProfile).where(PlayerProfile.user_id == current_user.id))
    profile = result.scalar_one_or_none()
    if not profile:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Profile not found")

    total = profile.total_matches
    win_rate = (profile.total_wins / total * 100.0) if total > 0 else 0.0

    return ProfileResponse(
        user_id=profile.user_id,
        username=current_user.username,
        display_title=profile.display_title,
        avatar_url=profile.avatar_url,
        favorite_fighter_id=profile.favorite_fighter_id,
        total_matches=profile.total_matches,
        total_wins=profile.total_wins,
        total_losses=profile.total_losses,
        win_rate=round(win_rate, 2),
        highest_combo_streak=profile.highest_combo_streak,
        total_damage_dealt=profile.total_damage_dealt,
        total_perfect_guards=profile.total_perfect_guards,
        total_awakenings=profile.total_awakenings
    )

@router.put("/profile", response_model=ProfileResponse)
async def update_profile(profile_in: ProfileUpdate, current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(PlayerProfile).where(PlayerProfile.user_id == current_user.id))
    profile = result.scalar_one_or_none()
    if not profile:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Profile not found")

    if profile_in.display_title is not None:
        profile.display_title = profile_in.display_title
    if profile_in.avatar_url is not None:
        profile.avatar_url = profile_in.avatar_url
    if profile_in.favorite_fighter_id is not None:
        profile.favorite_fighter_id = profile_in.favorite_fighter_id

    await db.commit()
    await db.refresh(profile)
    return await get_profile(current_user=current_user, db=db)

@router.get("/rank", response_model=RatingResponse)
async def get_rank(current_user: User = Depends(get_current_user), db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(PlayerRating).where(PlayerRating.user_id == current_user.id))
    rating = result.scalar_one_or_none()
    if not rating:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Rating record not found")

    return RatingResponse(
        user_id=rating.user_id,
        username=current_user.username,
        mmr=rating.mmr,
        tier_name=rating.tier_name,
        league_points=rating.league_points,
        win_streak=rating.win_streak,
        best_rank_tier=rating.best_rank_tier
    )
