namespace AuroraSeeker.Blocky.Shared.Collections.Pooling
{
    public interface IGrave<in T>
    {
        void Return(T element);
    }
}