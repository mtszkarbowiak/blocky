using AuroraSeeker.Blocky.Shared.Serialization.Buffers;
using AuroraSeeker.Blocky.Shared.Serialization.Unsafe;
using NUnit.Framework;
using UnityEngine;

namespace AuroraSeeker.Blocky.Tests.Serialization
{
    public class UnsafeSerializationUtilsTests
    {
        [Test]
        public void SerializeAndDeserialize_Float()
        {
            const float pi = Mathf.PI;
            
            var buffer = new ResizableByteBuffer();
            
            buffer.RestartForWriting();
            buffer.WriteFloat(pi);

            buffer.RestartForReading();
            var result = buffer.ReadFloat();
            
            Assert.AreEqual(pi, result);
        }
        
        [Test]
        public void SerializeAndDeserialize_UShort()
        {
            const ushort pi = 31415;
            
            var buffer = new ResizableByteBuffer();
            
            buffer.RestartForWriting();
            buffer.WriteFloat(pi);

            buffer.RestartForReading();
            var result = buffer.ReadFloat();
            
            Assert.AreEqual(pi, result);
        }
        
        [Test]
        public void SerializeAndDeserialize_String()
        {
            const string pi = "PI is a number!";
            
            var buffer = new ResizableByteBuffer();
            
            buffer.RestartForWriting();
            buffer.WriteString(pi);

            buffer.RestartForReading();
            var result = buffer.ReadString();
            
            Assert.AreEqual(pi, result);
        }
    }
}