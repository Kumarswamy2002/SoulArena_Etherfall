using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Combat
{
    public class ActiveStatusEffect
    {
        public StatusEffectType Type;
        public float DurationRemaining;
        public float MaxDuration;
        public float Potency; // Tick damage, slow factor, or drain amount
        public int Stacks;
        public float TickTimer;
        public int InflictorId;

        public ActiveStatusEffect(StatusEffectType type, float duration, float potency, int inflictorId, int stacks = 1)
        {
            Type = type;
            MaxDuration = duration;
            DurationRemaining = duration;
            Potency = potency;
            InflictorId = inflictorId;
            Stacks = stacks;
            TickTimer = 0.0f;
        }
    }

    /// <summary>
    /// Complete implementation of all 12 combat status effects:
    /// Burn, Freeze, Shock, Bleed, Silence, Slow, Blind, Root, Weakness, ArmorBreak, EtherDrain, HealingReduction.
    /// </summary>
    public class StatusEffectSystem
    {
        public int FighterId { get; private set; }
        private readonly Dictionary<StatusEffectType, ActiveStatusEffect> _activeEffects = new Dictionary<StatusEffectType, ActiveStatusEffect>();

        public event Action<StatusEffectType, int> OnStatusApplied;
        public event Action<StatusEffectType> OnStatusExpired;
        public event Action<float, StatusEffectType, int> OnStatusDamageTick;
        public event Action<float, int> OnEtherDrained;

        public StatusEffectSystem(int fighterId)
        {
            FighterId = fighterId;
        }

        public bool HasStatus(StatusEffectType type)
        {
            return _activeEffects.ContainsKey(type) && _activeEffects[type].DurationRemaining > 0;
        }

        public ActiveStatusEffect GetStatus(StatusEffectType type)
        {
            _activeEffects.TryGetValue(type, out var effect);
            return effect;
        }

        public void ApplyStatus(StatusEffectType type, float duration, float potency, int inflictorId)
        {
            if (type == StatusEffectType.None || duration <= 0.0f) return;

            if (_activeEffects.TryGetValue(type, out var existing))
            {
                // Refresh duration and stack if applicable (e.g. Bleed stacks up to 5)
                existing.DurationRemaining = Math.Max(existing.DurationRemaining, duration);
                if (type == StatusEffectType.Bleed && existing.Stacks < 5)
                {
                    existing.Stacks++;
                    existing.Potency += potency * 0.5f;
                }
                else
                {
                    existing.Potency = Math.Max(existing.Potency, potency);
                }
                OnStatusApplied?.Invoke(type, existing.Stacks);
            }
            else
            {
                var newEffect = new ActiveStatusEffect(type, duration, potency, inflictorId, 1);
                _activeEffects[type] = newEffect;
                OnStatusApplied?.Invoke(type, 1);
            }
        }

        public void RemoveStatus(StatusEffectType type)
        {
            if (_activeEffects.Remove(type))
            {
                OnStatusExpired?.Invoke(type);
            }
        }

        public void ClearAllStatuses()
        {
            var keys = new List<StatusEffectType>(_activeEffects.Keys);
            foreach (var key in keys)
            {
                RemoveStatus(key);
            }
        }

        public void Update(float deltaTime, bool isMoving)
        {
            var expiredStatuses = new List<StatusEffectType>();

            foreach (var kvp in _activeEffects)
            {
                var effect = kvp.Value;
                effect.DurationRemaining -= deltaTime;
                effect.TickTimer += deltaTime;

                // Process periodic effects (ticks every 0.5s or 1.0s)
                switch (effect.Type)
                {
                    case StatusEffectType.Burn:
                        if (effect.TickTimer >= 0.5f)
                        {
                            effect.TickTimer = 0.0f;
                            float burnDamage = effect.Potency * 0.5f;
                            OnStatusDamageTick?.Invoke(burnDamage, StatusEffectType.Burn, effect.InflictorId);
                        }
                        break;

                    case StatusEffectType.Bleed:
                        // Bleed deals tick damage + accelerated damage when the target moves/dashes
                        float tickInterval = isMoving ? 0.25f : 1.0f;
                        if (effect.TickTimer >= tickInterval)
                        {
                            effect.TickTimer = 0.0f;
                            float bleedDamage = effect.Potency * effect.Stacks * (isMoving ? 1.5f : 0.8f);
                            OnStatusDamageTick?.Invoke(bleedDamage, StatusEffectType.Bleed, effect.InflictorId);
                        }
                        break;

                    case StatusEffectType.EtherDrain:
                        if (effect.TickTimer >= 1.0f)
                        {
                            effect.TickTimer = 0.0f;
                            OnEtherDrained?.Invoke(effect.Potency, effect.InflictorId);
                        }
                        break;

                    case StatusEffectType.Shock:
                        // Shock triggers intermittent micro-stuns every 1.5s
                        if (effect.TickTimer >= 1.5f)
                        {
                            effect.TickTimer = 0.0f;
                            OnStatusDamageTick?.Invoke(effect.Potency, StatusEffectType.Shock, effect.InflictorId);
                        }
                        break;
                }

                if (effect.DurationRemaining <= 0.0f)
                {
                    expiredStatuses.Add(effect.Type);
                }
            }

            foreach (var expired in expiredStatuses)
            {
                RemoveStatus(expired);
            }
        }

        // Modifiers queried by Combat Engine
        public float GetSpeedModifier()
        {
            if (HasStatus(StatusEffectType.Freeze)) return 0.0f;
            if (HasStatus(StatusEffectType.Slow)) return 0.50f;
            return 1.0f;
        }

        public float GetOutgoingDamageModifier()
        {
            if (HasStatus(StatusEffectType.Weakness)) return 0.70f;
            return 1.0f;
        }

        public bool CanUseSpecialAbilities()
        {
            return !HasStatus(StatusEffectType.Silence) && !HasStatus(StatusEffectType.Freeze);
        }

        public bool CanMoveOrDash()
        {
            return !HasStatus(StatusEffectType.Root) && !HasStatus(StatusEffectType.Freeze);
        }

        public float GetHealingMultiplier()
        {
            if (HasStatus(StatusEffectType.HealingReduction)) return 0.30f;
            return 1.0f;
        }

        public bool IsBlind()
        {
            return HasStatus(StatusEffectType.Blind);
        }

        public bool IsArmorBroken()
        {
            return HasStatus(StatusEffectType.ArmorBreak);
        }
    }
}
