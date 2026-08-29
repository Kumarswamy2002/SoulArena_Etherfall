# UserRepository: Data access layer for user authentication and credentials
from typing import List, Optional
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy import select, desc

class UserRepository:
    def __init__(self, db: AsyncSession):
        self.db = db

    async def ping(self) -> bool:
        return True
