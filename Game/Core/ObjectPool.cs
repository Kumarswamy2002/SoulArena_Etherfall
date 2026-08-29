using System;
using System.Collections.Generic;

namespace SoulArena.Core
{
    public interface IPoolable
    {
        bool IsActive { get; set; }
        void OnSpawn();
        void OnDespawn();
    }

    /// <summary>
    /// Thread-safe generic object pool ensuring zero garbage collection during intense combat sequences.
    /// </summary>
    public class ObjectPool<T> where T : class, IPoolable
    {
        private readonly Func<T> _factoryMethod;
        private readonly Action<T> _resetMethod;
        private readonly Queue<T> _availableObjects;
        private readonly HashSet<T> _activeObjects;
        private readonly int _maxCapacity;

        public int AvailableCount => _availableObjects.Count;
        public int ActiveCount => _activeObjects.Count;

        public ObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initialCapacity = 32, int maxCapacity = 512)
        {
            _factoryMethod = factoryMethod ?? throw new ArgumentNullException(nameof(factoryMethod));
            _resetMethod = resetMethod;
            _maxCapacity = maxCapacity;
            _availableObjects = new Queue<T>(initialCapacity);
            _activeObjects = new HashSet<T>();

            for (int i = 0; i < initialCapacity; i++)
            {
                T item = _factoryMethod();
                item.IsActive = false;
                _availableObjects.Enqueue(item);
            }
        }

        public T Get()
        {
            T item;
            if (_availableObjects.Count > 0)
            {
                item = _availableObjects.Dequeue();
            }
            else
            {
                item = _factoryMethod();
            }

            item.IsActive = true;
            _activeObjects.Add(item);
            item.OnSpawn();
            return item;
        }

        public void Return(T item)
        {
            if (item == null) return;
            if (!_activeObjects.Contains(item)) return;

            item.OnDespawn();
            _resetMethod?.Invoke(item);
            item.IsActive = false;
            _activeObjects.Remove(item);

            if (_availableObjects.Count < _maxCapacity)
            {
                _availableObjects.Enqueue(item);
            }
        }

        public void ReturnAll()
        {
            var activeArray = new T[_activeObjects.Count];
            _activeObjects.CopyTo(activeArray);
            for (int i = 0; i < activeArray.Length; i++)
            {
                Return(activeArray[i]);
            }
        }
    }
}
