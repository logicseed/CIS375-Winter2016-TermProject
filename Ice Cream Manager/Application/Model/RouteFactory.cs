/// <project> IceCreamManager </project>
/// <module> RouteFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

namespace IceCreamManager.Model
{
    public static class RouteFactory
    {
        private static DatabaseEntityFactory<Route> DatabaseRouteFactory = new DatabaseEntityFactory<Route>();

        public static Route Load(int ID)
        {
            return DatabaseRouteFactory.Load(ID);
        }

        public static Route Create(RouteProperties EntityProperties)
        {
            return DatabaseRouteFactory.Create(EntityProperties);
        }
    }
}
