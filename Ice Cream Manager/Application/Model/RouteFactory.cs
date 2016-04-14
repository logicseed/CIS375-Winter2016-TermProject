
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
    }
}
