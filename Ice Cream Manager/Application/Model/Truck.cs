
using System;
/// <project> IceCreamManager </project>
/// <module> Truck </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
using System.Collections.Generic;
using System.Data;

namespace IceCreamManager.Model
{
    /// <summary>
    ///   Contains the properties of a Truck. 
    /// </summary>
    /// <remarks>
    ///   A class was chosen over struct because of how struct will be boxed when passing as the implemented type.
    /// </remarks>
    public class TruckProperties : DatabaseEntityProperties
    {
        public int Number;
        public double FuelRate;
        public List<InventoryItem> Inventory = null;
        public int RouteID = 0;
        public Route Route = null;
        public int DriverID = 0;
        public Driver Driver = null;
    }

    /// <summary>
    ///   Represents a complete ice cream truck with inventory, driver, and route. 
    /// </summary>
    public class Truck : DatabaseEntity
    {
        private TruckProperties TruckValues = new TruckProperties();

        /// <summary>
        ///   User provided number to distinguish the Truck. Changing this value marks a truck to be deleted. 
        /// </summary>
        public int Number
        {
            get
            {
                return TruckValues.Number;
            }

            set
            {
                TruckValues.Number = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The amount of currency this Truck spends on fuel per mile. Changing this value marks a truck to be deleted. 
        /// </summary>
        public double FuelRate
        {
            get
            {
                return TruckValues.FuelRate;
            }

            set
            {
                TruckValues.FuelRate = value;
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   A collection of InventoryItems that represent this Truck's inventory. 
        /// </summary>
        public List<InventoryItem> Inventory
        {
            get
            {
                // lazy loading
                if (TruckValues.Inventory == null)
                {
                    TruckValues.Inventory = InventoryItemFactory.LoadInventory(ID);
                }
                return TruckValues.Inventory;
            }

            protected set
            { }
        }

        /// <summary>
        ///   The unique identity of the Route assigned to this Truck. 
        /// </summary>
        public int RouteID
        {
            get
            {
                // lazy loading
                if (TruckValues.RouteID == 0)
                {
                    TruckValues.RouteID = Route.ID;
                }
                return TruckValues.RouteID;
            }
            set
            {
                TruckValues.RouteID = value;
                if (value != 0 && value != TruckValues.Route.ID)
                {
                    TruckValues.Route = RouteFactory.Load(value);
                }
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   A reference to this truck's Route in memory. 
        /// </summary>
        public Route Route
        {
            get
            {
                // lazy loading
                if (TruckValues.Route == null)
                {
                    TruckValues.Route = RouteFactory.LoadTruckRoute(ID);
                }
                return TruckValues.Route;
            }

            set
            {
                TruckValues.Route = value;
                if (value.ID != TruckValues.RouteID)
                {
                    TruckValues.RouteID = value.ID;
                }
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The unique identity of the Driver assigned to this truck. 
        /// </summary>
        public int DriverID
        {
            get
            {
                // lazy loading
                if (TruckValues.DriverID == 0)
                {
                    TruckValues.DriverID = Driver.ID;
                }
                return TruckValues.DriverID;
            }
            set
            {
                TruckValues.DriverID = value;
                if (value != 0 && value != TruckValues.Driver.ID)
                {
                    TruckValues.Driver = DriverFactory.Load(value);
                }
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   A reference to this truck's Driver in memory. 
        /// </summary>
        public Driver Driver
        {
            get
            {
                // lazy loading
                if (TruckValues.Driver == null)
                {
                    TruckValues.Driver = DriverFactory.LoadTruckDriver(ID);
                }
                return TruckValues.Driver;
            }
            set
            {
                TruckValues.Driver = value;
                if (value.ID != TruckValues.DriverID)
                {
                    TruckValues.DriverID = value.ID;
                }
                IsSaved = false;
                DeleteOnSave = true;
            }
        }

        /// <summary>
        ///   The SQL command used to create a truck in the database with this object's properties. 
        /// </summary>
        protected override string CreateCommand =>
            $"INSERT INTO {TableName} (Number,FuelRate) VALUES ({Number},{FuelRate})";

        /// <summary>
        ///   The name of the database table that stores trucks. 
        /// </summary>
        protected override string TableName => "Truck";

        /// <summary>
        ///   The SQL command used to update a truck in the database with this object's properties. 
        /// </summary>
        protected override string UpdateCommand =>
            $"UPDATE {TableName} SET (Number,FuelRate) VALUES ({Number},{FuelRate})";

        /// <summary>
        ///   Fills this truck's properties with values. 
        /// </summary>
        /// <param name="EntityProperties"> A DatabaseEntityProperties object with the values to use. </param>
        /// <returns> Whether or not the truck was successfully filled with the values. </returns>
        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            TruckValues = (TruckProperties)EntityProperties;

            return true;
        }

        /// <summary>
        ///   Load a Truck from the database based on the provided identity. 
        /// </summary>
        /// <param name="ID"> The unique Truck identity. </param>
        /// <returns> Whether or not the Truck was successfully loaded. </returns>
        public override bool Load(int ID)
        {
            this.ID = ID;
            DataTable ResultsTable = Database.DataTableFromCommand($"SELECT * FROM {TableName} WHERE ID = {ID}");

            if (ResultsTable.Rows.Count == 0) return false;

            Number = ResultsTable.Row().Col("Number");
            FuelRate = ResultsTable.Row().Col<double>("FuelRate");
            IsDeleted = ResultsTable.Row().Col<bool>("IsDeleted");

            return true;
        }

        /// <summary>
        /// Saves the Truck to the database.
        /// </summary>
        /// <returns>Whether or not the Truck was saved successfully.</returns>
        public override bool Save()
        {
            // Delete on save update all items before saving them
            bool UpdateInventoryItems = false;
            if (InDatabase && DeleteOnSave)
            {
                Delete();
                UpdateInventoryItems = true;
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
            SaveInventory(UpdateInventoryItems);

            return InDatabase;
        }

        /// <summary>
        /// Saves all the InventoryItems in the Inventory of this Truck.
        /// </summary>
        /// <param name="updateInventoryItems">Whether or not the InventoryItems should be updated to match a changed Truck ID.</param>
        private void SaveInventory(bool updateInventoryItems)
        {
            foreach (InventoryItem InventoryItemToSave in Inventory)
            {
                if (updateInventoryItems) InventoryItemToSave.TruckID = ID;
                InventoryItemToSave.Save();
            }
        }

        public bool AddItem(int ItemID, int Quantity)
        {
            for (int Index = 0; Index < Quantity; Index++)
            {
                InventoryItemProperties InventoryItemValues = new InventoryItemProperties();
                InventoryItemValues.InventoryID = ID;
                InventoryItemValues.ItemType = ItemFactory.Load(ItemID);
                InventoryItemValues.DateCreated = DateTime.Now;

                InventoryItem ItemToAdd = InventoryItemFactory.Create(InventoryItemValues);
                Items.Add(ItemToAdd);
            }

            return true;
        }

        public bool AddItem(int ItemID)
        {
            return AddItem(ItemID, 1);
        }

        public bool RemoveItem(int ItemID, int Quantity)
        {
            for (int Index = 0; Index < Quantity; Index++)
            {
                InventoryItem ItemToRemove = Items.Find(InventoryItem => InventoryItem.ItemType.ID == ItemID);
                Items.Remove(ItemToRemove);
                ItemToRemove.RemoveFromInventory();
            }

            return true;
        }

        public bool RemoveItem(int ItemID)
        {
            return RemoveItem(ItemID, 1);
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
