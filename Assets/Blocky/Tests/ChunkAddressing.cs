using NUnit.Framework;
using UnityEngine;
using static AuroraSeeker.Blocky.Shared.ChunkAddressing;

namespace AuroraSeeker.Blocky.Tests
{
    public class ChunkAddressing
    {
        [Test]
        public void UnpackAndPack()
        {
            var x = (ushort) Mathf.FloorToInt(Random.value * ChunkSize1D);
            var y = (ushort) Mathf.FloorToInt(Random.value * ChunkSize1D);
            var z = (ushort) Mathf.FloorToInt(Random.value * ChunkSize1D);

            var index = PackAddress(x, y, z);
            
            Assert.AreEqual(x, index.UnpackX());
            Assert.AreEqual(y, index.UnpackY());
            Assert.AreEqual(z, index.UnpackZ());
        }
        
        [Test]
        public void PackAndUnpack()
        {
            Restart:
            
            var index = (ushort) Mathf.FloorToInt(Random.value * ChunkSize3D);

            if (index == 0) goto Restart;

            var x = index.UnpackX();
            var y = index.UnpackY();
            var z = index.UnpackZ();

            var index2 = PackAddress(x, y, z);
            
            Assert.AreEqual(index, index2);
        }
    }
}