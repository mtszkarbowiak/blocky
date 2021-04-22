namespace AuroraSeeker.Blocky.Shared.HumanCommands
{
    public interface IHumanCommandRegistry
    {
        void RegisterCommand(IHumanCommand humanCommand);
    }
}