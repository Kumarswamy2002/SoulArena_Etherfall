# Soul Arena: Etherfall - System Architecture & Engineering Guide

## 1. Overview & Core Philosophy
**Soul Arena: Etherfall** is a high-octane 3D fighting arena / action RPG developed with a high-performance Unity C# deterministic simulation engine and an asynchronous Python (FastAPI + PostgreSQL + Redis) backend microservice suite.

### Core Architectural Pillars
- **Deterministic 60 FPS Game Loop**: Fixed-frame physics step, hitstop freezing, discrete frame data buffers, and zero-allocation object pools.
- **Data-Driven Combat Pipeline**: Hitboxes, hurtboxes, cancel windows, and ability definitions configured via modular data structs.
- **Rollback Networking (GGPO Paradigm)**: Snapshot ring buffers, client-side input prediction, and retroactive simulation rollbacks (up to 8 frames).
- **Original IP Energy Mechanics**: Dual-resource engine featuring **Ether** (tactical stamina / special fuel) and **Resonance** (awakening synergy meter).

---

## 2. Unity C# Game Architecture

```
                       +-------------------------+
                       |    Input Buffer (60Hz)  |
                       +------------+------------+
                                    |
                                    v
                       +-------------------------+
                       |   Fighter State Machine |
                       +------------+------------+
                                    |
                  +-----------------+-----------------+
                  |                                   |
                  v                                   v
    +---------------------------+       +---------------------------+
    |     Hitbox / Hurtbox      |       |      Combat Defense       |
    |    Spatial Collision      |       |    (Block, Parry, Dodge)  |
    +-------------+-------------+       +-------------+-------------+
                  |                                   |
                  +-----------------+-----------------+
                                    |
                                    v
                       +-------------------------+
                       |     Damage Calculator   |
                       | (Armor, Scaling, Crits) |
                       +------------+------------+
                                    |
                  +-----------------+-----------------+
                  |                                   |
                  v                                   v
    +---------------------------+       +---------------------------+
    |   Status Effect Engine    |       |      Resource Engine      |
    |   (12 Dynamic Ailments)   |       |   (Ether & Resonance)     |
    +---------------------------+       +---------------------------+
```

### 2.1 State Machine & Frame Progression
Each fighter is governed by a hierarchical finite state machine (`StateMachine<FighterBase>`). Movement and attacks proceed frame-by-frame:
1. **Startup Frames**: Windup animation before active hitboxes ignite. Counter-hit vulnerable.
2. **Active Frames**: Hitbox active window executing spatial capsule-sphere collision tests.
3. **Recovery Frames**: Cooldown wind-down frames. Cancel windows allow chaining into permitted follow-ups.

### 2.2 Hitstop & Impact Freezing
When heavy attacks, parries, or ultimates connect, the `FrameTimer` injects discrete freeze frames into the deterministic loop without freezing animations or UI timers, delivering visceral kinetic feedback.

---

## 3. Backend Microservice Architecture

The backend is built as a high-throughput async microservice leveraging:
- **FastAPI**: Asynchronous REST endpoints with auto-generated OpenAPI documentation.
- **SQLAlchemy 2.0 (asyncpg)**: Fully asynchronous PostgreSQL connection pool.
- **Redis 7**: Distributed queue for matchmaking tickets and real-time rating updates.
- **Bcrypt & JWT (HS256)**: Secure stateless authentication with password hashing.

### Database Schema Entity-Relationship
- `users` (id, email, username, hashed_password, is_active, created_at)
  - `player_profiles` (user_id [FK], display_title, favorite_fighter_id, total_matches, wins, losses, combo_streak, damage_dealt)
  - `player_ratings` (user_id [FK], mmr, tier_name, league_points, win_streak)
  - `matches` (id, game_mode, arena_id, is_ranked, winner_user_id, match_duration_seconds)
    - `match_participants` (id, match_id [FK], user_id [FK], slot_index, fighter_id, is_winner, damage_dealt, max_combo)
    - `round_details` (id, match_id [FK], round_number, winner_slot, duration_seconds, end_condition)
    - `replays` (id, match_id [FK], total_frames, replay_json_payload, file_size_bytes)
  - `player_achievements` (id, user_id [FK], achievement_id [FK], unlocked_at)

---

## 4. Matchmaking & Rating Engine
- **Elo / MMR Calculation**: Computes expected victory probabilities using standard logistical curves with a dynamic K-factor (K=32).
- **Anti-Cheat Validation**: Ingests match result telemetry and verifies match duration, max DPS limits, combo lengths, and round integrity before confirming rating adjustments.
