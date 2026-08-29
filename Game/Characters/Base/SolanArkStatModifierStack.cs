using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Characters.Base
{
    /// <summary>
    /// Dynamic Attribute & Stat Modifier Stack for Solan Ark (Sunforged).
    /// </summary>
    public class SolanArkStatModifierStack
    {
        public float PowerMultiplier { get; set; } = 1.0f;
        public float ArmorMultiplier { get; set; } = 1.0f;
        public float SpeedMultiplier { get; set; } = 1.0f;

        public void ApplyBuff(float powerBoost, float armorBoost, float speedBoost)
        {
            PowerMultiplier += powerBoost;
            ArmorMultiplier += armorBoost;
            SpeedMultiplier += speedBoost;
        }

        public void ResetModifiers()
        {
            PowerMultiplier = 1.0f;
            ArmorMultiplier = 1.0f;
            SpeedMultiplier = 1.0f;
        }
    }
}
