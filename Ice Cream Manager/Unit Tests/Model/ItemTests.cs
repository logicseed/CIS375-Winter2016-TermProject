using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IceCreamManager.Model
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int test = 4;
            test++;
            Assert.AreEqual(5, test);
        }
    }
}
