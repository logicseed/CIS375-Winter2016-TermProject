using System.Collections.Generic;

/// <project> IceCreamManager </project>
/// <module> Route </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    public class Route : DatabaseEntity
    {
        private RouteFactory routeFactory = RouteFactory.Reference;

        private int number;

        private List<City> routeCities = null;

        public Route()
        {
            ID = 0;
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < Requirement.MinRouteNumber) throw new RouteNumberInvalidException(Outcome.ValueTooSmall);
                if (value > Requirement.MaxRouteNumber) throw new RouteNumberInvalidException(Outcome.ValueTooLarge);
                number = value;
                IsSaved = false;
                ReplaceOnSave = true;
            }
        }

        public List<City> RouteCities
        {
            get
            {
                if (routeCities == null) routeCities = routeFactory.LoadCityList(ID);
                return routeCities;
            }
        }
        
    }
}
