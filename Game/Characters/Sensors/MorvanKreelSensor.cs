using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Combat;

namespace SoulArena.Characters.Sensors
{
    /// <summary>
    /// Spatial & Telemetry Sensor Module for Morvan Kreel (Grave King).
    /// Evaluates distance, corner containment, frame advantage, and incoming threat vectors.
    /// </summary>
    public class MorvanKreelSensor
    {
        public int FighterId { get; }
        public float DistanceToEnemy { get; private set; } = 0.0f;
        public bool IsEnemyInCorner { get; private set; } = false;
        public bool IsSelfInCorner { get; private set; } = false;
        public int CurrentFrameAdvantage { get; private set; } = 0;
        public bool ThreatIncoming { get; private set; } = false;

        public MorvanKreelSensor(int fighterId)
        {
            FighterId = fighterId;
        }

        public void UpdateSensors(FighterBase self, FighterBase enemy, Vector3D arenaBounds)
        {
            if (self == null || enemy == null) return;

            DistanceToEnemy = (self.Position - enemy.Position).Magnitude;

            float cornerThreshold = arenaBounds.X * 0.40f;
            IsEnemyInCorner = Math.Abs(enemy.Position.X) >= cornerThreshold;
            IsSelfInCorner = Math.Abs(self.Position.X) >= cornerThreshold;

            // Frame advantage estimation
            if (self.ActiveMove != null && enemy.ActiveMove != null)
            {
                CurrentFrameAdvantage = enemy.CurrentMoveFrame - self.CurrentMoveFrame;
            }
            else if (self.ActiveMove != null)
            {
                CurrentFrameAdvantage = 10;
            }
            else if (enemy.ActiveMove != null)
            {
                CurrentFrameAdvantage = -10;
            }
            else
            {
                CurrentFrameAdvantage = 0;
            }

            ThreatIncoming = enemy.ActiveMove != null && DistanceToEnemy <= 3.5f;
        }
    }
}
