namespace AuroraSeeker.Blocky.Shared
{
    public class CriticalConstants
    {
        public const int ChunkSizeBitShift = 5;

        public const int ChunkSize1D = 1 << ChunkSizeBitShift * 1;
        public const int ChunkSize2D = 1 << ChunkSizeBitShift * 2;
        public const int ChunkSize3D = 1 << ChunkSizeBitShift * 3;
    }
}