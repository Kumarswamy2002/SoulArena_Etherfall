using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Arenas.Destruction
{
    /// <summary>
    /// Debris & Destruction Particle Shard Pipeline for AstralGarden.
    /// Handles fragmentation physics for PrismCrystals (Capacity: 12).
    /// </summary>
    public class AstralGardenDestructionPipeline
    {
        public int TotalDestructionEvents { get; private set; } = 0;
        public int ActiveDebrisCount { get; private set; } = 0;

        public event Action<string, Vector3D> OnShardExplosion;

        public void TriggerDestruction(string objectId, Vector3D position)
        {
            TotalDestructionEvents++;
            ActiveDebrisCount += 12;
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
