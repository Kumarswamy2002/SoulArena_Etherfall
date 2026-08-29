using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Ether;
using SoulArena.Awakening;
using SoulArena.Combat;

namespace SoulArena.Abilities
{
    public class AbilityController
    {
        public int FighterId { get; private set; }
        private readonly Dictionary<string, AbilityData> _abilities = new Dictionary<string, AbilityData>();
        private readonly Dictionary<string, float> _cooldowns = new Dictionary<string, float>();

        public event Action<string> OnAbilityCastStarted;
        public event Action<string> OnAbilityCastCompleted;
        public event Action<string> OnAbilityInterrupted;

        public AbilityController(int fighterId)
        {
            FighterId = fighterId;
        }

        public void RegisterAbility(AbilityData ability)
        {
            if (ability == null || string.IsNullOrEmpty(ability.AbilityId)) return;
            _abilities[ability.AbilityId] = ability;
            _cooldowns[ability.AbilityId] = 0.0f;
        }

        public AbilityData GetAbility(string abilityId)
        {
            _abilities.TryGetValue(abilityId, out var ability);
            return ability;
        }

        public float GetCooldownRemaining(string abilityId)
        {
            _cooldowns.TryGetValue(abilityId, out float cd);
            return Math.Max(0.0f, cd);
        }

        public bool IsAbilityReady(string abilityId, EtherResource ether, StatusEffectSystem status)
        {
            if (!_abilities.TryGetValue(abilityId, out var ability)) return false;
            if (GetCooldownRemaining(abilityId) > 0.0f) return false;
            if (status != null && !status.CanUseSpecialAbilities()) return false;
            if (ether == null || ether.CurrentEther < ability.EtherCost) return false;

            return true;
        }

        public bool TryCastAbility(string abilityId, EtherResource ether, AwakeningController awakening, StatusEffectSystem status, out AbilityData abilityData)
        {
            abilityData = null;
            if (!IsAbilityReady(abilityId, ether, status)) return false;

            abilityData = _abilities[abilityId];
            if (!ether.TryConsume(abilityData.EtherCost)) return false;

            // Apply cooldown, modified by Awakening cooldown reduction
            float baseCd = abilityData.CooldownSeconds;
            if (awakening != null && awakening.IsAwakened)
            {
                baseCd *= (1.0f - awakening.Modifiers.CooldownReduction);
            }
            _cooldowns[abilityId] = baseCd;

            OnAbilityCastStarted?.Invoke(abilityId);
            return true;
        }

        public void Update(float deltaTime)
        {
            var keys = new List<string>(_cooldowns.Keys);
            foreach (var key in keys)
            {
                if (_cooldowns[key] > 0.0f)
                {
                    _cooldowns[key] -= deltaTime;
                    if (_cooldowns[key] <= 0.0f)
                    {
                        _cooldowns[key] = 0.0f;
                        OnAbilityCastCompleted?.Invoke(key);
                    }
                }
            }
        }

        public void ResetCooldowns()
        {
            var keys = new List<string>(_cooldowns.Keys);
            foreach (var key in keys)
            {
                _cooldowns[key] = 0.0f;
            }
        }
    }
}
