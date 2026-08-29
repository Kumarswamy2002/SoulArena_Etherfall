import redis.asyncio as aioredis
from typing import Optional
from Backend.app.core.config import settings

class RedisManager:
    def __init__(self):
        self.redis: Optional[aioredis.Redis] = None

    async def connect(self):
        self.redis = await aioredis.from_url(
            settings.REDIS_URL,
            encoding="utf-8",
            decode_responses=True
        )

    async def close(self):
        if self.redis:
            await self.redis.close()

    async def get_client(self) -> aioredis.Redis:
        if not self.redis:
            await self.connect()
        return self.redis

redis_manager = RedisManager()

async def get_redis() -> aioredis.Redis:
    return await redis_manager.get_client()
