
using System;
using System.Collections.Generic;
using System.Data;
/// <project> IceCreamManager </project>
/// <module> TruckFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>
namespace IceCreamManager.Model
{
    public class TruckFactory : DatabaseEntityFactory<Truck>
    {
        #region Singleton
        private static readonly TruckFactory SingletonInstance = new TruckFactory();
        public static TruckFactory Reference { get { return SingletonInstance; } }
        private TruckFactory() { }
        #endregion Singleton

        private LanguageManager Language = LanguageManager.Reference;

        protected override string DatabaseQueryColumns()
            => "Number,RouteID,DriverID,FuelRate,IsDeleted";

        protected override string DatabaseQueryColumnValuePairs(Truck truck)
            => $"Number = {truck.Number},RouteID = {truck.RouteID},DriverID = {truck.DriverID},FuelRate = {truck.FuelRate},IsDeleted = {truck.IsDeleted.ToDatabase()}";

        protected override string DatabaseQueryValues(Truck truck)
            => $"{truck.Number},{truck.RouteID},{truck.DriverID},{truck.FuelRate},{truck.IsDeleted.ToDatabase()}";

        protected override Truck MapDataRowToProperties(DataRow row)
        {
            Truck truck = new Truck();

            truck.ID = row.Col("ID");
            truck.Number = row.Col("Number");
            truck.RouteID = row.Col("RouteID");
            truck.DriverID = row.Col("DriverID");
            truck.FuelRate = row.Col<double>("FuelRate");
            truck.IsDeleted = row.Col<bool>("IsDeleted");
            truck.InDatabase = true;
            truck.IsSaved = true;

            return truck;
        }

        public List<InventoryItem> LoadInventoryList(int truckID)
        {
            throw new NotImplementedException();
        }

        public Route LoadTruckRoute(int routeID)
        {
            throw new NotImplementedException();
        }

        internal Driver LoadTruckDriver(int driverID)
        {
            throw new NotImplementedException();
        }

        protected override string SaveLogString(Truck truck)
        {
            var LogString = $"Truck {truck.Number} with items";
            return LogString;
        }

        public override DataTable GetDataTable(bool includeDeleted)
        {
            var TableFromDatabase = GetAllDataTable(includeDeleted);
            var TableToReturn = new DataTable();

            TableToReturn.Columns.Add(new DataColumn("ID", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Number", typeof(int)));
            TableToReturn.Columns.Add(new DataColumn("Driver", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Route", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("FuelRate", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("Items", typeof(string)));
            TableToReturn.Columns.Add(new DataColumn("IsDeleted", typeof(bool)));

            foreach (DataRow Row in TableFromDatabase.Rows)
            {
                DataRow RowToReturn = TableToReturn.NewRow();

                RowToReturn["ID"] = Row.Col("ID");
                RowToReturn["Number"] = Row.Col("Number");
                RowToReturn["FuelRate"] = Row.Col<double>("FuelRate");
                RowToReturn["IsDeleted"] = Row.Col<bool>("IsDeleted");

                if (Row.Col("DriverID") != 0) RowToReturn["Driver"] = Factory.Driver.GetNameByID(Row.Col("DriverID"));
                else RowToReturn["Driver"] = Language["NA"];

                if (Row.Col("RouteID") != 0) RowToReturn["Route"] = Factory.Route.GetNumberByID(Row.Col("RouteID"));
                else RowToReturn["Route"] = Language["NA"];

                var ItemsColumn = "";
                var TruckItemList = Factory.InventoryItem.GetTruckItemListByID(Row.Col("ID"));
                foreach (KeyValuePair<Item, int> pair in TruckItemList)
                {
                    ItemsColumn += $"{pair.Key.Description} ({pair.Value}), ";
                }
                if (ItemsColumn.Length > 0) ItemsColumn = ItemsColumn.Substring(0, ItemsColumn.Length - 2);
                RowToReturn["Items"] = ItemsColumn.Trim() == "" ? Language["Empty"] : ItemsColumn;

                

                TableToReturn.Rows.Add(RowToReturn);
            }

            return TableToReturn;
        }
    }
}
