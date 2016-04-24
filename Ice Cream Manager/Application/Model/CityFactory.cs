/// <project> IceCreamManager </project>
/// <module> CityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System;
using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Provides an interface for the creation and loading of cities. 
    /// </summary>
    public class CityFactory : DatabaseEntityFactory<City>
    {
        #region Singleton
        private static readonly CityFactory SingletonInstance = new CityFactory();
        public static CityFactory Reference { get { return SingletonInstance; } }
        private CityFactory() { }
        #endregion Singleton

        protected override string TableName => "City";

        protected override string DatabaseQueryColumns()
            => "Label,Name,State,Miles,Hours,IsDeleted";

        

        protected override string DatabaseQueryColumnValuePairs(City city)
            => $"Label = '{city.Label}',Name = '{city.Name}',State = '{city.State}',Miles = {city.Miles},Hours = {city.Hours},IsDeleted = {city.IsDeleted.ToDatabase()}";
        
        public List<City> GetAvailableCityList()
        {
            var DatabaseCommand = $"SELECT * FROM City WHERE ID NOT IN (SELECT CityID FROM RouteCity WHERE IsDeleted = 0) AND IsDeleted = 0";
            
            var ResultsTable = Database.Query(DatabaseCommand);
            var CityList = new List<City>();

            foreach (DataRow Row in ResultsTable.Rows)
            {
                CityList.Add(MapDataRowToProperties(Row));
            }

            return CityList;
        }

           public List<City> GetCityList(bool includeDeleted)
        {
            var DatabaseCommand = $"SELECT * FROM City";
            if (!includeDeleted) DatabaseCommand += " WHERE IsDeleted = 0";

            var ResultsTable = Database.Query(DatabaseCommand);
            var CityList = new List<City>();

            foreach (DataRow Row in ResultsTable.Rows)
            {
                CityList.Add(MapDataRowToProperties(Row));
            }

            return CityList;
        }

        protected override string DatabaseQueryValues(City city)
            => $"'{city.Label}','{city.Name}','{city.State}',{city.Miles},{city.Hours},{city.IsDeleted.ToDatabase()}";

        internal bool LabelInUse(City city)
        {
            var sql = $"SELECT * FROM City WHERE Label = '{city.Label}' AND IsDeleted = 0";
            var table = Database.Query(sql);
            return (table.Rows.Count > 0);
        }

        protected override City MapDataRowToProperties(DataRow row)
        {
            City city = new City();

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

        public bool DeleteAll()
        {
            string DatabaseCommand = $"UPDATE {TableName} SET IsDeleted = 1 WHERE IsDeleted = 0";

            if (DatabaseMan.ExecuteCommand(DatabaseCommand) > 0) return true;
            else return false;
        }

        public bool Exists(string cityLabel, bool isDeleted)
        {
            string DatabaseCommand = $"SELECT 1 FROM {TableName} WHERE Label = '{cityLabel}' AND IsDeleted = {isDeleted.ToDatabase()}";

            DataTable ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);

            if (ResultsTable.Rows.Count == 0) return true;
            else return false;
        }

        public bool Exists(string cityLabel)
        {
            return Exists(cityLabel, false);
        }

        public int GetCityID(string cityLabel)
        {
            string DatabaseCommand = $"SELECT ID FROM {TableName} WHERE Label = '{cityLabel}' AND IsDeleted = 0";

            DataTable ResultsTable = DatabaseMan.DataTableFromCommand(DatabaseCommand);

            if (ResultsTable.Rows.Count == 0) return 0;

            return ResultsTable.Row().Col("ID");
        }

        public City Load(string cityLabel)
        {
            throw new NotImplementedException();
        }

        public override DataTable GetDataTable(bool includeDeleted)
        {
            var TableFromDatabase = GetAllDataTable(includeDeleted);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Label", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Name", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("State", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Miles", typeof(double)));
            TableToReturn.Columns.Add(new DataColumn("Hours", typeof(double)));
            TableToReturn.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["Label"] = Row.Col<string>("Label");
                RowToReturn["Name"] = Row.Col<string>("Name");
                RowToReturn["State"] = Row.Col<string>("State");
                RowToReturn["Miles"] = Row.Col<double>("Miles");
                RowToReturn["Hours"] = Row.Col<double>("Hours");
                RowToReturn["IsDeleted"] = Row.Col<bool>("IsDeleted");

                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }

        public DataTable GetRouteCityDataTable(List<City> CityList)
        {
            var RouteCityDataTable = new DataTable();

            RouteCityDataTable.Columns.Add(new DataColumn("ID", typeof(int)));
            RouteCityDataTable.Columns.Add(new DataColumn("Label", typeof(string)));

            foreach (City city in CityList)
            {
                var RowToAdd = RouteCityDataTable.NewRow();
                RowToAdd["ID"] = city.ID;
                RowToAdd["Label"] = city.Label;

                RouteCityDataTable.Rows.Add(RowToAdd);
            }

            RouteCityDataTable.PrimaryKey = new DataColumn[] { RouteCityDataTable.Columns["ID"] };

            return RouteCityDataTable;
        }

        public List<City> GetCityList(int routeID)
        {
            var Cities = new List<City>();
            var sql = $"SELECT * FROM City WHERE ID IN (SELECT CityID FROM RouteCity WHERE RouteID = {routeID})";
            var table = Database.Query(sql);

            foreach (DataRow Row in table.Rows)
            {
                Cities.Add(MapDataRowToProperties(Row));
            }

            return Cities;
        }

        protected override string SaveLogString(City city)
        {
            return $"City Label {city.Label} to {city.Name} in {city.State}, which takes {city.Hours} hours to service its {city.Miles} miles.";
        }

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
    }
}
