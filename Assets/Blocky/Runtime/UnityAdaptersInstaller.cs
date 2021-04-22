using System;
using AuroraSeeker.Blocky.Shared.HumanCommands;
using AuroraSeeker.Blocky.Shared.HumanCommands.DefaultCommands;
using UnityEngine;
using Zenject;
using ILogger = AuroraSeeker.Blocky.Shared.Logging.ILogger;
using LogType = AuroraSeeker.Blocky.Shared.Logging.LogType;

namespace AuroraSeeker.Blocky.Runtime
{
    public class UnityAdaptersInstaller : MonoInstaller
    {
        private UnityLogger _unityLogger;
        private HumanCommandInterpreter _humanCommandInterpreter;

#if UNITY_EDITOR
        public string commandBuffer;

        [ContextMenu("Execute Command")]
        private void ExecuteCommandFromBuffer()
        {
            _humanCommandInterpreter.ExecuteCommand(commandBuffer);
        }
#endif
        
        public override void InstallBindings()
        {
            _unityLogger = new UnityLogger();
            _humanCommandInterpreter = new HumanCommandInterpreter();
            
            _humanCommandInterpreter.RegisterCommand(new ManualCommand(_humanCommandInterpreter, _unityLogger));
            _humanCommandInterpreter.RegisterCommand(new ListAllCommand(_humanCommandInterpreter, _unityLogger));
            
            Container
                .Bind<ILogger>()
                .FromInstance(_unityLogger);

            Container
                .Bind<IHumanCommandInterpreter>()
                .FromInstance(_humanCommandInterpreter);

            Container
                .Bind<IHumanCommandRegistry>()
                .FromInstance(_humanCommandInterpreter);
        }
        
        class UnityLogger : ILogger
        {
            public void Log(string text, LogType logType = LogType.Info)
            {
                switch (logType)
                {
                    case LogType.Info:
                        Debug.Log(text);
                        break;
                    case LogType.Warning:
                        Debug.LogWarning(text);
                        break;
                    case LogType.Error:
                        Debug.LogError(text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
                }
            }
        }
    }
}