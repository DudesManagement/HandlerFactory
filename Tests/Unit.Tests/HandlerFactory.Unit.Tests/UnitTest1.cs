using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dudes.HandlerFactory.Configurations;
using Dudes.Logger;

namespace HandlerFactory.Unit.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DefaultConfiguration x = new DefaultConfiguration(new NullLogger());
        }
    }
}
