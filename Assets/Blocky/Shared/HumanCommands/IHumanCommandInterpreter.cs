namespace AuroraSeeker.Blocky.Shared.HumanCommands
{
    public interface IHumanCommandInterpreter : IHumanCommandRegistry
    {
        void ExecuteCommand(string value);
    }
}