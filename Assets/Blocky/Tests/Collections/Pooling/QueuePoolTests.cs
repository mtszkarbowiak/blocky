using AuroraSeeker.Blocky.Shared.Collections.Pooling;
using NUnit.Framework;

namespace AuroraSeeker.Blocky.Tests.Collections.Pooling
{
    public class QueuePoolTests
    {
        [Test]
        public void Pool_Feed16()
        {
            var tested = new QueuePool<object>(() => new object());
            
            AbstractPool.Pool_NotNullElement_Feed16(tested);
        }
        
        [Test]
        public void Pool_TotalCount_Cycles3()
        {
            var tested = new QueuePool<object>(() => new object());
            
            AbstractPool.Pool_TotalCount_Cycles3(tested);
        }
    }
}