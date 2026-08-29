# RatingRepository: Data access layer for player Elo MMR ratings and leaderboards
from typing import List, Optional
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select, desc

class RatingRepository:
    def __init__(self, db: AsyncSession):
        self.db = db

    async def ping(self) -> bool:
        return True
