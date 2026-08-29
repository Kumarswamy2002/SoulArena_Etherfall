import os
from fastapi import FastAPI
from fastapi.responses import HTMLResponse, RedirectResponse
from fastapi.staticfiles import StaticFiles
from fastapi.middleware.cors import CORSMiddleware
from Backend.app.core.config import settings
from Backend.app.api.v1.api_router import api_router

app = FastAPI(
    title=settings.PROJECT_NAME,
    version=settings.VERSION,
    description="Official REST & Matchmaking Microservices for Soul Arena: Etherfall (3D Action Fighting RPG)",
    openapi_url="/openapi.json",
    docs_url="/docs",
    redoc_url="/redoc"
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

# Compatibility redirect for /api/v1/docs -> /docs
@app.get(f"{settings.API_V1_STR}/docs", include_in_schema=False)
async def redirect_api_v1_docs():
    return RedirectResponse(url="/docs")

# Compatibility redirect for /api/v1/openapi.json -> /openapi.json
@app.get(f"{settings.API_V1_STR}/openapi.json", include_in_schema=False)
async def redirect_api_v1_openapi():
    return RedirectResponse(url="/openapi.json")

# Root Web Dashboard
@app.get("/", response_class=HTMLResponse, tags=["Web Portal"])
async def root_web_portal():
    html_path = os.path.join(os.path.dirname(__file__), "static", "index.html")
    if os.path.exists(html_path):
        with open(html_path, "r", encoding="utf-8") as f:
            return f.read()
    return """
    <html>
        <body style="font-family:sans-serif;background:#0f172a;color:#fff;text-align:center;padding:50px;">
            <h1>⚡ Soul Arena: Etherfall API</h1>
            <p><a href="/docs" style="color:#38bdf8;">Open Interactive Swagger Docs</a></p>
        </body>
    </html>
    """

if __name__ == "__main__":
    import uvicorn
    uvicorn.run("Backend.app.main:app", host="0.0.0.0", port=8000, reload=True)
