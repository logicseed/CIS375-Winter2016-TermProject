﻿/// <project> IceCreamManager </project>
/// <module> CityFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System;
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

        protected override string DatabaseQueryColumns()
            => "Label,Name,State,Miles,Hours,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(City city)
            => $"Label = '{city.Label}',Name = '{city.Name}',State = '{city.State}',Miles = {city.Miles},Hours = {city.Hours},IsDeleted = {city.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(City city)
            => $"'{city.Label}','{city.Name}','{city.State}',{city.Miles},{city.Hours},{city.IsDeleted.ToDatabase()}";

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

            if (Database.ExecuteCommand(DatabaseCommand) > 0) return true;
            else return false;
        }

        public bool Exists(string cityLabel, bool isDeleted)
        {
            string DatabaseCommand = $"SELECT 1 FROM {TableName} WHERE Label = '{cityLabel}' AND IsDeleted = {isDeleted.ToDatabase()}";

            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

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

            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            if (ResultsTable.Rows.Count == 0) return 0;

            return ResultsTable.Row().Col("ID");
        }
    }
}
