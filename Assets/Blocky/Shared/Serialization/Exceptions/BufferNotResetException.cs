using System;
using System.Runtime.Serialization;

namespace AuroraSeeker.Blocky.Shared.Serialization.Exceptions
{
    [Serializable]
    public class BufferNotResetException : Exception
    {
        public BufferNotResetException()
        {
        }

        public BufferNotResetException(string message) : base(message)
        {
        }

        public BufferNotResetException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BufferNotResetException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}