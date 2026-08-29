#!/usr/bin/env python3
"""
Soul Arena: Etherfall - Master Launcher & Microservice Entrypoint
"""
import sys
import uvicorn
from Backend.app.core.config import settings

def main():
    print(f"============================================================")
    print(f"  {settings.PROJECT_NAME} v{settings.VERSION}")
    print(f"  Starting High-Performance Combat & Matchmaking Services...")
    print(f"============================================================")
    uvicorn.run(
        "Backend.app.main:app",
        host="0.0.0.0",
        port=8000,
        reload=False,
        log_level="info"
    )

if __name__ == "__main__":
    main()
