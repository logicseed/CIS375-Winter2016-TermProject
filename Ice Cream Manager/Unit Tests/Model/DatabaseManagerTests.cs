/// <project>IceCreamManager</project>
/// <module>DatabaseManagerTests</module>
/// <author>Marc King</author>
/// <date_created>2016-04-03</date_created>

using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace IceCreamManager.Model
{
    [TestClass]
    public class DatabaseManagerTests
    {
        DatabaseManager Database = DatabaseManager.DatabaseReference;

        [TestMethod]
        public void MalformedQueryException()
        {
            try
            {
                DataTable TestDataTable = Database.DataTableFromCommand("GARBAGEQUERYSDFLKHSDFKJSH");
                Assert.Fail("Does not throw exception on malformed query.");
            }
            catch (Exception)
            {
                // Threw an exception as expected.
            }
        }

        [TestMethod]
        public void MalformedNonQueryException()
        {
            try
            {
                Database.ExecuteCommand("GARBAGENONQUERYLKSDFSDF");
                Assert.Fail("Does not throw exception on malformed non-query.");
            }
            catch (Exception)
            {
                // Threw an exception as expected.
            }
        }

        [TestMethod]
        public void ExecuteQuery()
        {
            string DatabaseCommand = "SELECT id FROM test_table";
            DataTable ResultsDataTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(3, ResultsDataTable.Rows.Count);
            DatabaseCommand = "SELECT id FROM test_table WHERE id = 2";
            ResultsDataTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(1, ResultsDataTable.Rows.Count);
        }

        [TestMethod]
        public void ExecuteNonQuery()
        {
            string DatabaseCommand = "CREATE TABLE nonquery_test (id INTEGER)";
            Assert.AreEqual(0, Database.ExecuteCommand(DatabaseCommand));
            DatabaseCommand = "INSERT INTO nonquery_test VALUES (23)";
            Assert.AreEqual(1, Database.ExecuteCommand(DatabaseCommand));
            DatabaseCommand = "DROP TABLE nonquery_test";
            Assert.AreEqual(0, Database.ExecuteCommand(DatabaseCommand));
        }

        [TestMethod]
        public void IntColumnConversion()
        {
            string DatabaseCommand = "SELECT test_int FROM test_table";
            DataTable ResultsDataTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(1, Convert.ToInt32(ResultsDataTable.Rows[0]["test_int"]));
            Assert.AreEqual(2, Convert.ToInt32(ResultsDataTable.Rows[1]["test_int"]));
            Assert.AreEqual(3, Convert.ToInt32(ResultsDataTable.Rows[2]["test_int"]));
        }

        [TestMethod]
        public void TextColumnConversion()
        {
            string DatabaseCommand = "SELECT test_text FROM test_table";
            DataTable ResultsDataTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual("row one", Convert.ToString(ResultsDataTable.Rows[0]["test_text"]));
            Assert.AreEqual("row two", Convert.ToString(ResultsDataTable.Rows[1]["test_text"]));
            Assert.AreEqual("row three", Convert.ToString(ResultsDataTable.Rows[2]["test_text"]));
        }

        [TestMethod]
        public void DatetimeColumnConversion()
        {
            string DatabaseCommand = "SELECT test_datetime FROM test_table";
            DataTable ResultsDataTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(new DateTime(2016, 4, 3, 13, 50, 23, 42), Convert.ToDateTime(ResultsDataTable.Rows[0]["test_datetime"]));
            Assert.AreEqual(new DateTime(2016, 4, 3, 14, 50, 23, 42), Convert.ToDateTime(ResultsDataTable.Rows[1]["test_datetime"]));
            Assert.AreEqual(new DateTime(2016, 4, 3, 15, 50, 23, 42), Convert.ToDateTime(ResultsDataTable.Rows[2]["test_datetime"]));
        }

        [TestMethod]
        public void NullInNotNullColumnException()
        {
            string DatabaseCommand = "CREATE TABLE test_null_table ( id INTEGER NOT NULL, test_null INTEGER NOT NULL)";
            Database.ExecuteCommand(DatabaseCommand);
            try
            {
                DatabaseCommand = "INSERT INTO test_null_table (id, test_null) VALUES (1, NULL)";
                Database.ExecuteCommand(DatabaseCommand);
                Assert.Fail("Does not throw exception when violating NOT NULL constraint.");
            }
            catch (Exception)
            {
                // Threw an exception as expected.
            }
            finally
            {
                DatabaseCommand = "DROP TABLE test_null_table";
                Database.ExecuteCommand(DatabaseCommand);
            }
        }

        [TestMethod]
        public void OrderByDatetimeColumn()
        {
            string DatabaseCommand = "SELECT * FROM test_table ORDER BY test_datetime DESC";
            DataTable ResultsDataTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(3, Convert.ToInt32(ResultsDataTable.Rows[0]["test_int"]));
            Assert.AreEqual(2, Convert.ToInt32(ResultsDataTable.Rows[1]["test_int"]));
            Assert.AreEqual(1, Convert.ToInt32(ResultsDataTable.Rows[2]["test_int"]));
        }
    }
}
