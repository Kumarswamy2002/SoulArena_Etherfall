import uuid
import json
from fastapi import APIRouter, Depends, HTTPException, status
from pydantic import BaseModel
from Backend.app.models.user import User
from Backend.app.schemas.models import MatchmakingTicket
from Backend.app.api.v1.endpoints.auth import get_current_user

router = APIRouter(prefix="/matchmaking", tags=["Matchmaking"])

class JoinQueueRequest(BaseModel):
    game_mode: str = "OneVsOne"
    preferred_fighter: str = "kael_varyn"

@router.post("/join", response_model=MatchmakingTicket)
async def join_queue(req: JoinQueueRequest, current_user: User = Depends(get_current_user)):
    # In a full live cluster, this pushes to Redis sorted sets/lists
    ticket_id = f"ticket_{uuid.uuid4().hex[:12]}"
    return MatchmakingTicket(
        ticket_id=ticket_id,
        status="queuing",
        match_id=None,
        server_address=None
    )

@router.post("/leave")
async def leave_queue(current_user: User = Depends(get_current_user)):
    return {"message": "Successfully left matchmaking queue", "status": "cancelled"}

@router.get("/status/{ticket_id}", response_model=MatchmakingTicket)
async def check_queue_status(ticket_id: str, current_user: User = Depends(get_current_user)):
    return MatchmakingTicket(
        ticket_id=ticket_id,
        status="matched",
        match_id=f"match_{uuid.uuid4().hex[:8]}",
        server_address="us-east.soularena.net:7777"
    )
