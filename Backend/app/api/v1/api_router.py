from fastapi import APIRouter
from Backend.app.api.v1.endpoints import (
    auth,
    player,
    characters,
    matchmaking,
    matches,
    leaderboard,
    achievements
)

api_router = APIRouter()

api_router.include_router(auth.router)
api_router.include_router(player.router)
api_router.include_router(characters.router)
api_router.include_router(matchmaking.router)
api_router.include_router(matches.router)
api_router.include_router(leaderboard.router)
api_router.include_router(achievements.router)
