using AuroraSeeker.Blocky.Shared.Serialization;
using AuroraSeeker.Blocky.Shared.Serialization.Buffers;
using AuroraSeeker.Blocky.Shared.World;
using NUnit.Framework;

namespace AuroraSeeker.Blocky.Tests.World
{
    public class ChunkStateTests
    {
        [Test]
        public void Serialization_WriteAndReadChunk()
        {
            const ushort location = 7, value = 58;
            const byte b = 0xFE;
            
            var blockDataPoolingRegistry = new BlockDataPoolRegistry();
            blockDataPoolingRegistry.Register(value, () => new MockBlockData());
            
            var chunkState1 = new ChunkState();
            var chunkState2 = new ChunkState();

            var blockData = chunkState1.SetBlock(location, value, blockDataPoolingRegistry) as MockBlockData;
            blockData.theByte = b;
            
            var buffer = new ResizableByteBuffer();

            buffer.RestartForWriting();
            chunkState1.Serialize(buffer);
            
            buffer.RestartForReading();
            chunkState2.Deserialize(buffer, blockDataPoolingRegistry);
            
            var resultId = chunkState2.GetBlockID(location);
            var resultData = (MockBlockData) chunkState2.GetBlockData(location);
            var resultDataByte = resultData.theByte;
            
            Assert.AreEqual(value, resultId);
            Assert.AreEqual(b, resultDataByte);
        }

        class MockBlockData : IBlockData
        {
            public byte theByte;
            
            public void Serialize(IByteWriter writer)
            {
                writer.WriteNext(theByte);
            }

            public void Deserialize(IByteReader reader)
            {
                theByte = reader.ReadNext();
            }
        }
    }
}