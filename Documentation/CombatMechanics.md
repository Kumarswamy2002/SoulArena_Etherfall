# Soul Arena: Etherfall - Combat Mechanics & Defense Manual

## 1. Dual-Resource System

### 1.1 Ether (0 - 100)
- **Generation**: Passively regenerates at `3.5 Ether/sec`. Dealing offensive damage generates bonus Ether (`15%` of damage dealt).
- **Momentum Gauge (0 - 100)**: Dealing consecutive hits fills Momentum, accelerating Ether regeneration up to `2.0x`. Decays at `5.0/sec` when idle.
- **Burnout State**: Draining Ether to `0` triggers a 3-second Burnout lockout during which movement is slower, specials are locked, and defense takes full chip damage.

### 1.2 Resonance & Awakening (0 - 100)
- **Accumulation**: Built exclusively through successful combat interactions:
  - Counter Hits: `+50%` bonus Resonance.
  - Perfect Guards: `+15` flat Resonance.
  - Parries: `+20` flat Resonance.
- **Awakening Activation**: Available at `100 Resonance`. Lasts 20 seconds:
  - `+15%` Outgoing Damage.
  - `-15%` Incoming Damage.
  - `+20%` Movement & Dash Speed.
  - `30%` Cooldown Reduction on all abilities.
  - Unlocks cinematic **Ultimate Finisher** (requires 30 Ether).

---

## 2. Defensive Mechanics Matrix

| Defensive Technique | Input Window | Frame Data / Timing | Reward / Effect |
| :--- | :--- | :--- | :--- |
| **Standard Block** | Hold Guard | Continuous (drains guard meter) | Blocks 80% damage (20% chip damage) |
| **Perfect Guard** | Tap Guard within 4 frames of hit | `0.0667s` (~4 frames) | 100% damage blocked (0 chip), `+15 frames` advantage |
| **Dodge** | Tap Dodge + Direction | 15 invulnerability frames (i-frames) | Full evasion of physical & projectile hits |
| **Perfect Dodge** | Dodge within 5 frames of impact | `0.0833s` (~5 frames) | Trigger visual slowdown & immediate flank positioning |
| **Parry** | Tap Forward + Guard | `0.10s` (6 active frames, 21 recovery) | Staggers attacker for `1.6s`, massive counter window |
| **Combo Breaker** | Burst Escape button during hitstun | Consumes 50 Ether + 25 Resonance | Knocks back attacker and resets enemy combo |
| **Guard Break** | Triggered when Guard Meter reaches 0 | `2.2s` stun duration | Target becomes helpless and takes 100% true damage |

---

## 3. Combo & Juggle Engine
- **Damage Scaling**: Each sequential hit scales damage down by `8%`, floored at a minimum of `15%`.
- **Wall Splat**: Heavy attacks hitting an opponent near the arena perimeter trigger a Wall Splat, bouncing them off the boundary for follow-up juggles (`1.2s` stun).
- **Ground Bounce**: Launchers into downward aerial strikes cause a ground bounce rebound.

---

## 4. Status Effects Compendium (12 Distinct Types)

1. **Burn**: Deals fire DoT every 0.5s and halts natural Ether regeneration.
2. **Freeze**: Completely locks character movement and inputs. Heavy hits shatter the ice for bonus burst damage.
3. **Shock**: Delivers intermittent micro-stuns every 1.5s, disrupting attack startups.
4. **Bleed**: Stacks up to 5 times. Deals accelerated damage whenever the victim dashes or moves.
5. **Silence**: Disables special abilities and prevents Awakening activation.
6. **Slow**: Reduces movement and attack animation speed by 50%.
7. **Blind**: Gives a 40% chance for attacks to whiff and darkens the player's camera edges.
8. **Root**: Prevents dashing, jumping, and translational movement.
9. **Weakness**: Reduces outgoing attack power by 30%.
10. **Armor Break**: Disables defense armor mitigation; all incoming hits deal true damage.
11. **Ether Drain**: Siphons 5 Ether per second directly from target to inflictor.
12. **Healing Reduction**: Reduces all regeneration and healing by 70%.
