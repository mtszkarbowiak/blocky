#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuroraSeeker.Blocky.Shared.World
{
    public class BlockDataPoolRegistry : IBlockDataPoolingRegistry
    {
        private readonly Dictionary<ushort, Queue<IBlockData>> _pools;
        private readonly Dictionary<ushort, Func<IBlockData>> _factoryCallbacks;

        public BlockDataPoolRegistry(int capacity = 2048)
        {
            _pools = new Dictionary<ushort, Queue<IBlockData>>(capacity);
            _factoryCallbacks = new Dictionary<ushort, Func<IBlockData>>(capacity);
        }

        public void Register(ushort id, Func<IBlockData> facoryCallback)
        {
            if (_pools.ContainsKey(id) || _factoryCallbacks.ContainsKey(id)) 
                throw new ArgumentException($"This ID ({id}) is already registered.");

            var queue = new Queue<IBlockData>();
            
            _factoryCallbacks.Add(id, facoryCallback);
            _pools.Add(id, queue);
        }

        public IBlockData? GetById(ushort id)
        {
            if (_pools.TryGetValue(id, out var pool))
            {
                return pool.Any() ? pool.Dequeue() : _factoryCallbacks[id]();
            }

            return null;
        }

        public void Return(ushort id, IBlockData blockData)
        {
            _pools[id].Enqueue(blockData);
        }
    }
}