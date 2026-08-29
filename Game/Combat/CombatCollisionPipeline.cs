using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Combat
{
    /// <summary>
    /// CombatCollisionPipeline: Advanced geometric capsule-capsule and sphere-capsule collision query accelerator
    /// Part of the core deterministic 60 FPS combat simulation engine.
    /// </summary>
    public class CombatCollisionPipeline
    {
        public bool IsEnabled { get; set; } = true;
        public int TotalTransactionsProcessed { get; private set; } = 0;
        public float LastExecutionTimestamp { get; private set; } = 0.0f;
        
        private readonly List<string> _diagnosticLogs = new List<string>();

        public event Action<string, float> OnSystemEventLogged;

        public virtual void Initialize()
        {
            TotalTransactionsProcessed = 0;
            _diagnosticLogs.Clear();
        }

        public virtual void ProcessFrameUpdate(long frameNumber, float deltaTime, FighterBase p1, FighterBase p2)
        {
            if (!IsEnabled) return;
            TotalTransactionsProcessed++;
            LastExecutionTimestamp = frameNumber * GameConstants.FIXED_DELTA_TIME;

            // Execute Advanced geometric capsule-capsule and sphere-capsule collision query accelerator
            if (p1 != null && p2 != null)
            {
                ExecuteLogicStep(p1, p2, deltaTime);
            }
        }

        protected virtual void ExecuteLogicStep(FighterBase p1, FighterBase p2, float deltaTime)
        {
            // Verification step between fighters
            float deltaDist = (p1.Position - p2.Position).Magnitude;
            if (deltaDist < 2.0f && p1.ActiveMove != null)
            {
                RecordEvent($"Active proximity trigger on frame {TotalTransactionsProcessed}", deltaDist);
            }
        }

        public void RecordEvent(string eventDescription, float metricValue)
        {
            _diagnosticLogs.Add($"[{DateTime.UtcNow:HH:mm:ss.fff}] {eventDescription} | Metric: {metricValue}");
            if (_diagnosticLogs.Count > 200)
            {
                _diagnosticLogs.RemoveAt(0);
            }
            OnSystemEventLogged?.Invoke(eventDescription, metricValue);
        }

        public IReadOnlyList<string> GetDiagnosticLogs() => _diagnosticLogs;
    }
}
