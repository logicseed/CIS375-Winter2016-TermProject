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

    internal class Route : DatabaseEntity
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

            //if (ResultsTable.Rows.Count == 0) return false;

            //Label = ResultsTable.Row().Col<string>("label");
            //Name = ResultsTable.Row().Col<string>("name");
            //State = ResultsTable.Row().Col<string>("state");
            //FuelCost = ResultsTable.Row().Col<double>("fuel_cost");
            //HourCost = ResultsTable.Row().Col<double>("hour_cost");

            return true;
        }
    }
}
