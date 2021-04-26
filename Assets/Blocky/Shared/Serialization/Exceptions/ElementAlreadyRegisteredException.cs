using System;
using System.Runtime.Serialization;

namespace AuroraSeeker.Blocky.Shared.Serialization.Exceptions
{
    [Serializable]
    public class ElementAlreadyRegisteredException : Exception
    {
        public ElementAlreadyRegisteredException()
        {
        }

        public ElementAlreadyRegisteredException(string message) : base(message)
        {
        }

        public ElementAlreadyRegisteredException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ElementAlreadyRegisteredException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}