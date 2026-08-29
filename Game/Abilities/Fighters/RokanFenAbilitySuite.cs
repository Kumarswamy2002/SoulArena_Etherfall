using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Abilities;

namespace SoulArena.Abilities.Fighters
{
    /// <summary>
    /// Complete Special Ability Suite for Rokan Fen (Beast Soul).
    /// Element: Beast | Archetype: CloseCombat
    /// Implements: Ability 1 (Special Surge), Ability 2 (Area Hazard), Ability 3 (Mobility/Counter), Ultimate Finisher.
    /// </summary>
    public class RokanFenAbilitySuite
    {
        public string FighterId { get; } = "rokan_fen";
        public EtherElement Element { get; } = EtherElement.Beast;

        public float Ability1Cooldown { get; private set; } = 0.0f;
        public float Ability2Cooldown { get; private set; } = 0.0f;
        public float Ability3Cooldown { get; private set; } = 0.0f;
        public float UltimateCooldown { get; private set; } = 0.0f;

        public const float ABILITY1_MAX_CD = 4.5f;
        public const float ABILITY2_MAX_CD = 7.0f;
        public const float ABILITY3_MAX_CD = 9.0f;
        public const float ULTIMATE_MAX_CD = 25.0f;

        public event Action<string, Vector3D> OnAbilityCast;
        public event Action<string> OnUltimateFired;

        public bool ExecuteAbility1(FighterBase caster, FighterBase target)
        {
            if (Ability1Cooldown > 0.0f || caster.Ether.CurrentEther < 25.0f) return false;
            caster.Ether.ConsumeEther(25.0f);
            Ability1Cooldown = ABILITY1_MAX_CD;

            OnAbilityCast?.Invoke("rokan_fen_ability_1_surge", caster.Position);
            return true;
        }

        public bool ExecuteAbility2(FighterBase caster, FighterBase target)
        {
            if (Ability2Cooldown > 0.0f || caster.Ether.CurrentEther < 35.0f) return false;
            caster.Ether.ConsumeEther(35.0f);
            Ability2Cooldown = ABILITY2_MAX_CD;

            OnAbilityCast?.Invoke("rokan_fen_ability_2_hazard", caster.Position);
            return true;
        }

        public bool ExecuteAbility3(FighterBase caster, FighterBase target)
        {
            if (Ability3Cooldown > 0.0f || caster.Ether.CurrentEther < 30.0f) return false;
            caster.Ether.ConsumeEther(30.0f);
            Ability3Cooldown = ABILITY3_MAX_CD;

            OnAbilityCast?.Invoke("rokan_fen_ability_3_mobility", caster.Position);
            return true;
        }

        public bool ExecuteUltimate(FighterBase caster, FighterBase target)
        {
            if (UltimateCooldown > 0.0f || caster.Ether.CurrentEther < 50.0f || !caster.Resonance.IsAwakeningReady) return false;
            caster.Ether.ConsumeEther(50.0f);
            UltimateCooldown = ULTIMATE_MAX_CD;

            OnUltimateFired?.Invoke("rokan_fen_ultimate_finisher");
            return true;
        }

        public void UpdateCooldowns(float deltaTime)
        {
            if (Ability1Cooldown > 0.0f) Ability1Cooldown = Math.Max(0.0f, Ability1Cooldown - deltaTime);
            if (Ability2Cooldown > 0.0f) Ability2Cooldown = Math.Max(0.0f, Ability2Cooldown - deltaTime);
            if (Ability3Cooldown > 0.0f) Ability3Cooldown = Math.Max(0.0f, Ability3Cooldown - deltaTime);
            if (UltimateCooldown > 0.0f) UltimateCooldown = Math.Max(0.0f, UltimateCooldown - deltaTime);
        }
    }
}
