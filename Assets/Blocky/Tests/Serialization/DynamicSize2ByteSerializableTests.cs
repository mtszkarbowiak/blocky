using System.Collections.Generic;
using System.Linq;
using AuroraSeeker.Blocky.Shared.Serialization.Buffers;
using NUnit.Framework;
using TestedType = AuroraSeeker.Blocky.Shared.Serialization.DynamicSize2ByteSerializable;

namespace AuroraSeeker.Blocky.Tests.Serialization
{
    public class DynamicSize2ByteSerializableTests
    {
        [Test]
        public void WriteAndRead()
        {
            var buffer = new ResizableByteBuffer();
            var testInheritor = new TestedTypeInheritor();

            const byte a = 0x5A, b = 0x7F, c = 0x51, d = 0xE0, e = 0x1A;

            testInheritor.bytes = new List<byte>(){a,b,c,d,e};
            
            buffer.RestartForWriting();
            testInheritor.Serialize(buffer);
            
            
            testInheritor.bytes = new List<byte>(){};
            
            buffer.RestartForReading();
            testInheritor.Deserialize(buffer);
            
            Assert.AreEqual(a,testInheritor.bytes[0]);
            Assert.AreEqual(b,testInheritor.bytes[1]);
            Assert.AreEqual(c,testInheritor.bytes[2]);
            Assert.AreEqual(d,testInheritor.bytes[3]);
            Assert.AreEqual(e,testInheritor.bytes[4]);
        }
    }

    class TestedTypeInheritor : TestedType
    {
        public List<byte> bytes;
        
        protected override void OnDeserializedSize(int size)
        {
            bytes = new List<byte>(size);
        }

        protected override void OnDeserializedNextByte(byte b, int index)
        {
            bytes.Add(b);
        }

        protected override int OnSerializingSize()
        {
            return bytes.Count;
        }

        protected override byte OnSerializingByte(int index)
        {
            return bytes[index];
        }
    }
}