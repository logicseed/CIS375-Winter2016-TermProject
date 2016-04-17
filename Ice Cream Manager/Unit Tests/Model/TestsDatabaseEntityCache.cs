/// <project> IceCreamManager </project>
/// <module> DatabaseEntityCacheTests </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Model;

namespace IceCreamManager.UnitTests.Model
{
    [TestClass]
    public class TestsDatabaseEntityCache
    {
        private DatabaseEntityCache TestEntityCache = DatabaseEntityCache.Reference;

        // Due to the nature of the class being tested here, no method can be tested in isolation.
        // We cannot test to see if an Add() occurred successfully without using Get() or Contains(),
        // just like we can't test Remove() without the previous two methods. For this reason all
        // of the methods will be tested in a single test method. The Assert. calls will be given
        // verbose messages so that if this test fails we will information as to which part failed.
        [TestMethod]
        public void CachingFunctionality()
        {
            TestDatabaseEntity testDatabaseEntity = new TestDatabaseEntity();
            testDatabaseEntity.ID = 423;

            Assert.AreEqual(true, TestEntityCache.Add("TestCache", testDatabaseEntity),
                "Add() Not returning true after adding object to cache.");
            Assert.AreEqual(false, TestEntityCache.Add("TestCache", testDatabaseEntity),
                "Add() Not returning after trying to add an object already added to cache.");
            // Now we should get a reference to the same object in memory.
            TestDatabaseEntity testEntityFromCache = (TestDatabaseEntity)TestEntityCache.Get("TestCache", 423);
            Assert.AreSame(testDatabaseEntity, testEntityFromCache, 
                "Add() Not referencing the same object in memory.");

            Assert.AreEqual(true, TestEntityCache.Contains("TestCache", testDatabaseEntity.ID), 
                "Contains() Not returning true when cache contains object.");
            Assert.AreEqual(true, TestEntityCache.Remove("TestCache", testDatabaseEntity), 
                "Remove() Not returning true when object removed from cache.");
            Assert.AreEqual(false, TestEntityCache.Remove("TestCache", testDatabaseEntity), 
                "Remove() Not returning false when object not removed from cache.");
            Assert.AreEqual(false, TestEntityCache.Contains("TestCache", testDatabaseEntity.ID),
                "Contains() Not returning false when cache does not contain object.");
        }
        
    }
}
