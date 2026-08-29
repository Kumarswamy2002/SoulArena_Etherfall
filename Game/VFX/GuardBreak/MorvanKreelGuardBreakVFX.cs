using System;
using SoulArena.Core;

namespace SoulArena.VFX.GuardBreak
{
    /// <summary>
    /// Guard Break Glass Shatter & Poise Rupture VFX for Morvan Kreel (Grave King).
    /// </summary>
    public class MorvanKreelGuardBreakVFX
    {
        public string FighterId { get; } = "morvan_kreel";
        public int GlassShardCount { get; set; } = 32;
        public float RuptureShockwaveRadius { get; set; } = 4.5f;

        public event Action<Vector3D, int> OnGuardBreakShardsSpawned;

        public void PlayShatterVFX(Vector3D center)
        {
            OnGuardBreakShardsSpawned?.Invoke(center, GlassShardCount);
        }
    }
}
