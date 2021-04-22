namespace AuroraSeeker.Blocky.Shared.Logging
{
    public interface ILogger
    {
        void Log(string text, LogType logType = LogType.Info);
    }
}