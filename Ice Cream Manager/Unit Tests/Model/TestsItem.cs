/// <project> IceCreamManager </project>
/// <module> ItemTests </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-11 </date_created>

using System;
using IceCreamManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IceCreamManager.UnitTests.Model
{
    [TestClass]
    public class TestsItem
    {
        private DatabaseManager Database = DatabaseManager.Reference;

        //[TestMethod]
        //public void Load_LoadValidID_InstantiatedItemObject()
        //{
        //    Item TestItem = new Item(2);

        //    Assert.AreEqual(3, TestItem.Number);
        //    Assert.AreEqual("Vanilla", TestItem.Description);
        //    Assert.AreEqual(2.5, TestItem.Price);
        //    Assert.AreEqual(60, TestItem.Lifetime);
        //    Assert.AreEqual(5, TestItem.Quantity);
        //    Assert.AreEqual(true, TestItem.IsDeleted);
        //}

        //[TestMethod]
        //public void Load_LoadInvalidID_ArgumentOutOfRangeException()
        //{
        //    try
        //    {
        //        Item TestItem = new Item(-1);
        //        Assert.Fail("Didn't throw exception.");
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        // Expected this exception.
        //    }
        //}

        //[TestMethod]
        //public void Save_PropertyMarksAsDeleted_ItemInDatabaseAndOriginalMarkedAsDeleted()
        //{
        //    int OriginalID = 1;
        //    int ChangedID;

        //    Item OriginalItem = new Item(OriginalID);
        //    OriginalItem.Description = "Test Description";
        //    Assert.AreEqual(false, OriginalItem.IsSaved);
        //    OriginalItem.Save();
        //    ChangedID = OriginalItem.ID;
        //    Assert.AreNotEqual(OriginalID, ChangedID);

        //    // check original was deleted
        //    OriginalItem = new Item(OriginalID);
        //    Assert.AreEqual(true, OriginalItem.IsDeleted);
        //    Database.ExecuteCommand($"UPDATE Item SET IsDeleted = 0 WHERE ID = {OriginalID}");

        //    Item ChangedItem = new Item(ChangedID);
        //    Assert.AreEqual("Test Description", ChangedItem.Description);

        //    Database.ExecuteCommand($"DELETE FROM Item WHERE ID = {ChangedID}");
        //}
    }
}
