# ⚡ SOUL ARENA: ETHERFALL (Public GitHub Edition)

[![CI Backend](https://github.com/SoulArena/SoulArena/actions/workflows/ci-backend.yml/badge.svg)](https://github.com/SoulArena/SoulArena/actions/workflows/ci-backend.yml)
[![CI Game](https://github.com/SoulArena/SoulArena/actions/workflows/ci-game.yml/badge.svg)](https://github.com/SoulArena/SoulArena/actions/workflows/ci-game.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Engine: Unity 2022.3 LTS](https://img.shields.io/badge/Engine-Unity_2022.3_LTS-black.svg)](https://unity.com/)
[![Backend: FastAPI + Redis + Postgres](https://img.shields.io/badge/Backend-FastAPI_Python_3.12-green.svg)](https://fastapi.tiangolo.com/)

> **Soul Arena: Etherfall** is an original-IP 3D competitive fighting arena / action RPG. Players control unique Soulforged fighters manipulating **Ether**, an original internal energy and resonance system. Featuring high-velocity combat, frame-accurate cancels, juggles, perfect defense, awakenings, and interactive dynamic arenas.

---

## 🌟 Key Features

- 🎮 **20 Unique Original Fighters**: Distinct roles (Rushdown, Tank, Assassin, Summoner, Power Fighter, Boss), full move chains, passives, and cinematic Ultimates.
- ⚡ **Original Energy Architecture**: Dual-resource engine powering movement and specials (**Ether**) and synergy transformations (**Resonance & Awakening**).
- 🛡️ **Defensive Combat Depth**: Guard meter, Guard Break, **Perfect Guard** (4-frame advantage), **Perfect Dodge** (slow-motion trigger), **Parry** (1.6s counter stagger), and **Combo Breakers**.
- 🏟️ **10 Interactive Arenas**: Hazard zones (lava geysers, low-gravity rifts, slippery ice, water surges), breakable pillars/crates, and dynamic 3-phase stage collapses.
- 🤖 **Adaptive Utility AI**: 6 Difficulty Presets (*Beginner* to *Grandmaster*) & 6 Fighter Personalities (*Aggressive, Defensive, Tactical, Evasive, Counter Fighter, Combo Fighter*).
- 🏆 **11 Rich Game Modes**: 1v1, 2v2 Tag, 3v3 Elimination, Free For All, Training Mode (frame data overlay), Casual, Ranked, Tournament, Survival, Boss Battle, and Story Mode.
- 🌐 **Online Rollback Ready & Microservice Backend**: Deterministic frame recording/playback, rollback prediction, FastAPI backend, PostgreSQL database, Redis matchmaking, and anti-cheat validation.
- 🛠️ **Developer Tools & Telemetry**: Character, Ability, Combo, and Arena Editors, plus live AI & Match state debuggers.

---

## 📂 Repository Structure

```
SoulArena/
├── Game/
│   ├── Core/               # Engine foundation, events, math, pooling, inputs, frame timers
│   ├── Characters/         # Character base, stats, definitions, and 20 fighter implementations
│   ├── Combat/             # Hitboxes, hurtboxes, damage pipeline, defense, parry, status effects
│   ├── Combos/             # Combo trees, cancel windows, juggles, wall splat, scaling
│   ├── Abilities/          # Ability pipeline, projectiles, AoE, channeling
│   ├── Ether/              # Ether resource, momentum, burnout lockout
│   ├── Resonance/          # Resonance accumulation & Awakening triggers
│   ├── Awakening/          # Awakening state modifiers, transformation VFX, ultimates
│   ├── AI/                 # 6 Personalities, 6 Difficulties, Utility AI decision trees
│   ├── Arenas/             # 10 Arena controllers, destructibles, hazard zones, factory
│   ├── GameModes/          # 1v1, Training, Survival, Tournament, Boss, Casual, Ranked
│   ├── Match/              # Match coordinator, round timers, collisions, results
│   ├── Story/              # Dialogue runner, chapters, custom encounter objectives
│   ├── Replay/             # Frame-by-frame input recorder, deterministic replay player
│   └── Spectator/          # Dynamic director camera, combat telemetry HUD
├── UI/                     # Combat HUD, character select grid, health/ether meters
├── Networking/             # Rollback netcode manager, snapshots, desync detection
├── Backend/                # FastAPI backend microservices (Auth, MMR, Matchmaking, Replays)
│   ├── app/
│   │   ├── api/v1/         # REST API endpoints
│   │   ├── core/           # Security, config, database, redis pool
│   │   ├── models/         # SQLAlchemy ORM models
│   │   ├── schemas/        # Pydantic v2 schemas
│   │   └── services/       # Matchmaking queue, Elo rating, server anti-cheat validator
│   └── tests/              # Pytest async test suite (100% passing)
├── Tools/                  # Character Editor, Ability Editor, AI Debugger
├── Tests/                  # C# Gameplay, Combat, Ether, and Roster tests
├── Documentation/          # Architecture, Fighter Compendium, Arena Guide, API, Combat Specs
├── Docker/                 # Dockerfile.backend, Dockerfile.unity, docker-compose.yml
└── .github/workflows/      # Automated CI/CD workflows for backend and game builds
```

---

## 🚀 Quickstart & Setup

### 1. Run Backend with Docker Compose
```bash
cd Docker
docker compose up --build -d
```
The REST API will be available at `http://localhost:8000/api/v1` with interactive OpenAPI docs at `http://localhost:8000/api/v1/docs`.

### 2. Run Backend Locally (Python 3.11 / 3.12)
```bash
pip install -r Backend/requirements.txt
python -m uvicorn Backend.app.main:app --reload --port 8000
```

### 3. Run Automated Tests
```bash
# Run Backend Test Suite
pytest Backend/tests/ -v
```

---

## 📖 Documentation Quicklinks

- 📐 [Architecture & Engineering Guide](file:///Documentation/Architecture.md)
- 🥋 [20 Fighter Compendium](file:///Documentation/FighterCompendium.md)
- 🏟️ [10 Arena & Hazards Guide](file:///Documentation/ArenaGuide.md)
- ⚔️ [Combat Mechanics & Defense Manual](file:///Documentation/CombatMechanics.md)
- 🌐 [REST API Specification](file:///Documentation/ApiReference.md)

---

## ⚖️ License
Released under the MIT License. Soul Arena: Etherfall is an original IP.
