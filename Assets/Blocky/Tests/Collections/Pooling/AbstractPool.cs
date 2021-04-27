using AuroraSeeker.Blocky.Shared.Collections.Pooling;
using NUnit.Framework;

namespace AuroraSeeker.Blocky.Tests.Collections.Pooling
{
    public static class AbstractPool
    {
        public static void Pool_NotNullElement_Feed16<T>(IPool<T> pool)
        {
            const int feed = 16;

            var count = pool.GetCount();

            for (var i = 0; i < count + feed; i++)
            {
                Assert.IsNotNull(pool.Get());
            }
        }
        
        public static void Pool_TotalCount_Cycles3<T>(IPool<T> pool)
        {
            const int feed = 2, cycles = 3;

            var count = pool.GetCount();
            var iterations = (count + feed) * cycles;

            for (var i = 0; i < iterations; i++)
            {
                var obj = pool.Get();
                
                pool.Return(obj);
            }

            Assert.IsTrue(iterations < pool.GetCount());
        }
    }
}