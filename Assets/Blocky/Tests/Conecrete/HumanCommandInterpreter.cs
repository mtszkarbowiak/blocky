using AuroraSeeker.Blocky.Shared.HumanCommands.DefaultCommands;
using NUnit.Framework;
using TestedType = AuroraSeeker.Blocky.Shared.HumanCommands.HumanCommandInterpreter;

namespace AuroraSeeker.Blocky.Tests.Conecrete
{
    public class HumanCommandInterpreter
    {
        [Test]
        public void RegisterAndInvoke()
        {
            var humanCommandInterpreter = new TestedType(1);
            
            humanCommandInterpreter.RegisterCommand(new CustomActionCommand(
                new []{"test"}, 
                args =>
                {
                    Assert.Pass();
                },
                "")
            );
            
            humanCommandInterpreter.ExecuteCommand("test");
            
            Assert.Fail();
        }
    }
}