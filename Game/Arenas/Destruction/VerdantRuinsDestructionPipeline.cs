using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Arenas.Destruction
{
    /// <summary>
    /// Debris & Destruction Particle Shard Pipeline for VerdantRuins.
    /// Handles fragmentation physics for AncientTrees (Capacity: 6).
    /// </summary>
    public class VerdantRuinsDestructionPipeline
    {
        public int TotalDestructionEvents { get; private set; } = 0;
        public int ActiveDebrisCount { get; private set; } = 0;

        public event Action<string, Vector3D> OnShardExplosion;

        public void TriggerDestruction(string objectId, Vector3D position)
        {
            TotalDestructionEvents++;
            ActiveDebrisCount += 6;
            OnShardExplosion?.Invoke(objectId, position);
        }

        public void UpdateDebris(float deltaTime)
        {
            if (ActiveDebrisCount > 0)
            {
                ActiveDebrisCount = Math.Max(0, ActiveDebrisCount - 1);
            }
        }
    }
}
