using System.Collections.Generic;

namespace AuroraSeeker.Blocky.Shared.HumanCommands
{
    public interface IHumanCommand
    {
        IEnumerable<string> CommandAliases { get; }

        void Interpret(string[] args);
        
        string Manual { get; }
    }
}