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
                buffer.WriteUShort(_blockIds[i]);
            
        }

        public void Deserialize(IByteReader buffer)
        {
            for (var i = 0; i < ChunkSize3D; i++)
                _blockIds[i] = buffer.ReadUshort();
        }

        
        public void SetBlockID(ushort location, ushort block)
        {
            _blockIds[location] = block;
        }

        public ushort GetBlockID(ushort location)
        {
            return _blockIds[location];
        }
        
        public void SetBlockData(ushort location, IBlockData data)
        {
            if (_blockData.ContainsKey(location))
            {
                if (data == null)
                    _blockData.Remove(location);
                else
                    _blockData[location] = data;
                
                return;
            }
            
            if(data != null)
                _blockData.Add(location, data);
        }

        public IBlockData GetBlockData(ushort location)
        {
            return _blockData[location];
        }
    }
}