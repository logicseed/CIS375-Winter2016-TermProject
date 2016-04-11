/// <project> IceCreamManager </project>
/// <module> Truck </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
using System.Data;

namespace IceCreamManager.Model
{
    public class TruckProperties : DatabaseEntityProperties
    {
        public int Number;
        public double FuelRate;
        public Inventory Inventory;
        public Route Route;
        public Driver Driver;
    }

    public class Truck : DatabaseEntity
    {
        private TruckProperties TruckValues = new TruckProperties();

        public int Number
        {
            get
            {
                return TruckValues.Number;
            }

            set
            {
                TruckValues.Number = value;
                DeleteOnSave = true;
            }
        }

        public double FuelRate
        {
            get
            {
                return TruckValues.FuelRate;
            }

            set
            {
                TruckValues.FuelRate = value;
                DeleteOnSave = true;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return TruckValues.Inventory;
            }

            set
            {
                TruckValues.Inventory = value;
            }
        }

        public Route Route
        {
            get
            {
                return TruckValues.Route;
            }

            set
            {
                TruckValues.Route = value;
            }
        }

        public Driver Driver
        {
            get
            {
                return TruckValues.Driver;
            }

            set
            {
                TruckValues.Driver = value;
            }
        }

        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (number,fuel_rate,inventory_id) VALUES ({Number},{FuelRate},{Inventory.ID})";

        protected override string TableName => "truck";

        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (number,fuel_rate,inventory_id) VALUES ({Number},{FuelRate},{Inventory.ID})";

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            TruckValues = (TruckProperties)EntityProperties;

            return true;
        }

        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE id = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("number");
            FuelRate = ResultsTable.Row().Col<double>("fuel_rate");
            IsDeleted = ResultsTable.Row().Col<bool>("deleted");

            Inventory = InventoryFactory.Load(ResultsTable.Row().Col("inventory_id"));

            // Load route
            ResultsTable = Database.DataTableFromCommand($"SELECT route_id FROM truck_route WHERE truck_id = {ID} AND deleted = 0");
            if (ResultsTable.Rows.Count != 0)
            {
                Route = RouteFactory.Load(ResultsTable.Row().Col("route_id"));
            }

            // Load driver
            ResultsTable = Database.DataTableFromCommand($"SELECT driver_id FROM truck_driver WHERE truck_id = {ID} AND deleted = 0");
            if (ResultsTable.Rows.Count != 0)
            {
                Driver = DriverFactory.Load(ResultsTable.Row().Col("driver_id"));
            }

            return true;
        }

        public override bool Save()
        {
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

            SaveRoute();
            SaveDriver();

            return InDatabase;
        }

        private void SaveRoute()
        {
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM truck_route WHERE truck_id = {ID} AND route_id = {Route.ID}");

            if (ResultsTable.Rows.Count == 0)
            {
                Database.ExecuteCommand($"INSERT INTO truck_route (truck_id,route_id) VALUES ({ID},{Route.ID})");
            }
            else if (ResultsTable.Row().Col<bool>("deleted"))
            {
                int DeletedTruckRouteID = ResultsTable.Row().Col("id");
                Database.ExecuteCommand($"UPDATE truck_route SET (deleted) VALUES (0) WHERE id = {DeletedTruckRouteID}");
            }
        }

        private void SaveDriver()
        {
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM truck_driver WHERE truck_id = {ID} AND driver_id = {Driver.ID}");

            if (ResultsTable.Rows.Count == 0)
            {
                Database.ExecuteCommand($"INSERT INTO truck_driver (truck_id,driver_id) VALUES ({ID},{Driver.ID})");
            }
            else if (ResultsTable.Row().Col<bool>("deleted"))
            {
                int DeletedTruckDriverID = ResultsTable.Row().Col("id");
                Database.ExecuteCommand($"UPDATE truck_driver SET (deleted) VALUES (0) WHERE id = {DeletedTruckDriverID}");
            }
        }
    }
}
