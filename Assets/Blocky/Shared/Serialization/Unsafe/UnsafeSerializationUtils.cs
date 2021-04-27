using System;

namespace AuroraSeeker.Blocky.Shared.Serialization.Unsafe
{
    public static class UnsafeSerializationUtils
    {
        public static unsafe void WriteFloat(this IByteWriter writer, float f)
        {
            var pointer = &f;
            var ltBytePnt = (byte*) pointer;

            writer.WriteNext(ltBytePnt[0]);
            writer.WriteNext(ltBytePnt[1]);
            writer.WriteNext(ltBytePnt[2]);
            writer.WriteNext(ltBytePnt[3]);
        }
        
        public static unsafe float ReadFloat(this IByteReader reader)
        {
            float result;
            
            var pointer = &result;
            var ltBytePnt = (byte*) pointer;

            ltBytePnt[0] = reader.ReadNext();
            ltBytePnt[1] = reader.ReadNext();
            ltBytePnt[2] = reader.ReadNext();
            ltBytePnt[3] = reader.ReadNext();

            return result;
        }
        
        
        public static unsafe void WriteUInt16(this IByteWriter writer, ushort s)
        {
            var pointer = &s;
            var ltBytePnt = (byte*) pointer;

            writer.WriteNext(ltBytePnt[0]);
            writer.WriteNext(ltBytePnt[1]);
        }
        
        public static unsafe void WriteUInt32(this IByteWriter writer, uint i)
        {
            var pointer = &i;
            var ltBytePnt = (byte*) pointer;

            writer.WriteNext(ltBytePnt[0]);
            writer.WriteNext(ltBytePnt[1]);
            writer.WriteNext(ltBytePnt[2]);
            writer.WriteNext(ltBytePnt[3]);
        }
        
        public static unsafe ushort ReadUInt16(this IByteReader reader)
        {
            ushort result;
            
            var pointer = &result;
            var ltBytePnt = (byte*) pointer;

            ltBytePnt[0] = reader.ReadNext();
            ltBytePnt[1] = reader.ReadNext();

            return result;
        }
        
        public static unsafe uint ReadUInt32(this IByteReader reader)
        {
            uint result;
            
            var pointer = &result;
            var ltBytePnt = (byte*) pointer;

            ltBytePnt[0] = reader.ReadNext();
            ltBytePnt[1] = reader.ReadNext();
            ltBytePnt[2] = reader.ReadNext();
            ltBytePnt[3] = reader.ReadNext();

            return result;
        }


        public static void WriteString(this IByteWriter writer, string str)
        {
            var size = (ushort) str.Length;
            
            writer.WriteUInt16(size);

            for (var i = 0; i < size; i++)
                writer.WriteUInt16(str[i]);
        }

        public static unsafe string ReadString(this IByteReader reader)
        {
            var size = reader.ReadUInt16();

            var buffer = stackalloc char[size];

            for (var i = 0; i < size; i++)
                buffer[i] = (char) reader.ReadUInt16();

            return new string(buffer);
        }
    }
}