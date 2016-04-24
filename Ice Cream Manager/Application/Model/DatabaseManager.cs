/// <project> IceCreamManager </project>
/// <module> DatabaseManager </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-03 </date_created>

using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Manages the connection and interaction with the database. 
    /// </summary>
    /// <remarks>
    ///   Follows the Singleton design pattern; only one copy exists, provides own reference, and created on first access.
    /// </remarks>
    /// <example>
    ///   Place the following line at the top of the class that needs database access:
    ///
    ///   DatabaseManager Database = DatabaseManager.DatabaseReference;
    ///
    ///   You then have access to all the public methods through the Database object reference.
    /// </example>
    public sealed class DatabaseManager // Sealed as Singleton
    {
        #region Singleton

        private static readonly DatabaseManager SingletonInstance = new DatabaseManager();

        /// <summary>
        ///   Reference to the DatabaseManager Singleton instance. 
        /// </summary>
        public static DatabaseManager Reference { get { return SingletonInstance; } }

        #endregion Singleton

        private SQLiteConnection DatabaseConnection;
        private SQLiteDataReader DataReaderConnection;
        private SQLiteCommand DatabaseCommandExecuter;
        public int LastInsertID = 0;

        private static string DatabaseFile;
        private static string DatabaseFileAccessDetails;

        private DatabaseManager() // Private as Singleton
        {
            GenerateDatabaseFileAccessDetails();

            EnsureDatabaseExistence();

            EstablishConnectionToDatabase();

            CreateDatabaseCommandExecuter();
        }

        /// <summary>
        ///   Generated the database file access based on the environment. 
        /// </summary>
        /// <preconditions> None </preconditions>
        /// <postconditions> None </postconditions>
        private void GenerateDatabaseFileAccessDetails()
        {
#if DEBUG   // Development
            DatabaseFile = "../../../TestDatabase.db";
            //DatabaseFile = "C:/Cosmosys/Ice Cream Manager/TestDatabase.db"; // Marc's path
#else       // Production
            DatabaseFile = "IceCreamManager.db";
#endif
            DatabaseFileAccessDetails = String.Format("Data Source={0};Version=3;", DatabaseFile);
        }

        // TODO: Make custom exceptions for all the exceptions this class can raise.

        /// <summary>
        ///   Ensures the existence of the database. 
        /// </summary>
        /// <preconditions> The database file path must be writable. </preconditions>
        /// <postconditions> The database file was created if it didn't exist. </postconditions>
        private static void EnsureDatabaseExistence()
        {
            try
            {
                if (File.Exists(DatabaseFile) == false)
                {
                    SQLiteConnection.CreateFile(DatabaseFile);
                }
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error creating the database file.", e);
            }
        }

        /// <summary>
        ///   Establishes a connection to the database. 
        /// </summary>
        /// <preconditions> The database file must exist. </preconditions>
        /// <postconditions> The connection to the database has been established. </postconditions>
        private void EstablishConnectionToDatabase()
        {
            try
            {
                DatabaseConnection = new SQLiteConnection(DatabaseFileAccessDetails);
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error establishing connection to the database file.", e);
            }
        }

        /// <summary>
        ///   Opens the connection to the database. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions> The connection to the database will accept database commands. </postconditions>
        private void OpenConnectionToDatabase()
        {
            try
            {
                if (DatabaseConnection.State == ConnectionState.Closed)
                {
                    DatabaseConnection.Open();
                }
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error opening connection to the database.", e);
            }
        }

        /// <summary>
        ///   Closes the connection to the database. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions> The connection to the database will not accept database commands. </postconditions>
        private void CloseConnectionToDatabase()
        {
            try
            {
                if (DatabaseConnection.State == ConnectionState.Open)
                {
                    DatabaseConnection.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error closing connection to the database.", e);
            }
        }

        /// <summary>
        ///   Creates an executer of database commands. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions> The database command executer is ready to accept commands. </postconditions>
        private void CreateDatabaseCommandExecuter()
        {
            try
            {
                DatabaseCommandExecuter = DatabaseConnection.CreateCommand();
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error creating database command executer.", e);
            }
        }

        /// <summary>
        ///   Provides the database command executer with the database command to be executed. 
        /// </summary>
        /// <preconditions> The database command executer must be ready to accept database commands. </preconditions>
        /// <postconditions>
        ///   The database command executer is ready to execute the provided database command.
        /// </postconditions>
        /// <param name="databaseCommandToExecute">
        ///   The database command to be executed by the database command executer.
        /// </param>
        private void ProvideExecuterCommandToExecute(string databaseCommandToExecute)
        {
            try
            {
                DatabaseCommandExecuter.CommandText = databaseCommandToExecute;
            }
            catch (Exception e)
            {
                throw new Exception("Error providing database command executer with the database command to execute.", e);
            }
        }

        /// <summary>
        ///   Opens a data reader connection to the database based on the database command to execute. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions>
        ///   The data reader connection based on the database command to execute will be open for reading rows of data.
        /// </postconditions>
        /// <param name="databaseCommand"> The database command the data reader connection will be based upon. </param>
        private void OpenDataReaderConnectionBasedOnDatabaseCommand(string databaseCommand)
        {
            try
            {
                OpenConnectionToDatabase();

                ProvideExecuterCommandToExecute(databaseCommand);

                DataReaderConnection = DatabaseCommandExecuter.ExecuteReader();
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error opening a data reader connection to the database.", e);
            }
        }

        /// <summary>
        ///   Closes the current data reader connection to the database. 
        /// </summary>
        /// <preconditions> A data reader connection to the database must exist. </preconditions>
        /// <postconditions> The current data reader connection to the database is closed. </postconditions>
        private void CloseDataReaderConnection()
        {
            try
            {
                if (DataReaderConnection != null && DataReaderConnection.IsClosed != true)
                {
                    DataReaderConnection.Close();
                }
                CloseConnectionToDatabase();
            }
            catch (SQLiteException e)
            {
                throw new Exception("Error closing a data reader connection to the database.", e);
            }
        }

        /// <summary>
        ///   Creates a data table containing results from the database based on the database command. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions> No changes are made to the database. </postconditions>
        /// <param name="databaseCommand">
        ///   The database command that provides the results that the data table is created from.
        /// </param>
        /// <returns> The results of the database query. </returns>
        public DataTable DataTableFromCommand(string databaseCommand)
        {
            DataTable ResultsDataTable = new DataTable();

            try
            {
                OpenDataReaderConnectionBasedOnDatabaseCommand(databaseCommand);

                ResultsDataTable.Load(DataReaderConnection);

                CloseDataReaderConnection();
            }
            catch (Exception e)
            {
                throw new Exception("Error creating a data table based on a database command.", e);
            }

            return ResultsDataTable;
        }

        /// <summary>
        ///   Executes a database command on the database. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions> The database will reflect the command that was executed. </postconditions>
        /// <param name="DatabaseCommand"> The database command that will be executed on the database. </param>
        /// <returns> The number of database rows affected by the database command. </returns>
        public int ExecuteCommand(string DatabaseCommand)
        {
            int NumberOfRowsAffectedByCommand = 0;

            try
            {
                OpenConnectionToDatabase();

                ProvideExecuterCommandToExecute(DatabaseCommand);

                NumberOfRowsAffectedByCommand = DatabaseCommandExecuter.ExecuteNonQuery();

                // Get last insert row id
                ProvideExecuterCommandToExecute("SELECT last_insert_rowid()");

                DataReaderConnection = DatabaseCommandExecuter.ExecuteReader();

                DataTable ResultsTable = new DataTable();

                ResultsTable.Load(DataReaderConnection);

                LastInsertID = ResultsTable.Row().Col();

                CloseConnectionToDatabase();
            }
            catch (Exception e)
            {
                throw new Exception("Error executing a database command on the database.", e);
            }

            return NumberOfRowsAffectedByCommand;
        }

        /// <summary>
        ///   Marks a row in a database table as deleted. 
        /// </summary>
        /// <preconditions> The connection to the database file must be established. </preconditions>
        /// <postconditions> The specified database row is marked as deleted. </postconditions>
        /// <param name="tableName"> The name of the database table that contains the row to be marked as deleted. </param>
        /// <param name="id"> The unique identity number of the database row to be marked as deleted. </param>
        /// <returns> Whether or not the database row was marked as deleted. </returns>
        public bool MarkAsDeleted(string tableName, int id)
        {
            string DatabaseCommand = $"UPDATE {tableName} SET IsDeleted = 1 WHERE id = {id}";

            try
            {
                if (ExecuteCommand(DatabaseCommand) > 0) return true;
                else return false;
            }
            catch (Exception e)
            {
                throw new Exception("Error marking a database row as deleted.", e);
            }
        }

    }

    /// <summary>
    /// Provides simple access to the database manager methods.
    /// </summary>
    public sealed class Database
    {
        #region Singleton
        private static readonly Database SingletonInstance = new Database();
        public static Database Reference { get { return SingletonInstance; } }
        private Database() { }
        #endregion Singleton
        private static DatabaseManager DatabaseMan = DatabaseManager.Reference;
        public static DataTable Query(string query) => DatabaseMan.DataTableFromCommand(query);
        public static int NonQuery(string nonQuery) => DatabaseMan.ExecuteCommand(nonQuery);
    }

    
}