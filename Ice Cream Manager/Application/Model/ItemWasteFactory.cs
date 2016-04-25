/// <project> IceCreamManager </project>
/// <module> ItemWasteFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;
using System.Data;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class ItemWasteFactory : DatabaseEntityFactory<ItemWaste>
    {
        #region Singleton
        private static readonly ItemWasteFactory SingletonInstance = new ItemWasteFactory();
        public static ItemWasteFactory Reference { get { return SingletonInstance; } }
        private ItemWasteFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "ItemID,RouteID,TruckID,DateExpired";

        protected override string DatabaseQueryColumnValuePairs(ItemWaste itemWaste)
            => $"ItemID = {itemWaste.ItemID},RouteID = {itemWaste.RouteID},TruckID = {itemWaste.TruckID},DateExpired = '{itemWaste.DateExpired.ToDatabase()}'";

        protected override string DatabaseQueryValues(ItemWaste itemWaste)
            => $"{itemWaste.ItemID},{itemWaste.RouteID},{itemWaste.TruckID},'{itemWaste.DateExpired.ToDatabase()}'";

        protected override ItemWaste MapDataRowToProperties(DataRow row)
        {
            ItemWaste itemWaste = new ItemWaste();

            itemWaste.ID = row.Col("ID");
            itemWaste.ItemID = row.Col("ItemID");
            itemWaste.RouteID = row.Col("RouteID");
            itemWaste.TruckID = row.Col("TruckID");
            itemWaste.DateExpired = row.Col<DateTime>("DateExpired");
            itemWaste.InDatabase = true;
            itemWaste.IsSaved = true;

            return itemWaste;
        }

        internal double GetItemWaste(RevenueCriteria criteria, DateTime workingDate)
        {
            var sql = "SELECT Sum(Item.Price) FROM ItemWaste";
            sql += " INNER JOIN Item ON Item.ID = ItemWaste.ItemID ";
            sql += $"WHERE ItemWaste.DateExpired < '{workingDate.AddDays(1).Date.ToDatabase()}' AND ItemWaste.DateExpired >= '{workingDate.Date.ToDatabase()}' ";

            if (criteria.ItemNumber != 0) sql += $"AND ItemWaste.ItemID IN (SELECT ID FROM Item WHERE Number = {criteria.ItemNumber}) ";
            if (criteria.TruckNumber != 0) sql += $"AND ItemWaste.TruckID IN (SELECT ID FROM Truck WHERE Number = {criteria.TruckNumber}) ";
            if (criteria.DriverNumber != 0) sql += $"AND ItemWaste.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Driver ON Driver.ID = Truck.DriverID WHERE Driver.Number = {criteria.DriverNumber}) ";
            if (criteria.RouteNumber != 0) sql += $"AND ItemWaste.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID WHERE Route.Number = {criteria.RouteNumber}) ";
            if (criteria.CityLabel != "All") sql += $"AND ItemWaste.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID INNER JOIN RouteCity ON RouteCity.RouteID = Route.ID INNER JOIN City ON City.ID = RouteCity.CityID WHERE City.Label = '{criteria.CityLabel}') ";

            var table = Database.Query(sql);
            if (table.Rows.Count == 0) return 0.0;
            return table.Row().Col<double>();
        }


        protected override string SaveLogString(ItemWaste entity)
        {
            throw new NotImplementedException();
        }

        internal void WasteMany(int itemID, int truckID, int quantity)
        {
            var sql = $"INSERT INTO ItemWaste (ItemID, TruckID, DateExpired) VALUES ";
            for (int i = 0; i < quantity; i++)
            {
                sql += $"({itemID},{truckID},'{DateTime.Now.ToDatabase()}'),";
            }
            sql = sql.TrimEnd(',');

            Database.NonQuery(sql);
            Log.Success($"Wasted {quantity} {Factory.Item.GetNameByID(itemID)} from truck number {Factory.Truck.GetNumberByID(truckID)}.");

        }
    }
}
