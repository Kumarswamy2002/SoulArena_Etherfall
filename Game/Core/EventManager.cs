using System;
using System.Collections.Generic;

namespace SoulArena.Core
{
    public interface IGameEvent { }

    /// <summary>
    /// Centralized high-performance strongly-typed Event Bus for all gameplay, combat, and match events.
    /// Eliminates tight coupling between systems.
    /// </summary>
    public static class EventManager
    {
        private static readonly Dictionary<Type, List<Delegate>> _eventListeners = new Dictionary<Type, List<Delegate>>();

        public static void Subscribe<T>(Action<T> listener) where T : IGameEvent
        {
            Type eventType = typeof(T);
            if (!_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType] = new List<Delegate>();
            }
            if (!_eventListeners[eventType].Contains(listener))
            {
                _eventListeners[eventType].Add(listener);
            }
        }

        public static void Unsubscribe<T>(Action<T> listener) where T : IGameEvent
        {
            Type eventType = typeof(T);
            if (_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType].Remove(listener);
                if (_eventListeners[eventType].Count == 0)
                {
                    _eventListeners.Remove(eventType);
                }
            }
        }

        public static void Publish<T>(T gameEvent) where T : IGameEvent
        {
            Type eventType = typeof(T);
            if (_eventListeners.TryGetValue(eventType, out List<Delegate> listeners))
            {
                // Iterate on a snapshot in case an event handler unbinds during invoke
                var snapshot = listeners.ToArray();
                for (int i = 0; i < snapshot.Length; i++)
                {
                    if (snapshot[i] is Action<T> action)
                    {
                        action.Invoke(gameEvent);
                    }
                }
            }
        }

        public static void ClearAll()
        {
            _eventListeners.Clear();
        }
    }

    // Concrete Core Gameplay Events
    public struct CharacterDamageEvent : IGameEvent
    {
        public int AttackerId;
        public int TargetId;
        public float RawDamage;
        public float FinalDamage;
        public bool IsCritical;
        public bool IsCounter;
        public DefenseType DefenseResult;
        public AttackType AttackType;
        public StatusEffectType AppliedStatus;
    }

    public struct GuardBreakEvent : IGameEvent
    {
        public int FighterId;
        public float StunDuration;
    }

    public struct PerfectGuardEvent : IGameEvent
    {
        public int DefenderId;
        public int AttackerId;
        public float CounterFrameAdvantage;
    }

    public struct PerfectDodgeEvent : IGameEvent
    {
        public int DodgerId;
        public int AttackerId;
        public float SlowdownDuration;
    }

    public struct ParrySuccessEvent : IGameEvent
    {
        public int DefenderId;
        public int AttackerId;
        public float StaggerDuration;
    }

    public struct ComboCountUpdatedEvent : IGameEvent
    {
        public int AttackerId;
        public int HitCount;
        public float TotalDamage;
        public float CurrentDamageScaling;
    }

    public struct ComboBreakerEvent : IGameEvent
    {
        public int BreakerId;
        public int AttackerId;
    }

    public struct AwakeningActivatedEvent : IGameEvent
    {
        public int FighterId;
        public float Duration;
        public EtherElement Element;
    }

    public struct AwakeningEndedEvent : IGameEvent
    {
        public int FighterId;
    }

    public struct UltimateExecutedEvent : IGameEvent
    {
        public int FighterId;
        public string UltimateName;
    }

    public struct RoundStateChangedEvent : IGameEvent
    {
        public int RoundNumber;
        public string StateName;
        public float TimeRemaining;
    }

    public struct MatchEndedEvent : IGameEvent
    {
        public int WinnerId;
        public MatchResult Result;
        public int RoundsWonP1;
        public int RoundsWonP2;
        public float TotalDuration;
    }

    public struct ArenaHazardTriggeredEvent : IGameEvent
    {
        public ArenaId Arena;
        public string HazardName;
        public float Damage;
        public float Duration;
    }
}
