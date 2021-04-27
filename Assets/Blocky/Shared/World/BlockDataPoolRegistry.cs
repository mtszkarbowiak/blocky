#nullable enable

using System;
using System.Collections.Generic;
using AuroraSeeker.Blocky.Shared.Collections.Pooling;
using AuroraSeeker.Blocky.Shared.Serialization.Exceptions;

namespace AuroraSeeker.Blocky.Shared.World
{
    public class BlockDataPoolRegistry : IBlockDataPoolingRegistry
    {
        private readonly Dictionary<ushort, QueuePool<IBlockData>> _pools;

        public BlockDataPoolRegistry(int capacity = 2048)
        {
            _pools = new Dictionary<ushort, QueuePool<IBlockData>>(capacity);
        }

        public void Register(ushort id, Func<IBlockData> factoryCallback)
        {
            if (_pools.ContainsKey(id)) 
                throw new ElementAlreadyRegisteredException($"This ID ({id}) is already registered.");

            _pools.Add(id, new QueuePool<IBlockData>(factoryCallback));
        }

        public IBlockData? GetById(ushort id)
        {
            return _pools.TryGetValue(id, out var pool) ? pool.Get() : null;
        }

        public void Return(ushort id, IBlockData blockData)
        {
            _pools[id].Return(blockData);
        }
    }
}