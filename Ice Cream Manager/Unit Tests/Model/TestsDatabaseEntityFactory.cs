/// <project> IceCreamManager </project>
/// <module> DatabaseEntityFactoryTests </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Model;
using System.Data;

namespace IceCreamManager.UnitTests.Model
{
    /// <summary>
    /// Concrete version of abstract class for testing.
    /// </summary>
    public class TestDatabaseEntityFactory : DatabaseEntityFactory<TestDatabaseEntity>
    {
        #region Singleton
        private static readonly TestDatabaseEntityFactory SingletonInstance = new TestDatabaseEntityFactory();
        public static TestDatabaseEntityFactory Reference { get { return SingletonInstance; } }
        private TestDatabaseEntityFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "TestInteger,TestDouble,TestBoolean,TestString,TestDateTime";

        protected override string DatabaseQueryColumnValuePairs(TestDatabaseEntity test)
            => $"TestInteger = {test.TestInteger},TestDouble = {test.TestDouble},TestBoolean = {test.TestBoolean.ToDatabase()},TestString = '{test.TestString}',TestDateTime = '{test.TestDateTime.ToDatabase()}'";

        protected override string DatabaseQueryValues(TestDatabaseEntity test)
            => $"{test.TestInteger},{test.TestDouble},{test.TestBoolean.ToDatabase()},'{test.TestString}','{test.TestDateTime.ToDatabase()}'";

        protected override TestDatabaseEntity MapDataRowToProperties(DataRow row)
        {
            TestDatabaseEntity test = new TestDatabaseEntity();

            test.ID = row.Col("ID");
            test.TestInteger = row.Col("TestInteger");
            test.TestDouble = row.Col<double>("TestDouble");
            test.TestString = row.Col<string>("TestString");
            test.TestBoolean = row.Col<bool>("TestBoolean");
            test.TestDateTime = row.ColDateTime("TestDateTime");

            return test;
        }
    }


    [TestClass]
    public class TestsDatabaseEntityFactory
    {
        TestDatabaseEntityFactory TestFactory = TestDatabaseEntityFactory.Reference;

        [TestMethod]
        public void CreateNewEmptyEntity()
        {
            TestDatabaseEntity test = TestFactory.New();
            Assert.IsFalse(test == null, "Factory.New() did not return instantiated entity.");
            
            Assert.IsTrue(test.ID == 0, "ID not set to zero.");

            Assert.IsFalse(test.InDatabase, "InDatabase not set to false.");
            Assert.IsFalse(test.IsSaved, "IsSaved not set to false.");
            Assert.IsFalse(test.IsDeleted, "IsDeleted not set to false.");
            Assert.IsFalse(test.ReplaceOnSave, "ReplaceOnSave not set to false.");
        }


        [TestMethod]
        public void SaveEntityToDatabase()
        {
            TestDatabaseEntity test = TestFactory.New();

            test.TestInteger = 42;
            Assert.IsTrue(test.TestInteger == 42, "TestInteger not set correctly.");
            test.TestDouble = 4.2;
            Assert.IsTrue(test.TestDouble == 4.2, "TestDouble not set correctly.");
            test.TestString = "ATLTUAE";
            Assert.IsTrue(test.TestString == "ATLTUAE", "TestString not set correctly.");
            test.TestBoolean = true;
            Assert.IsTrue(test.TestBoolean, "TestBoolean not set correctly.");

            DateTime testDate = DateTime.Now;
            test.TestDateTime = testDate;
            Assert.IsTrue(test.TestDateTime.CompareTo(testDate) == 0, "TestDateTime not set correctly.");

            Assert.IsTrue(TestFactory.Save(test), "Save() did not return true on saving new entity.");
            Assert.IsTrue(test.InDatabase, "InDatabase not set to true after saving new entity.");
            Assert.IsTrue(test.IsSaved, "IsSaved not set to true after saving new entity.");
            Assert.IsTrue(test.ID > 0, "ID not set after saving new entity.");

            TestDatabaseEntity testRef = TestFactory.Load(test.ID);


            //Assert.AreSame(test, testRef, "Same object reference not returned when loading the saved entity.");


                


            
        }
    }
}
