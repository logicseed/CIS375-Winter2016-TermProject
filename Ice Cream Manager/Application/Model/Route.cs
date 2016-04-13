using System.Collections.Generic;

/// <project> IceCreamManager </project>
/// <module> Route </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System.Data;

namespace IceCreamManager.Model
{
    public class RouteProperties : DatabaseEntityProperties
    {
        public int Number;
        public Dictionary<int, City> RouteCities;
    }

    public class Route : DatabaseEntity
    {
        private RouteProperties RouteValues = new RouteProperties();

        public Route()
        {
            ID = 0;
        }

        public Route(int ID)
        {
            Load(ID);
        }

        public int Number
        {
            get
            {
                return RouteValues.Number;
            }

            set
            {
                if (value < Requirement.MinNumber) throw new RouteNumberInvalidException(Outcome.ValueTooSmall);
                else if (value > Requirement.MaxNumber) throw new RouteNumberInvalidException(Outcome.ValueTooLarge);
                RouteValues.Number = value;
                DeleteOnSave = true;
            }
        }

        public Dictionary<int, City> RouteCities
        {
            get
            {
                return RouteValues.RouteCities;
            }

            protected set
            {
                RouteValues.RouteCities = value;
                DeleteOnSave = true;
            }
        }

        protected override string TableName => "route";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (number) VALUES ({Number}) WHERE id = {ID}";

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (number) VALUES ({Number})";

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            RouteValues = (RouteProperties)EntityProperties;

            return true;
        }

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("number");
            IsDeleted = ResultsTable.Row().Col<bool>("deleted");

            // Load Cities
            ResultsTable = Database.DataTableFromCommand($"SELECT city_id FROM route_city WHERE route_id = {ID}");

            foreach (DataRow Row in ResultsTable.Rows)
            {
                int CityID = Row.Col("id");
                RouteCities.Add(CityID, CityFactory.Load(CityID));
            }

            return true;
        }

        public bool AddCity(City NewCity)
        {
            if (RouteCities.Count == 10) throw new RouteCityCountException(Outcome.TooManyCities);
            RouteCities.Add(NewCity.ID, NewCity);
            DeleteOnSave = true;
            return true;
        }

        public override bool Save()
        {
            SaveCities();
            SaveRouteCities();

            if (InDatabase && DeleteOnSave)
            {
                Delete();
            }
            else if (InDatabase && !DeleteOnSave)
            {
                Update();
            }
            else if (!InDatabase)
            {
                Create();
            }

            return InDatabase;
        }

        private void SaveCities()
        {
            foreach (KeyValuePair<int, City> CityToSave in RouteCities)
            {
                CityToSave.Value.Save();
            }
        }

        private void SaveRouteCities()
        {
            foreach (KeyValuePair<int, City> CityInRoute in RouteCities)
            {
                DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM route_city WHERE route_id = {ID} AND city_id = {CityInRoute.Key}");

                if (ResultsTable.Rows.Count == 0)
                {
                    Database.ExecuteCommand($"INSERT INTO route_city (route_id,city_id) VALUES ({ID},{CityInRoute.Key}");
                }
                else if (ResultsTable.Row().Col<bool>("deleted"))
                {
                    Database.ExecuteCommand($"UPDATE route_city SET (deleted) VALUES (0) WHERE id = {ResultsTable.Row().Col("id")}");
                }
            }
        }
    }
}
