import os
from typing import List
from pydantic_settings import BaseSettings, SettingsConfigDict

class Settings(BaseSettings):
    PROJECT_NAME: str = "Soul Arena: Etherfall API"
    VERSION: str = "1.0.0"
    API_V1_STR: str = "/api/v1"
    
    # Security
    SECRET_KEY: str = os.getenv("SECRET_KEY", "soul-arena-etherfall-ultra-secure-jwt-secret-key-2026")
    ALGORITHM: str = "HS256"
    ACCESS_TOKEN_EXPIRE_MINUTES: int = 60 * 24 * 7 # 7 days

    # Database
    DATABASE_URL: str = os.getenv("DATABASE_URL", "postgresql+asyncpg://soularena:soularenapass@localhost:5432/soularenadb")
    
    # Redis Cache & Matchmaking
    REDIS_URL: str = os.getenv("REDIS_URL", "redis://localhost:6379/0")

    # CORS
    CORS_ORIGINS: List[str] = ["*"]

    # Matchmaking Settings
    MATCHMAKING_MMR_TOLERANCE: int = 150
    MATCHMAKING_EXPANSION_RATE_PER_SEC: int = 10
    MAX_QUEUE_WAIT_SECONDS: int = 60

    model_config = SettingsConfigDict(case_sensitive=True, env_file=".env", extra="ignore")

settings = Settings()
