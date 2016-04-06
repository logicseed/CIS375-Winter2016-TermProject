/// <project>IceCreamManager</project>
/// <module>ExtensionMethodsTests</module>
/// <author>Marc King</author>
/// <date_created>2016-04-03</date_created>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IceCreamManager.Controller
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void DateTimeToSQLiteDatetime()
        {
            // Should output "YYYY-MM-DD HH:MM:SS.SSS" formatted string.
            DateTime dateTime = new DateTime(2016, 4, 3, 13, 50, 23, 42);
            string result = dateTime.ToDatabase();

            Assert.AreEqual("2016-04-03 13:50:23.042", result, "Output didn't match expected format.");
        }
    }
}
