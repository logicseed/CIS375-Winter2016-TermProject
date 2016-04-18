
using System;
using System.Collections.Generic;
/// <project> IceCreamManager </project>
/// <module> RouteFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
using System.Data;

namespace IceCreamManager.Model
{
    public class RouteFactory : DatabaseEntityFactory<Route>
    {
        #region Singleton
        private static readonly RouteFactory SingletonInstance = new RouteFactory();
        public static RouteFactory Reference { get { return SingletonInstance; } }
        private RouteFactory() { }
        #endregion Singleton

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
            throw new NotImplementedException();
        }

        public Route LoadByNumber(int v)
        {
            throw new NotImplementedException();
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
    }
}
