using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Model;

namespace IceCreamManager.Model
{
    [TestClass]
    public class ItemTests
    {
        DatabaseManager Database = DatabaseManager.DatabaseReference;

        Item TestItem;

        [TestMethod]
        public void ItemConstructor_ValidID_InstantiatedItem()
        {
            // Arrange
            TestItem = new Item(1);
            // Act

            // Assert
            Assert.AreEqual(1, TestItem.ID, "ID");
            Assert.AreEqual(1, TestItem.Number, "Number");
            Assert.AreEqual(0.5, TestItem.Price, "Price");
            Assert.AreEqual("test item", TestItem.Description, "Description");
            Assert.AreEqual(30, TestItem.Lifetime, "Lifetime");
            Assert.AreEqual(true, TestItem.Deleted, "Deleted");
            Assert.AreEqual(DateTime(2016, 4, 3, 13, 50, 23, 42), TestItem.Date_deleted, "DateDeleted");
        }


        [TestMethod]
        public void ItemConstructor_InvalidID_ThrowException()
        {
            // Arrange

            // Act

            // Assert
        }


    }
}
