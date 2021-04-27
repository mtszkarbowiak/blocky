using AuroraSeeker.Blocky.Shared.Serialization;
using AuroraSeeker.Blocky.Shared.Serialization.Unsafe;

namespace AuroraSeeker.Blocky.Shared.World.BlockData.Concrete
{
    public class LifeTimeData : IBlockData
    {
        private float _lifeTime;

        public void Serialize(IByteWriter writer)
        {
            writer.WriteFloat(_lifeTime);
        }

        public void Deserialize(IByteReader reader)
        {
            _lifeTime = reader.ReadFloat();
        }
    }
}