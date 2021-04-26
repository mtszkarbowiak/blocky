using System;

namespace AuroraSeeker.Blocky.Shared.Serialization
{
    public abstract class DynamicSize2ByteSerializable : IByteSerializable
    {
        public void Serialize(IByteWriter writer)
        {
            var size = OnSerializingSize();

#if DEBUG
            if (size > ushort.MaxValue) throw new ArgumentException("Size can not be higher than max ushort!");
#endif

            {
                var a = (byte) (size >> 8);
                var b = (byte)size ;
                
                writer.WriteNext(a);
                writer.WriteNext(b);
            }

            for (var i = 0; i < size; i++)
            {
                var b = OnSerializingByte(i);
                
                writer.WriteNext(b);
            }
        }

        public void Deserialize(IByteReader reader)
        {
            ushort size;
            
            {
                int a = reader.ReadNext();
                int b = reader.ReadNext();

                size = (ushort) ((a << 8) | b);
            }

            OnDeserializedSize(size);

            for (var i = 0; i < size; i++)
            {
                var b = reader.ReadNext();
                 OnDeserializedNextByte(b, i);
            }
        }

        protected abstract void OnDeserializedSize(int size);
        protected abstract void OnDeserializedNextByte(byte b, int index);

        protected abstract int OnSerializingSize();
        protected abstract byte OnSerializingByte(int index);
    }
}