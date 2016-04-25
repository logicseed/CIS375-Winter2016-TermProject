using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamManager.Model;
using System.Data;

namespace IceCreamManager.UnitTests.Model
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DatabaseManager Database = DatabaseManager.Reference;
            Item item = new Item();

            string DatabaseCommand = $"SELECT * FROM Item WHERE ID = 1";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            DataRow row = ResultsTable.Rows[0];

            item.ID = row.Col("ID");
            item.Number = row.Col("Number");
            item.Description = row.Col<string>("Description");
            item.Price = row.Col<double>("Price");
            item.Lifetime = row.Col("Lifetime");
            item.Quantity = row.Col("Quantity");
            item.IsDeleted = row.Col<bool>("IsDeleted");
            item.InDatabase = true;
            item.IsSaved = true;

            Assert.IsTrue(item.Number == 1);
        }


        [TestMethod]
        public void MethodName_Action_ExpectedResult()
        {
            Item item = Factory.Item.Load(1);

            Assert.IsTrue(item.Number == 1);
        }

    }
}
