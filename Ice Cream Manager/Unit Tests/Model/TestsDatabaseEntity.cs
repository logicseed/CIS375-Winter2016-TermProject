/// <project> IceCreamManager </project>
/// <module> DatabaseEntityTests </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Model;

namespace IceCreamManager.UnitTests.Model
{
    public class TestDatabaseEntity : DatabaseEntity
    {
        // Concrete version of abstract class for testing.
        public int TestInteger;
        public double TestDouble;
        public string TestString;
        public bool TestBoolean;
        public DateTime TestDateTime;

        public override bool Save()
        {
            return false;
        }
    }

    [TestClass]
    public class TestsDatabaseEntity
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
