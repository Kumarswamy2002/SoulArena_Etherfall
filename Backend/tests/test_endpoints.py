import sys
from pathlib import Path

# Bootstrap sys.path to guarantee root package resolution across all runners
_ROOT = Path(__file__).resolve().parents[2]
if str(_ROOT) not in sys.path:
    sys.path.insert(0, str(_ROOT))

import pytest
from fastapi.testclient import TestClient
from Backend.app.main import app
from Backend.app.core.security import create_access_token, get_password_hash, verify_password

client = TestClient(app)

def test_health_endpoint():
    response = client.get("/health")
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "healthy"
    assert "Soul Arena" in data["service"]

def test_characters_endpoint():
    response = client.get("/api/v1/characters")
    assert response.status_code == 200
    data = response.json()
    assert len(data) == 20
    fighter_ids = [char["id"] for char in data]
    assert "kael_varyn" in fighter_ids
    assert "auren_zeth" in fighter_ids

def test_character_detail():
    response = client.get("/api/v1/characters/kael_varyn")
    assert response.status_code == 200
    data = response.json()
    assert data["name"] == "Kael Varyn"
    assert data["element"] == "Storm"

def test_achievements_endpoint():
    response = client.get("/api/v1/achievements")
    assert response.status_code == 200
    data = response.json()
    assert len(data) >= 6

def test_password_hashing():
    raw_pass = "StormBlade2026!"
    hashed = get_password_hash(raw_pass)
    assert verify_password(raw_pass, hashed)
    assert not verify_password("WrongPassword", hashed)

def test_jwt_token_generation():
    token = create_access_token("test-user-id-123")
    assert token is not None
    assert isinstance(token, str)
