using System.Collections.Generic;
using AuroraSeeker.Blocky.Shared.Logging;

namespace AuroraSeeker.Blocky.Shared.HumanCommands.DefaultCommands
{
    public class ManualCommand : IHumanCommand
    {
        public ManualCommand(HumanCommandInterpreter humanCommandInterpreter, ILogger logger)
        {
            _humanCommandInterpreter = humanCommandInterpreter;
            _logger = logger;
        }

        private readonly HumanCommandInterpreter _humanCommandInterpreter;
        private readonly ILogger _logger;
        
        public IEnumerable<string> CommandAliases => new[] {"man", "manual","help"};

        public string Manual => "Lists all commands.";

        public void Interpret(string[] args)
        {
            var humanCommands = _humanCommandInterpreter.GetAliasDictionary();

            if (humanCommands.TryGetValue(args[1], out var humanCommand))
            {
                _logger.Log("Manual for: " 
                            + HumanCommandUtils.ConcatenateAliases(humanCommand.CommandAliases) 
                            + '\n' + humanCommand.Manual + '\n');
            }
            else _logger.Log("Command alias not found.", LogType.Error);
        }
    }
}