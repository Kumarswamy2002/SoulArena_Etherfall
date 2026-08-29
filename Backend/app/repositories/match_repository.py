# MatchRepository: Data access layer for match history, rounds, and participant telemetry
from typing import List, Optional
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select, desc

class MatchRepository:
    def __init__(self, db: AsyncSession):
        self.db = db

    async def ping(self) -> bool:
        return True
