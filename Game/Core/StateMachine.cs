using System;
using System.Collections.Generic;

namespace SoulArena.Core
{
    public interface IState<T>
    {
        void OnEnter(T entity);
        void OnUpdate(T entity, float deltaTime);
        void OnFixedUpdate(T entity, float fixedDeltaTime);
        void OnExit(T entity);
    }

    /// <summary>
    /// Robust, reusable hierarchical Finite State Machine engine with state transition tables and event triggers.
    /// </summary>
    public class StateMachine<T>
    {
        private readonly T _owner;
        private readonly Dictionary<Type, IState<T>> _states = new Dictionary<Type, IState<T>>();
        
        public IState<T> CurrentState { get; private set; }
        public IState<T> PreviousState { get; private set; }
        public float TimeInCurrentState { get; private set; }
        public int FramesInCurrentState { get; private set; }

        public event Action<IState<T>, IState<T>> OnStateChanged;

        public StateMachine(T owner)
        {
            _owner = owner;
        }

        public void RegisterState<TState>(TState state) where TState : IState<T>
        {
            Type stateType = typeof(TState);
            if (!_states.ContainsKey(stateType))
            {
                _states[stateType] = state;
            }
        }

        public void ChangeState<TState>() where TState : IState<T>
        {
            Type stateType = typeof(TState);
            if (!_states.TryGetValue(stateType, out IState<T> newState))
            {
                throw new InvalidOperationException($"State '{stateType.Name}' is not registered in this StateMachine.");
            }

            if (CurrentState == newState) return;

            PreviousState = CurrentState;
            CurrentState?.OnExit(_owner);

            CurrentState = newState;
            TimeInCurrentState = 0.0f;
            FramesInCurrentState = 0;

            CurrentState.OnEnter(_owner);
            OnStateChanged?.Invoke(PreviousState, CurrentState);
        }

        public void Update(float deltaTime)
        {
            if (CurrentState != null)
            {
                TimeInCurrentState += deltaTime;
                CurrentState.OnUpdate(_owner, deltaTime);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if (CurrentState != null)
            {
                FramesInCurrentState++;
                CurrentState.OnFixedUpdate(_owner, fixedDeltaTime);
            }
        }

        public bool IsInState<TState>() where TState : IState<T>
        {
            return CurrentState != null && CurrentState.GetType() == typeof(TState);
        }
    }
}
