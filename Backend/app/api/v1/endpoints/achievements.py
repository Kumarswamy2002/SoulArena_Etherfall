from typing import List
from fastapi import APIRouter
from pydantic import BaseModel

router = APIRouter(prefix="/achievements", tags=["Achievements"])

class AchievementItem(BaseModel):
    id: str
    name: str
    description: str
    reward_points: int

ACHIEVEMENT_CATALOG = [
    {"id": "first_blood", "name": "First Blood", "description": "Win your first combat match.", "reward_points": 10},
    {"id": "awakening_mastery", "name": "True Resonance", "description": "Trigger Awakening 25 times.", "reward_points": 25},
    {"id": "combo_king", "name": "Unbroken Flow", "description": "Land a 15-hit combo in ranked combat.", "reward_points": 50},
    {"id": "perfect_parry", "name": "Iron Reflexes", "description": "Perform 10 Perfect Parries.", "reward_points": 30},
    {"id": "grandmaster_rank", "name": "Soulforged Legend", "description": "Reach Grandmaster rating tier.", "reward_points": 100},
    {"id": "all_fighters", "name": "Master of Roster", "description": "Win a match with each of the 20 fighters.", "reward_points": 150}
]

@router.get("", response_model=List[AchievementItem])
async def list_achievements():
    return ACHIEVEMENT_CATALOG
