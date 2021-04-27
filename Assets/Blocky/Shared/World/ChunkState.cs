#nullable enable
using System.Collections.Generic;
using AuroraSeeker.Blocky.Shared.Serialization;
using AuroraSeeker.Blocky.Shared.Serialization.Unsafe;
using static AuroraSeeker.Blocky.Shared.ChunkAddressing;

namespace AuroraSeeker.Blocky.Shared.World
{
    public class ChunkState
    {
        private readonly ushort[] _blockIds;
        private readonly Dictionary<ushort, IBlockData> _blockData;
        
        private const int DefaultChunkDataCapacity = ChunkSize2D;

        
        public ChunkState()
        {
            _blockIds = new ushort[ChunkSize3D];
            _blockData = new Dictionary<ushort, IBlockData>(DefaultChunkDataCapacity);
        }

        
        public void Serialize(IByteWriter buffer)
        {
            for (var i = 0; i < ChunkSize3D; i++)
                buffer.WriteUInt16(_blockIds[i]);

            buffer.WriteUInt16((ushort) _blockData.Count);

            foreach (var pair in _blockData)
            {
                var index = pair.Key;
                var data = pair.Value;
                
                buffer.WriteUInt16(index);
                data.Serialize(buffer);
            }
        }

        public void Deserialize(IByteReader buffer, IBlockDataPoolingRegistry blockDataPoolingRegistry)
        {
            ClearChunk(blockDataPoolingRegistry);
            
            for (var i = 0; i < ChunkSize3D; i++)
                _blockIds[i] = buffer.ReadUInt16();

            int count = buffer.ReadUInt16();

            for (var i = 0; i < count; i++)
            {
                var addressIndex = buffer.ReadUInt16();
                var registryIndex = _blockIds[addressIndex];
                
                var data = blockDataPoolingRegistry.GetById(registryIndex);
                data.Deserialize(buffer);
                
                _blockData.Add(addressIndex,data);
            }
        }

        public void ClearChunk(IBlockDataPoolingRegistry blockDataPoolingRegistry, bool overrideIds = false)
        {
            if (overrideIds)
            {
                for (int i = 0; i < ChunkSize3D; i++)
                    _blockIds[i] = 0;
            }
            
            foreach (var pair in _blockData)
            {
                var addressIndex = pair.Key;
                var data = pair.Value;
                var registryIndex = _blockIds[addressIndex];
                
                blockDataPoolingRegistry.Return(registryIndex, data);
            }
        }


        public ushort GetBlockID(ushort location)
        {
            return _blockIds[location];
        }
        
        public IBlockData? GetBlockData(ushort location)
        {
            return _blockData.TryGetValue(location, out var result) ? result : null;
        }

        public IBlockData? SetBlock(ushort location, ushort blockId, IBlockDataPoolingRegistry dataPoolingRegistry)
        {
            var previousID = _blockIds[location];
            var isKeyPresent = _blockData.TryGetValue(location, out var value);
            
            if(isKeyPresent) dataPoolingRegistry.Return(previousID, value);

            _blockIds[location] = blockId;
            
            var newData = dataPoolingRegistry.GetById(blockId);

            if (newData == null) 
                return null;
            
            if (isKeyPresent)
                _blockData[location] = newData;
            else
                _blockData.Add(location, newData);

            return newData;
        }
    }
}