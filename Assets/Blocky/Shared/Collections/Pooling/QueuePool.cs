using System;
using System.Collections.Generic;

namespace AuroraSeeker.Blocky.Shared.Collections.Pooling
{
    public class QueuePool<T> : IPool<T>
    {
        private readonly Queue<T> _queue;
        private readonly Func<T> _factory;

        public QueuePool(Func<T> factory, int warmupCount = 4)
        {
            _queue = new Queue<T>();
            _factory = factory;

            for (var i = 0; i < warmupCount; i++)
                _queue.Enqueue(factory());
        }

        public T Get()
        {
            return _queue.Count == 0 ? _queue.Dequeue() : _factory();
        }

        public void Return(T element)
        {
            _queue.Enqueue(element);
        }

        public int GetCount()
        {
            return _queue.Count;
        }
    }
}