namespace AuroraSeeker.Blocky.Shared.Collections.Pooling
{
    public interface ISource<out T>
    {
        T Get();
    }
}