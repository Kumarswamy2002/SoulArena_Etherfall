using System;
using SoulArena.Core;

namespace SoulArena.Characters
{
    [Serializable]
    public class FighterStats
    {
        public float MaxHealth = 1000.0f;
        public float AttackPower = 100.0f;
        public float DefenseArmor = 20.0f;
        public float MoveSpeed = 6.0f;
        public float DashSpeed = 14.0f;
        public float JumpForce = 12.0f;
        public float Weight = 1.0f; // Affects launch height and juggle fall speed
        public float CriticalChance = 0.05f; // 5% base crit

        public FighterStats Clone()
        {
            return new FighterStats
            {
                MaxHealth = this.MaxHealth,
                AttackPower = this.AttackPower,
                DefenseArmor = this.DefenseArmor,
                MoveSpeed = this.MoveSpeed,
                DashSpeed = this.DashSpeed,
                JumpForce = this.JumpForce,
                Weight = this.Weight,
                CriticalChance = this.CriticalChance
            };
        }
    }

    [Serializable]
    public class FighterDefinition
    {
        public string FighterId;
        public string Name;
        public string Title;
        public EtherElement Element;
        public FighterRole Role;
        public string WeaponType;
        public string Backstory;
        public FighterStats BaseStats = new FighterStats();
        public string PassiveAbilityName;
        public string PassiveDescription;
        public string UltimateName;
        public string UltimateDescription;
    }
}
