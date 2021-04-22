using System.Collections.Generic;
using AuroraSeeker.Blocky.Shared.Logging;
using static AuroraSeeker.Blocky.Shared.HumanCommands.HumanCommandUtils;

namespace AuroraSeeker.Blocky.Shared.HumanCommands.DefaultCommands
{
    public class ListAllCommand : IHumanCommand
    {
        public ListAllCommand(HumanCommandInterpreter humanCommandInterpreter, ILogger logger)
        {
            _humanCommandInterpreter = humanCommandInterpreter;
            _logger = logger;
        }

        private HumanCommandInterpreter _humanCommandInterpreter;
        private ILogger _logger;
        
        public IEnumerable<string> CommandAliases => new[] {"all"};

        public string Manual => "List all commands.";
        
        public void Interpret(string[] args)
        {
            var humanCommands = _humanCommandInterpreter.GetAllHumanCommands();

            foreach (var humanCommand in humanCommands)
            {
                _logger.Log($"{ConcatenateAliases(humanCommand.CommandAliases)}");
            }
        }
    }
}