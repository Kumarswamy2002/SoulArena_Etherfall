using System;
using SoulArena.Core;

namespace SoulArena.VFX.GuardBreak
{
    /// <summary>
    /// Guard Break Glass Shatter & Poise Rupture VFX for Raven Drake (Blood Knight).
    /// </summary>
    public class RavenDrakeGuardBreakVFX
    {
        public string FighterId { get; } = "raven_drake";
        public int GlassShardCount { get; set; } = 32;
        public float RuptureShockwaveRadius { get; set; } = 4.5f;

        public event Action<Vector3D, int> OnGuardBreakShardsSpawned;

        public void PlayShatterVFX(Vector3D center)
        {
            OnGuardBreakShardsSpawned?.Invoke(center, GlassShardCount);
        }
    }
}
