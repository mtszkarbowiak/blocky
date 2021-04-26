using AuroraSeeker.Blocky.Shared.Serialization.Buffers;
using NUnit.Framework;

namespace AuroraSeeker.Blocky.Tests.Serialization
{
    public class ResizableByteBufferTests
    {
        [Test]
        public void WriteAndRead_Positive()
        {
            var buffer = new ResizableByteBuffer();
            
            AbstractByteBufferTests.WriteAndRead_Positive(buffer);
        }
        
        [Test]
        public void WriteAndRead_BufferNotReset_DebugModeOnly()
        {
            var buffer = new ResizableByteBuffer();
            
            AbstractByteBufferTests.WriteAndRead_BufferNotReset_DebugModeOnly(buffer);
        }
        
        [Test]
        public void WriteAndRead_BufferOutOfRange_DebugModeOnly()
        {
            var buffer = new ResizableByteBuffer();
            
            AbstractByteBufferTests.WriteAndRead_BufferOutOfRange_DebugModeOnly(buffer);
        }
    }
}