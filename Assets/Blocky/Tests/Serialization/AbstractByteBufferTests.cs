using AuroraSeeker.Blocky.Shared.Serialization;
using AuroraSeeker.Blocky.Shared.Serialization.Exceptions;
using NUnit.Framework;

namespace AuroraSeeker.Blocky.Tests.Serialization
{
    public static class AbstractByteBufferTests
    {
        public static void WriteAndRead_Positive(IByteBuffer buffer)
        {
            const byte
                a = 0x51, b = 0xF1, c = 0x5A, d = 0x0E;
            
            buffer.RestartForWriting();
            buffer.WriteNext(a);
            buffer.WriteNext(b);
            buffer.WriteNext(c);
            buffer.WriteNext(d);
            
            buffer.RestartForReading();
            Assert.AreEqual(a, buffer.ReadNext());
            Assert.AreEqual(b, buffer.ReadNext());
            Assert.AreEqual(c, buffer.ReadNext());
            Assert.AreEqual(d, buffer.ReadNext());
        }

        public static void WriteAndRead_BufferOutOfRange_DebugModeOnly(IByteBuffer buffer)
        {
            buffer.RestartForWriting();
            buffer.WriteNext(0);
            
            buffer.RestartForReading();
            buffer.ReadNext();
            
#if DEBUG
            Assert.Throws<BufferOutOfRangeException>(() =>
            {
                buffer.ReadNext();
            });
#else
            Assert.Inconclusive();
#endif
        }

        public static void WriteAndRead_BufferNotReset_DebugModeOnly(IByteBuffer buffer)
        {
            buffer.RestartForWriting();
            buffer.WriteNext(0);
            
#if DEBUG
            Assert.Throws<BufferNotResetException>(() =>
            {
                buffer.ReadNext();
            });
#else
            Assert.Inconclusive();
#endif
        }
    }
}