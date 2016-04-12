/// <project> IceCreamManager </project>
/// <module> RouteFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    public static class RouteFactory
    {
        private static DatabaseEntityFactory<Route> DatabaseRouteFactory = new DatabaseEntityFactory<Route>();
        private static DatabaseManager Database = DatabaseManager.Reference;

        public static Route Load(int ID)
        {
            return DatabaseRouteFactory.Load(ID);
        }

        public static Route Create(RouteProperties EntityProperties)
        {
            return DatabaseRouteFactory.Create(EntityProperties);
        }

        public static Route LoadTruckRoute(int truckID)
        {
            Route RouteToAdd = null;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT RouteID FROM TruckRoute WHERE TruckID = {truckID} AND IsDeleted = 0");
            if (ResultsTable.Rows.Count != 0)
            {
                RouteToAdd = Load(ResultsTable.Row().Col("RouteID"));
            }

            return RouteToAdd;
        }
    }
}
