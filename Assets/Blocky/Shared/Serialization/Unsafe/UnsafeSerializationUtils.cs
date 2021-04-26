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
        
        public static unsafe void WriteUShort(this IByteWriter writer, ushort f)
        {
            var pointer = &f;
            var ltBytePnt = (byte*) pointer;

            writer.WriteNext(ltBytePnt[0]);
            writer.WriteNext(ltBytePnt[1]);
        }
        
        public static unsafe ushort ReadUshort(this IByteReader reader)
        {
            ushort result;
            
            var pointer = &result;
            var ltBytePnt = (byte*) pointer;

            ltBytePnt[0] = reader.ReadNext();
            ltBytePnt[1] = reader.ReadNext();

            return result;
        }
    }
}