# Soul Arena: Etherfall - Backend REST API Reference

Base URL: `/api/v1`

---

## 1. Authentication
### `POST /api/v1/auth/register`
- **Body**: `{"email": "player@soularena.net", "username": "SoulChampion", "password": "SecurePassword123!"}`
- **Response**: `201 Created`
  ```json
  {
    "id": "uuid-v4-string",
    "email": "player@soularena.net",
    "username": "SoulChampion",
    "is_active": true,
    "created_at": "2026-08-29T12:00:00Z"
  }
  ```

### `POST /api/v1/auth/login`
- **Body**: `{"username_or_email": "SoulChampion", "password": "SecurePassword123!"}`
- **Response**: `200 OK`
  ```json
  {
    "access_token": "jwt-bearer-token-string",
    "token_type": "bearer"
  }
  ```

---

## 2. Player Profiles & Rating
### `GET /api/v1/player/profile` *(Requires Bearer Auth)*
- **Response**: `200 OK`
  ```json
  {
    "user_id": "uuid",
    "username": "SoulChampion",
    "display_title": "Storm Vanguard",
    "avatar_url": "https://assets.soularena.net/avatars/kael.png",
    "favorite_fighter_id": "kael_varyn",
    "total_matches": 142,
    "total_wins": 98,
    "total_losses": 44,
    "win_rate": 69.01,
    "highest_combo_streak": 22,
    "total_damage_dealt": 134200.0,
    "total_perfect_guards": 89,
    "total_awakenings": 115
  }
  ```

### `GET /api/v1/player/rank` *(Requires Bearer Auth)*
- **Response**: `200 OK`
  ```json
  {
    "user_id": "uuid",
    "username": "SoulChampion",
    "mmr": 2150,
    "tier_name": "Master",
    "league_points": 75,
    "win_streak": 6,
    "best_rank_tier": "Master"
  }
  ```

---

## 3. Matchmaking & Matches
### `POST /api/v1/matchmaking/join` *(Requires Bearer Auth)*
- **Body**: `{"game_mode": "OneVsOne", "preferred_fighter": "kael_varyn"}`
- **Response**: `200 OK`
  ```json
  {
    "ticket_id": "ticket_ab12cd34ef56",
    "status": "queuing",
    "match_id": null,
    "server_address": null
  }
  ```

### `POST /api/v1/matches/report` *(Requires Bearer Auth)*
- **Body**:
  ```json
  {
    "game_mode": "OneVsOne",
    "arena_id": "SkyforgeTemple",
    "is_ranked": true,
    "match_duration_seconds": 74.5,
    "participants": [
      {
        "user_id": "user-uuid-1",
        "slot_index": 1,
        "fighter_id": "kael_varyn",
        "is_winner": true,
        "damage_dealt": 1050.0,
        "damage_taken": 620.0,
        "max_combo": 14
      },
      {
        "user_id": "user-uuid-2",
        "slot_index": 2,
        "fighter_id": "ryka_voss",
        "is_winner": false,
        "damage_dealt": 620.0,
        "damage_taken": 1050.0,
        "max_combo": 9
      }
    ],
    "rounds": [
      { "round_number": 1, "winner_slot": 1, "duration_seconds": 38.0, "end_condition": "KO" },
      { "round_number": 2, "winner_slot": 1, "duration_seconds": 36.5, "end_condition": "KO" }
    ],
    "replay_json_payload": "{\"match_id\":\"uuid\",\"total_frames\":4470,...}"
  }
  ```

---

## 4. Leaderboard & Characters
### `GET /api/v1/leaderboard?limit=50`
### `GET /api/v1/characters`
### `GET /api/v1/characters/{id}`
### `GET /api/v1/achievements`
