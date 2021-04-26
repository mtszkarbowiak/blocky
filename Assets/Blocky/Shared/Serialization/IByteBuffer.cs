namespace AuroraSeeker.Blocky.Shared.Serialization
{
    public interface IByteBuffer : IByteReader, IByteWriter
    {
        void RestartForWriting();
           
        void RestartForReading();
    }
}