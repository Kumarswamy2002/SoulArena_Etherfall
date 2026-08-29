using System;
using SoulArena.Core;

namespace SoulArena.VFX.GuardBreak
{
    /// <summary>
    /// Guard Break Glass Shatter & Poise Rupture VFX for Orin Veil (Mind Weaver).
    /// </summary>
    public class OrinVeilGuardBreakVFX
    {
        public string FighterId { get; } = "orin_veil";
        public int GlassShardCount { get; set; } = 32;
        public float RuptureShockwaveRadius { get; set; } = 4.5f;

        public event Action<Vector3D, int> OnGuardBreakShardsSpawned;

        public void PlayShatterVFX(Vector3D center)
        {
            OnGuardBreakShardsSpawned?.Invoke(center, GlassShardCount);
        }
    }
}
