from typing import List, Optional
from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select, desc
from Backend.app.core.database import get_db
from Backend.app.models.user import User, PlayerProfile, PlayerRating
from Backend.app.models.match import Match, MatchParticipant, RoundDetail
from Backend.app.models.achievement import ReplayRecord
from Backend.app.schemas.models import MatchReportRequest, MatchResponse, ParticipantReport
from Backend.app.services.ranking_service import RankingService, ValidationService
from Backend.app.api.v1.endpoints.auth import get_current_user

router = APIRouter(prefix="/matches", tags=["Matches"])

@router.post("/report", response_model=MatchResponse, status_code=status.HTTP_201_CREATED)
async def report_match_result(
    report: MatchReportRequest,
    current_user: User = Depends(get_current_user),
    db: AsyncSession = Depends(get_db)
):
    if len(report.participants) < 2:
        raise HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail="Match must have at least 2 participants")

    # Anti-cheat / Server validation
    p1 = report.participants[0]
    p2 = report.participants[1]
    is_valid, reason = ValidationService.validate_match_payload(
        match_duration=report.match_duration_seconds,
        p1_damage_dealt=p1.damage_dealt,
        p2_damage_dealt=p2.damage_dealt,
        p1_max_combo=p1.max_combo,
        p2_max_combo=p2.max_combo,
        total_rounds=len(report.rounds)
    )

    if not is_valid:
        raise HTTPException(status_code=status.HTTP_422_UNPROCESSABLE_ENTITY, detail=f"Match validation failed: {reason}")

    # Determine winner
    winner_id = p1.user_id if p1.is_winner else (p2.user_id if p2.is_winner else None)

    # Create match record
    match = Match(
        game_mode=report.game_mode,
        arena_id=report.arena_id,
        is_ranked=report.is_ranked,
        winner_user_id=winner_id,
        match_duration_seconds=report.match_duration_seconds
    )
    db.add(match)
    await db.flush()

    # Calculate Elo change if ranked
    if report.is_ranked:
        p1_rating_res = await db.execute(select(PlayerRating).where(PlayerRating.user_id == p1.user_id))
        p2_rating_res = await db.execute(select(PlayerRating).where(PlayerRating.user_id == p2.user_id))
        r1 = p1_rating_res.scalar_one_or_none()
        r2 = p2_rating_res.scalar_one_or_none()

        if r1 and r2:
            if p1.is_winner:
                w_delta, l_delta = RankingService.calculate_elo_change(r1.mmr, r2.mmr)
                r1.mmr = max(100, r1.mmr + w_delta)
                r2.mmr = max(100, r2.mmr + l_delta)
                r1.win_streak += 1
                r2.win_streak = 0
            else:
                w_delta, l_delta = RankingService.calculate_elo_change(r2.mmr, r1.mmr)
                r2.mmr = max(100, r2.mmr + w_delta)
                r1.mmr = max(100, r1.mmr + l_delta)
                r2.win_streak += 1
                r1.win_streak = 0

            r1.tier_name = RankingService.get_tier_name(r1.mmr)
            r2.tier_name = RankingService.get_tier_name(r2.mmr)

    # Save participants
    for p in report.participants:
        part = MatchParticipant(
            match_id=match.id,
            user_id=p.user_id,
            slot_index=p.slot_index,
            fighter_id=p.fighter_id,
            is_winner=p.is_winner,
            damage_dealt=p.damage_dealt,
            damage_taken=p.damage_taken,
            max_combo=p.max_combo
        )
        db.add(part)

        # Update profile stats
        prof_res = await db.execute(select(PlayerProfile).where(PlayerProfile.user_id == p.user_id))
        prof = prof_res.scalar_one_or_none()
        if prof:
            prof.total_matches += 1
            if p.is_winner:
                prof.total_wins += 1
            else:
                prof.total_losses += 1
            prof.total_damage_dealt += p.damage_dealt
            prof.highest_combo_streak = max(prof.highest_combo_streak, p.max_combo)

    # Save rounds
    for r in report.rounds:
        rd = RoundDetail(
            match_id=match.id,
            round_number=r.round_number,
            winner_slot=r.winner_slot,
            duration_seconds=r.duration_seconds,
            end_condition=r.end_condition
        )
        db.add(rd)

    # Save replay if provided
    if report.replay_json_payload:
        rep = ReplayRecord(
            match_id=match.id,
            total_frames=int(report.match_duration_seconds * 60),
            replay_json_payload=report.replay_json_payload,
            file_size_bytes=len(report.replay_json_payload.encode("utf-8"))
        )
        db.add(rep)

    await db.commit()
    await db.refresh(match)

    return MatchResponse(
        id=match.id,
        game_mode=match.game_mode,
        arena_id=match.arena_id,
        is_ranked=match.is_ranked,
        winner_user_id=match.winner_user_id,
        match_duration_seconds=match.match_duration_seconds,
        created_at=match.created_at,
        participants=report.participants
    )

@router.get("", response_model=List[MatchResponse])
async def list_matches(limit: int = 20, db: AsyncSession = Depends(get_db)):
    result = await db.execute(select(Match).order_by(desc(Match.created_at)).limit(limit))
    matches = result.scalars().all()
    out = []
    for m in matches:
        out.append(MatchResponse(
            id=m.id,
            game_mode=m.game_mode,
            arena_id=m.arena_id,
            is_ranked=m.is_ranked,
            winner_user_id=m.winner_user_id,
            match_duration_seconds=m.match_duration_seconds,
            created_at=m.created_at,
            participants=[]
        ))
    return out
