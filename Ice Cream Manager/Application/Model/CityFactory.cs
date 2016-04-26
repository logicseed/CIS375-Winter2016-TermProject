/// <project> IceCreamManager </project>
/// <module> CityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Provides an interface for the creation and loading of cities. Most of its functionality is provided by DatabaseEntityFactory. 
    /// </summary>
    public class CityFactory : DatabaseEntityFactory<City>
    {
        #region Singleton

        public static CityFactory Reference { get { return SingletonInstance; } }
        private static readonly CityFactory SingletonInstance = new CityFactory();

        private CityFactory()
        {
        }

        #endregion Singleton

        #region Public Methods

        /// <summary>
        ///   Marks all existing Cities in the database as deleted. 
        /// </summary>
        /// <returns> Whether or not all the Cities were marked as deleted. </returns>
        public bool DeleteAll()
        {
            var sql = $"UPDATE {TableName} SET IsDeleted = 1 WHERE IsDeleted = 0";

            if (Database.NonQuery(sql) > 0) return true;
            else return false;
        }

        /// <summary>
        ///   Checks to see if a City exists with the specified Label. 
        /// </summary>
        /// <param name="cityLabel"> The Label to check. </param>
        /// <param name="isDeleted"> Whether or not Cities marked as deleted should be included in the check. </param>
        /// <returns> Whether or not a City exists with the specified Label. </returns>
        public bool Exists(string cityLabel, bool isDeleted)
        {
            var sql = $"SELECT 1 FROM {TableName} WHERE Label = '{cityLabel}' AND IsDeleted = {isDeleted.ToDatabase()}";

            var table = Database.Query(sql);

            if (table.Rows.Count == 0) return true;
            else return false;
        }

        /// <summary>
        ///   Checks to see if a City exists with the specified Label. 
        /// </summary>
        /// <param name="cityLabel"> The Label to check. </param>
        /// <returns> Whether or not a City exists with the specified Label. </returns>
        public bool Exists(string cityLabel)
        {
            return Exists(cityLabel, false);
        }

        public City Load(string label)
        {
            return Load(GetCityID(label));
        }
        /// <summary>
        ///   Builds a list of Cities that are available to be assigned to Routes. 
        /// </summary>
        /// <returns> A List of instantiated City objects. </returns>
        public List<City> GetAvailableCityList()
        {
            var DatabaseCommand = $"SELECT * FROM City WHERE ID NOT IN (SELECT CityID FROM RouteCity WHERE IsDeleted = 0) AND IsDeleted = 0 ORDER BY Label";

            var ResultsTable = Database.Query(DatabaseCommand);
            var CityList = new List<City>();

            foreach (DataRow Row in ResultsTable.Rows)
            {
                CityList.Add(MapDataRowToProperties(Row));
            }

            return CityList;
        }

        /// <summary>
        ///   Gets a City database ID based on the specified Label. 
        /// </summary>
        /// <param name="cityLabel"> The Label to find the City ID for. </param>
        /// <returns> The ID of a City with the specified Label. </returns>
        public int GetCityID(string cityLabel)
        {
            var sql = $"SELECT ID FROM {TableName} WHERE Label = '{cityLabel}' AND IsDeleted = 0";

            var table = Database.Query(sql);

            if (table.Rows.Count == 0) return 0;

            return table.Row().Col("ID");
        }

        /// <summary>
        ///   Builds a list of all Cities in the database. 
        /// </summary>
        /// <param name="includeDeleted"> Whether or not Cities marked as deleted should be included. </param>
        /// <returns> A List of instantiated City objects. </returns>
        public List<City> GetCityList(bool includeDeleted)
        {
            var sql = $"SELECT * FROM City ";
            if (!includeDeleted) sql += "WHERE IsDeleted = 0 ";
            sql += "ORDER BY Label";

            var table = Database.Query(sql);
            var cityList = new List<City>();

            foreach (DataRow row in table.Rows)
            {
                cityList.Add(MapDataRowToProperties(row));
            }

            return cityList;
        }

        /// <summary>
        ///   Builds a List of instantiated City objects that are assigned to the specified Route. 
        /// </summary>
        /// <param name="routeID"> The ID of the Route whose Cities are put into the List. </param>
        /// <returns> A List of City objects. </returns>
        public List<City> GetCityList(int routeID)
        {
            var cities = new List<City>();
            var sql = $"SELECT * FROM City WHERE ID IN (SELECT CityID FROM RouteCity WHERE RouteID = {routeID})";
            var table = Database.Query(sql);

            foreach (DataRow row in table.Rows)
            {
                cities.Add(MapDataRowToProperties(row));
            }

            return cities;
        }

        /// <summary>
        ///   Builds a DataTable containing Cities from the database. 
        /// </summary>
        /// <param name="includeDeleted"> Whether or not Cities marked as deleted should be included. </param>
        /// <returns> A DataTable filled with City values. </returns>
        public override DataTable GetDataTable(bool includeDeleted)
        {
            var databaseTable = GetAllDataTableOrdered(includeDeleted, "ORDER BY Label");
            var returnTable = new DataTable();

            returnTable.Columns.Add(new DataColumn("ID", typeof(int)));
            returnTable.Columns.Add(new DataColumn("Label", typeof(string)));
            returnTable.Columns.Add(new DataColumn("Name", typeof(string)));
            returnTable.Columns.Add(new DataColumn("State", typeof(string)));
            returnTable.Columns.Add(new DataColumn("Miles", typeof(double)));
            returnTable.Columns.Add(new DataColumn("Hours", typeof(double)));
            returnTable.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow row in databaseTable.Rows)
            {
                DataRow returnRow = returnTable.NewRow();

                returnRow["ID"] = row.Col("ID");
                returnRow["Label"] = row.Col<string>("Label");
                returnRow["Name"] = row.Col<string>("Name");
                returnRow["State"] = row.Col<string>("State");
                returnRow["Miles"] = row.Col<double>("Miles");
                returnRow["Hours"] = row.Col<double>("Hours");
                returnRow["IsDeleted"] = row.Col<bool>("IsDeleted");

                returnTable.Rows.Add(returnRow);
            }

            return returnTable;
        }

        /// <summary>
        ///   Builds a DataTable containing City IDs and Labels based on a specified List of Cities. 
        /// </summary>
        /// <param name="cityList"> The List of Cities with which to build the DataTable. </param>
        /// <returns> A DataTable containing the Cities. </returns>
        public DataTable GetRouteCityDataTable(List<City> cityList)
        {
            var routeCityDataTable = new DataTable();

            routeCityDataTable.Columns.Add(new DataColumn("ID", typeof(int)));
            routeCityDataTable.Columns.Add(new DataColumn("Label", typeof(string)));

            foreach (City city in cityList)
            {
                var rowToAdd = routeCityDataTable.NewRow();
                rowToAdd["ID"] = city.ID;
                rowToAdd["Label"] = city.Label;

                routeCityDataTable.Rows.Add(rowToAdd);
            }

            routeCityDataTable.PrimaryKey = new DataColumn[] { routeCityDataTable.Columns["ID"] };

            return routeCityDataTable;
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        ///   Fills a provided Dictionary with key-value pairs of ID and Label of Cities for use in DropDownBoxes. 
        /// </summary>
        /// <param name="cityList"> The Dictionary to fill. </param>
        internal void GetCityLabelList(ref Dictionary<string, string> cityList)
        {
            var sql = $"SELECT * FROM City WHERE IsDeleted = 0 ORDER BY Label";
            var table = Database.Query(sql);

            foreach (DataRow row in table.Rows)
            {
                var name = $"{row.Col<string>("Label")}, {row.Col<string>("Name")}, {row.Col<string>("State")}";
                cityList.Add(row.Col<string>("Label"), name);
            }
        }

        /// <summary>
        ///   Checks to see if a Label is in use by another City that is not marked as deleted. 
        /// </summary>
        /// <param name="city"> The City with the label to check. </param>
        /// <returns> Whether or not the label is in use. </returns>
        internal bool LabelInUse(City city)
        {
            var sql = $"SELECT * FROM City WHERE Label = '{city.Label}' AND IsDeleted = 0";
            var table = Database.Query(sql);
            return (table.Rows.Count > 0);
        }

        #endregion Internal Methods

        #region Protected Properties

        /// <summary>
        ///   Provides the table name in the database where Cities are stored. 
        /// </summary>
        protected override string TableName => "City";

        #endregion Protected Properties

        #region Protected Methods

        /// <summary>
        ///   Provides the name of the City table fields in the database. 
        /// </summary>
        protected override string DatabaseQueryColumns()
            => "Label,Name,State,Miles,Hours,IsDeleted";

        /// <summary>
        ///   Provides a string of field-values pairs for use in SQL statements. 
        /// </summary>
        protected override string DatabaseQueryColumnValuePairs(City city)
            => $"Label = '{city.Label}',Name = '{city.Name}',State = '{city.State}',Miles = {city.Miles},Hours = {city.Hours},IsDeleted = {city.IsDeleted.ToDatabase()}";

        /// <summary>
        ///   Provides a string of City table field values for use in SQL statements. 
        /// </summary>
        protected override string DatabaseQueryValues(City city)
            => $"'{city.Label}','{city.Name}','{city.State}',{city.Miles},{city.Hours},{city.IsDeleted.ToDatabase()}";

        /// <summary>
        ///   Fills a City object with values from a DataRow contained database query results. 
        /// </summary>
        /// <param name="row"> The DataRow used to fill the City. </param>
        /// <returns> A City object filled with the values in the DataRow. </returns>
        protected override City MapDataRowToProperties(DataRow row)
        {
            var city = new City();

            city.ID = row.Col("ID");
            city.Label = row.Col<string>("Label");
            city.Name = row.Col<string>("Name");
            city.State = row.Col<string>("State");
            city.Miles = row.Col<double>("Miles");
            city.Hours = row.Col<double>("Hours");
            city.IsDeleted = row.Col<bool>("IsDeleted");
            city.InDatabase = true;
            city.IsSaved = true;

            return city;
        }

        /// <summary>
        ///   Creates a string for use in log entries related to actions performed on Cities. 
        /// </summary>
        /// <param name="city"> The City that action was performed on. </param>
        /// <returns> The log message. </returns>
        protected override string SaveLogString(City city)
        {
            return $"City Label {city.Label} to {city.Name} in {city.State}, which takes {city.Hours} hours to service its {city.Miles} miles.";
        }

        #endregion Protected Methods
    }
}
