using System;
using SoulArena.Core;
using SoulArena.Combat;
using SoulArena.Characters;

namespace SoulArena.Characters.Mechanics
{
    /// <summary>
    /// Deep Combat Subsystem & Unique Passive Logic for Auren Zeth (First Soul).
    /// Element: PrimeEther | Role: BossAdvanced
    /// </summary>
    public class AurenZethMechanicsController
    {
        public int FighterId { get; }
        public float SpecializedResourceMeter { get; private set; } = 0.0f;
        public int ComboHitAccumulator { get; private set; } = 0;
        public bool IsPassiveTriggered { get; private set; } = false;
        public float PassiveCooldownRemaining { get; private set; } = 0.0f;

        public event Action<float> OnSpecializedMeterChanged;
        public event Action<string> OnPassiveSkillProc;

        public AurenZethMechanicsController(int fighterId)
        {
            FighterId = fighterId;
        }

        public void ProcessHitDelivered(HitResult hit, FighterBase attacker, FighterBase defender)
        {
            if (!hit.HitConnected) return;

            ComboHitAccumulator++;
            SpecializedResourceMeter = MathUtility.Clamp(SpecializedResourceMeter + 10.0f, 0.0f, 100.0f);
            OnSpecializedMeterChanged?.Invoke(SpecializedResourceMeter);

            // Trigger specific elemental passive effects
            if (PassiveCooldownRemaining <= 0.0f && SpecializedResourceMeter >= 50.0f)
            {
                ExecutePassiveSurge(attacker, defender);
            }
        }

        private void ExecutePassiveSurge(FighterBase attacker, FighterBase defender)
        {
            IsPassiveTriggered = true;
            PassiveCooldownRemaining = 8.0f;
            SpecializedResourceMeter -= 30.0f;

            attacker.Ether.AddEther(15.0f);
            OnPassiveSkillProc?.Invoke("Auren Zeth Passive Surge Proc!");
        }

        public void Update(float deltaTime)
        {
            if (PassiveCooldownRemaining > 0.0f)
            {
                PassiveCooldownRemaining -= deltaTime;
                if (PassiveCooldownRemaining <= 0.0f)
                {
                    IsPassiveTriggered = false;
                    PassiveCooldownRemaining = 0.0f;
                }
            }
        }

        public void Reset()
        {
            SpecializedResourceMeter = 0.0f;
            ComboHitAccumulator = 0;
            IsPassiveTriggered = false;
            PassiveCooldownRemaining = 0.0f;
        }
    }
}
