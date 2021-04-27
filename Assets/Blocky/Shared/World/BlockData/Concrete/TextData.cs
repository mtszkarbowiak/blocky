using AuroraSeeker.Blocky.Shared.Serialization;
using AuroraSeeker.Blocky.Shared.Serialization.Unsafe;

namespace AuroraSeeker.Blocky.Shared.World.BlockData.Concrete
{
    public class TextData : IBlockData
    {
        private string _text;

        public void Serialize(IByteWriter writer)
        {
            writer.WriteString(_text);
        }

        public void Deserialize(IByteReader reader)
        {
            _text = reader.ReadString();
        }
    }
}