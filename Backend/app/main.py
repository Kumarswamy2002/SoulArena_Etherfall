from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from Backend.app.core.config import settings
from Backend.app.api.v1.api_router import api_router

app = FastAPI(
    title=settings.PROJECT_NAME,
    version=settings.VERSION,
    description="Official REST & Matchmaking Microservices for Soul Arena: Etherfall (3D Action Fighting RPG)",
    openapi_url=f"{settings.API_V1_STR}/openapi.json",
    docs_url=f"{settings.API_V1_STR}/docs",
    redoc_url=f"{settings.API_V1_STR}/redoc"
)

# CORS Middleware
app.add_middleware(
    CORSMiddleware,
    allow_origins=settings.CORS_ORIGINS,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

app.include_router(api_router, prefix=settings.API_V1_STR)

@app.get("/health", tags=["Health"])
async def health_check():
    return {
        "status": "healthy",
        "service": settings.PROJECT_NAME,
        "version": settings.VERSION,
        "mode": "production-ready"
    }

if __name__ == "__main__":
    import uvicorn
    uvicorn.run("Backend.app.main:app", host="0.0.0.0", port=8000, reload=True)
