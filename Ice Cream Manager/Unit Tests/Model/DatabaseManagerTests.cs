/// <project> IceCreamManager </project>
/// <module> DatabaseManagerTests </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-03 </date_created>

using System;
using System.Data;
using IceCreamManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IceCreamManager.UnitTests.Model
{
    [TestClass]
    public class DatabaseManagerTests
    {
        private DatabaseManager Database = DatabaseManager.Reference;

        [TestMethod]
        public void DataTableFromCommand_MalformedQuery_ThrowsException()
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
        public void DataTableFromCommand_SelectDateTimeColumns_ResultsAsDateTimes()
        {
            string DatabaseCommand = "SELECT test_datetime FROM test_table";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(new DateTime(2016, 4, 3, 13, 50, 23, 42), Convert.ToDateTime(ResultsTable.Rows[0]["test_datetime"]));
            Assert.AreEqual(new DateTime(2016, 4, 3, 14, 50, 23, 42), Convert.ToDateTime(ResultsTable.Rows[1]["test_datetime"]));
            Assert.AreEqual(new DateTime(2016, 4, 3, 15, 50, 23, 42), Convert.ToDateTime(ResultsTable.Rows[2]["test_datetime"]));
        }

        [TestMethod]
        public void DataTableFromCommand_SelectDoubleColumns_ResultsAsDoubles()
        {
            string DatabaseCommand = "SELECT test_double FROM test_table";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(3.4, Convert.ToDouble(ResultsTable.Rows[0]["test_double"]));
            Assert.AreEqual(2.3, Convert.ToDouble(ResultsTable.Rows[1]["test_double"]));
            Assert.AreEqual(1.2, Convert.ToDouble(ResultsTable.Rows[2]["test_double"]));
        }

        [TestMethod]
        public void DataTableFromCommand_SelectIntegerColumns_ResultsAsIntegers()
        {
            string DatabaseCommand = "SELECT test_int FROM test_table";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(1, Convert.ToInt32(ResultsTable.Rows[0]["test_int"]));
            Assert.AreEqual(2, Convert.ToInt32(ResultsTable.Rows[1]["test_int"]));
            Assert.AreEqual(3, Convert.ToInt32(ResultsTable.Rows[2]["test_int"]));
        }
        [TestMethod]
        public void DataTableFromCommand_SelectStringColumns_ResultsAsStrings()
        {
            string DatabaseCommand = "SELECT test_text FROM test_table";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual("row one", Convert.ToString(ResultsTable.Rows[0]["test_text"]));
            Assert.AreEqual("row two", Convert.ToString(ResultsTable.Rows[1]["test_text"]));
            Assert.AreEqual("row three", Convert.ToString(ResultsTable.Rows[2]["test_text"]));
        }

        [TestMethod]
        public void DataTableFromCommand_SimpleQuery_ResultsFromDatabase()
        {
            string DatabaseCommand = "SELECT id FROM test_table";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(3, ResultsTable.Rows.Count);
            DatabaseCommand = "SELECT id FROM test_table WHERE id = 2";
            ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(1, ResultsTable.Rows.Count);
        }

        [TestMethod]
        public void DataTableFromCommand_SelectOrderedByDatetimeColumn_ResultsOrderedByDateTime()
        {
            string DatabaseCommand = "SELECT * FROM test_table ORDER BY test_datetime DESC";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);
            Assert.AreEqual(3, Convert.ToInt32(ResultsTable.Rows[0]["test_int"]));
            Assert.AreEqual(2, Convert.ToInt32(ResultsTable.Rows[1]["test_int"]));
            Assert.AreEqual(1, Convert.ToInt32(ResultsTable.Rows[2]["test_int"]));
        }
        [TestMethod]
        public void ExecuteCommand_MalformedNonQuery_ThrowsException()
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
        public void ExecuteCommand_CreateTableInsertThenDropTable_NoChangesToDatabase()
        {
            string DatabaseCommand = "CREATE TABLE nonquery_test (id INTEGER)";
            Assert.AreEqual(0, Database.ExecuteCommand(DatabaseCommand));
            DatabaseCommand = "INSERT INTO nonquery_test VALUES (23)";
            Assert.AreEqual(1, Database.ExecuteCommand(DatabaseCommand));
            DatabaseCommand = "DROP TABLE nonquery_test";
            Assert.AreEqual(0, Database.ExecuteCommand(DatabaseCommand));
        }

        [TestMethod]
        public void ExecuteCommand_InsertNullIntoNotNullColumn_ThrowsException()
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
        public void DateTimeExtension_ConvertDateTimeToDatabase_ResultsMatchRequiredFormat()
        {
            // Should output "YYYY-MM-DD HH:MM:SS.SSS" formatted string.
            DateTime dateTime = new DateTime(2016, 4, 3, 13, 50, 23, 42);
            string result = dateTime.ToDatabase();

            Assert.AreEqual("2016-04-03 13:50:23.042", result, "Output didn't match expected format.");
        }

        [TestMethod]
        public void DatatypeConversionExtensions_SelectVariousDatatypes_ConvertedToProperDatatypes()
        {
            string DatabaseCommand = "SELECT * FROM test_table";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            Assert.IsInstanceOfType(ResultsTable.Row().Col<int>("test_int"), typeof(int), "Failed casting database entry to int.");
            Assert.IsInstanceOfType(ResultsTable.Row().Col<string>("test_text"), typeof(string), "Failed casting database entry to string.");
            Assert.IsInstanceOfType(ResultsTable.Row().Col<bool>("test_bool"), typeof(bool), "Failed casting database entry to bool.");
            Assert.IsInstanceOfType(ResultsTable.Row().Col<DateTime>("test_datetime"), typeof(DateTime), "Failed casting database entry to DateTime.");
            Assert.IsInstanceOfType(ResultsTable.Row().Col<double>("test_double"), typeof(double), "Failed casting database entry to double.");
        }
    }
}
