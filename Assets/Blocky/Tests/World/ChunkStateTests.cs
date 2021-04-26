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
            const ushort location = 58, value = 58;
            
            var chunkState1 = new ChunkState();
            var chunkState2 = new ChunkState();

            chunkState1.SetBlockID(location, value);
            
            var buffer = new ResizableByteBuffer();

            buffer.RestartForWriting();
            chunkState1.Serialize(buffer);
            
            buffer.RestartForReading();
            chunkState2.Deserialize(buffer);

            var result = chunkState2.GetBlockID(location);
            Assert.AreEqual(value, result);
        }
    }
}