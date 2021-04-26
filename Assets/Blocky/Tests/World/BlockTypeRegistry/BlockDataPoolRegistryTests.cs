using AuroraSeeker.Blocky.Shared.Serialization.Exceptions;
using AuroraSeeker.Blocky.Shared.World;
using NUnit.Framework;

namespace AuroraSeeker.Blocky.Tests.World.BlockTypeRegistry
{
    public class BlockDataPoolRegistryTests
    {
        [Test]
        public void Registry_ElementAlreadyRegisteredException()
        {
            var tested = new BlockDataPoolRegistry();
            
            tested.Register(0, () => null);

            Assert.Throws<ElementAlreadyRegisteredException>(() => tested.Register(0, () => null));
        }
    }
}