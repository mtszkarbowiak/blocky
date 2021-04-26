namespace AuroraSeeker.Blocky.Shared.World
{
    public interface IBlockDataPoolingRegistry
    {
        IBlockData GetById(ushort id);
        
        void Return(ushort id, IBlockData blockData);
    }
}