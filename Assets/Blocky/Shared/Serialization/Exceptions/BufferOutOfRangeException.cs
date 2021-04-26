using System;
using System.Runtime.Serialization;

namespace AuroraSeeker.Blocky.Shared.Serialization.Exceptions
{
    [Serializable]
    public class BufferOutOfRangeException : Exception
    {
        public BufferOutOfRangeException(){}

        public BufferOutOfRangeException(string message) : base(message){}

        public BufferOutOfRangeException(string message, Exception inner) : base(message, inner){}

        protected BufferOutOfRangeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}