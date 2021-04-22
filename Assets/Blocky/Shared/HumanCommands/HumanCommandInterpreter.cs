#nullable enable

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AuroraSeeker.Blocky.Shared.HumanCommands.DefaultCommands;
using AuroraSeeker.Blocky.Shared.Logging;

namespace AuroraSeeker.Blocky.Shared.HumanCommands
{
    public class HumanCommandInterpreter : IHumanCommandInterpreter
    {
        private const char Splitter = ' ';
        private readonly Dictionary<string, IHumanCommand> _aliasDictionary;
        private readonly Regex _commandRegex;

        public HumanCommandInterpreter(int capacity = 1024)
        {
            _aliasDictionary = new Dictionary<string, IHumanCommand>(capacity);
            _commandRegex = new Regex("[a-zA-z]");
        }
        
        public void RegisterCommand(IHumanCommand humanCommand)
        {
            foreach (var commandAlias in humanCommand.CommandAliases)
            {
                if (_aliasDictionary.ContainsKey(commandAlias))
                {
                    throw new InvalidOperationException(
                        $"{nameof(HumanCommandInterpreter)} already contains definition for {humanCommand}.");
                }
                
                if (!_commandRegex.IsMatch(commandAlias))
                {
                    throw new InvalidOperationException(
                        $"{nameof(HumanCommandInterpreter)} already contains definition for {humanCommand}.");
                }
                
                _aliasDictionary.Add(commandAlias, humanCommand);
            }
        }

        public void ExecuteCommand(string value)
        {
            var args = value.Split(Splitter);
            
            if(args.Length == 0) return;

            if (_aliasDictionary.TryGetValue(args[0], out var command))
            {
                command.Interpret(args);
            }
            else throw new KeyNotFoundException($"No command with alias {args[0]} found.");
        }

        public IEnumerable<IHumanCommand> GetAllHumanCommands()
        {
            return _aliasDictionary.Values;
        }

        public IReadOnlyDictionary<string,IHumanCommand> GetAliasDictionary()
        {
            return _aliasDictionary;
        }
    }
}