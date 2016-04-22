
using System;
using System.Collections.Generic;
/// <project> IceCreamManager </project>
/// <module> RouteFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
using System.Data;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class RouteFactory : DatabaseEntityFactory<Route>
    {
        #region Singleton
        private static readonly RouteFactory SingletonInstance = new RouteFactory();
        public static RouteFactory Reference { get { return SingletonInstance; } }
        private RouteFactory() { }
        #endregion Singleton

        protected int OldRouteID;
        protected override string TableName => "Route";

        protected override string DatabaseQueryColumns()
            => "Number,IsDeleted";

        protected override string DatabaseQueryValues(Route route)
            => $"{route.Number},{route.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryColumnValuePairs(Route route)
            => $"{route.Number},{route.IsDeleted.ToDatabase()}";

        protected override Route MapDataRowToProperties(DataRow row)
        {
            Route route = new Route();

            route.ID = row.Col("ID");
            route.Number = row.Col("Number");
            route.IsDeleted = row.Col<bool>("IsDeleted");
            route.InDatabase = true;
            route.IsSaved = true;

            return route;
        }

        public List<City> LoadCityList(int routeID)
        {
            return Factory.City.GetCityList(routeID);
        }

        public override DataTable GetDataTable(bool includeDeleted)
        {
            var TableFromDatabase = GetAllDataTable(includeDeleted);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Number", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Cities", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["Number"] = Row.Col("Number");

                string CitiesColumn = "";
                foreach (City city in  Factory.City.GetCityList(Row.Col("ID")))
                {
                    CitiesColumn += city.Label + ", ";
                }
                if (CitiesColumn.Length > 0) CitiesColumn = CitiesColumn.Substring(0, CitiesColumn.Length - 2);
                RowToReturn["Cities"] = CitiesColumn;
                RowToReturn["IsDeleted"] = Row.Col<bool>("IsDeleted");



                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }

        protected override string SaveLogString(Route route)
        {
            var LogString = $"Route {route.Number} with ";
            foreach (City city in route.Cities)
            {
                LogString += $" {city.Label},"; 
            }
            LogString.TrimEnd(',');
            return LogString;
        }

        public bool HasCity(Route route, string label)
        {
            var sql = $"SELECT * FROM City WHERE ID IN (SELECT CityID FROM RouteCity WHERE RouteID = {route.ID} AND IsDeleted = 0) AND Label = '{label}'";
            var table = Database.Query(sql);
            return (table.Rows.Count > 0);
        }

        public bool HasCity(Route route, City city, bool deleted = false)
        {
            var sql = $"SELECT * FROM RouteCity WHERE CityID = {city.ID} AND RouteID = {route.ID} AND IsDeleted = {deleted.ToDatabase()}";
            var table = Database.Query(sql);
            return (table.Rows.Count > 0);
        }

        protected override bool SaveChildren(Route route)
        {
            if (OldRouteID == route.ID) return true;
            if (!RemoveOldCities(route)) return false;
            if (!AddNewCities(route)) return false;
            return true;
        }

        private bool AddNewCities(Route route)
        {
            foreach (City city in route.Cities)
            {
                city.Save();
                if (!AddCity(route, city)) return false;
            }
            return true;
        }

        private bool RemoveOldCities(Route route)
        {
            var sql = $"UPDATE RouteCity SET IsDeleted = 1 WHERE RouteID = {OldRouteID}";

            if (Database.NonQuery(sql) > 0 || OldRouteID == 0)
            {
                return true;
            }
            else return false;
        }

        protected bool AddCity(Route route, City city)
        {
            var sql = $"INSERT INTO RouteCity (RouteID,CityID,IsDeleted) VALUES ({route.ID},{city.ID},0)";

            if (Database.NonQuery(sql) > 0)
            {
                return true;
            }
            else return false;
        }

        public override bool Save(Route route)
        {
            if (route.IsSaving || route.IsSaved) return true;
            else route.IsSaving = true;
            OldRouteID = route.ID;

            if (route.InDatabase && route.ReplaceOnSave)
            {
                route.IsSaved = Replace(route); // Changes that result in deletion
            }
            else if (route.InDatabase && !route.ReplaceOnSave)
            {
                route.IsSaved = Update(route); // Changes that don't result in deletion
            }
            else if (!route.InDatabase)
            {
                route.IsSaved = Create(route); // New entity
            }
            return (route.IsSaved && SaveChildren(route));
        }

        public void RemoveRoute(int routeID)
        {
            var sql = $"UPDATE Route SET IsDeleted = 1 WHERE ID = {routeID}";
            Database.NonQuery(sql);
            sql = $"UPDATE RouteCity SET IsDeleted = 1 WHERE RouteID = {routeID}";
            Database.NonQuery(sql);
        }
    }
}
