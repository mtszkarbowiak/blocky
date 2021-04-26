namespace AuroraSeeker.Blocky.Shared.Serialization
{
    public interface IByteSerializable
    {
        void Serialize(IByteWriter writer);

        void Deserialize(IByteReader reader);
    }
}