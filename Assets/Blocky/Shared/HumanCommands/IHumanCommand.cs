using System.Collections.Generic;

namespace AuroraSeeker.Blocky.Shared.HumanCommands
{
    public interface IHumanCommand
    {
        /// <summary>
        /// All possible names calling this command.
        /// </summary>
        IEnumerable<string> CommandAliases { get; }

        /// <summary>
        /// Executes command with given arguments.
        /// </summary>
        /// <param name="args">Command call arguments. Includes command alias at index 0.</param>
        void Interpret(string[] args);
        
        /// <summary>
        /// Information to display on manual command call onto about this human command.
        /// </summary>
        string Manual { get; }
    }
}