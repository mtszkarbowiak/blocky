using System;
using System.Collections.Generic;

namespace AuroraSeeker.Blocky.Shared.HumanCommands.DefaultCommands
{
    public class CustomActionCommand : IHumanCommand
    {
        private readonly Action<string[]> _interpretCallback;
        
        public IEnumerable<string> CommandAliases { get; private set; }
        public string Manual { get; private set; }
        public void Interpret(string[] args) => _interpretCallback.Invoke(args);

        public CustomActionCommand(
            IEnumerable<string> commandAliases, 
            Action<string[]> interpretCallback, 
            string manual)
        {
            CommandAliases = commandAliases;
            Manual = manual;
            
            _interpretCallback = interpretCallback ?? throw new NullReferenceException(
                "InterpretCallback can not be null!");
        }
    }
}