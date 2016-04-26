/// <project> IceCreamManager </project>
/// <module> SaleFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;
using System.Data;
using IceCreamManager.Controller;

namespace IceCreamManager.Model
{
    public class SaleFactory : DatabaseEntityFactory<Sale>
    {
        #region Singleton
        private static readonly SaleFactory SingletonInstance = new SaleFactory();
        public static SaleFactory Reference { get { return SingletonInstance; } }
        private SaleFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "ItemID,TruckID,RouteID,DriverID,DateSold";

        protected override string DatabaseQueryColumnValuePairs(Sale sale)
            => $"ItemID = {sale.ItemID},TruckID = {sale.TruckID},RouteID = {sale.RouteID},DriverID = {sale.DriverID},DateSold = '{sale.DateSold.ToDatabase()}'";

        protected override string DatabaseQueryValues(Sale sale)
            => $"{sale.ItemID},{sale.TruckID},{sale.RouteID},{sale.DriverID},{sale.DateSold.ToDatabase()}";

        protected override Sale MapDataRowToProperties(DataRow row)
        {
            Sale sale = new Sale();

            sale.ID = row.Col("ID");
            sale.ItemID = row.Col("ItemID");
            sale.TruckID = row.Col("TruckID");
            sale.RouteID = row.Col("RouteID");
            sale.DriverID = row.Col("DriverID");
            sale.DateSold = row.Col<DateTime>("DateSold");
            sale.InDatabase = true;
            sale.IsSaved = true;

            return sale;
        }

        internal double GetSales(RevenueCriteria criteria, DateTime workingDate)
        {
            var sql = "SELECT Sum(Item.Price) FROM Sale";
            sql += " INNER JOIN Item ON Item.ID = Sale.ItemID ";
            sql += $"WHERE Sale.DateSold < '{workingDate.AddDays(1).Date.ToDatabase()}' AND Sale.DateSold >= '{workingDate.Date.ToDatabase()}' ";

            if (criteria.ItemNumber != 0) sql += $"AND Sale.ItemID IN (SELECT ID FROM Item WHERE Number = {criteria.ItemNumber}) ";
            if (criteria.TruckNumber != 0) sql += $"AND Sale.TruckID IN (SELECT ID FROM Truck WHERE Number = {criteria.TruckNumber}) ";
            if (criteria.DriverNumber != 0) sql += $"AND Sale.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Driver ON Driver.ID = Truck.DriverID WHERE Driver.Number = {criteria.DriverNumber}) ";
            if (criteria.RouteNumber != 0) sql += $"AND Sale.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID WHERE Route.Number = {criteria.RouteNumber}) ";
            if (criteria.CityLabel != "All") sql += $"AND Sale.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID INNER JOIN RouteCity ON RouteCity.RouteID = Route.ID INNER JOIN City ON City.ID = RouteCity.CityID WHERE City.Label = '{criteria.CityLabel}') ";

            var table = Database.Query(sql);
            if (table.Rows.Count == 0) return 0.0;
            return table.Row().Col<double>();
        }

        protected override string SaveLogString(Sale entity)
        {
            throw new NotImplementedException();
        }

        public void SellMany(int itemID, int truckID, int quantity)
        {
            var sql = $"INSERT INTO Sale (ItemID, TruckID, DateSold) VALUES ";
            for (int i = 0; i < quantity; i++)
            {
                sql += $"({itemID},{truckID},'{DateTime.Now.ToDatabase()}'),";
            }
            sql = sql.TrimEnd(',');

            Database.NonQuery(sql);
            Log.Success($"Sold {quantity} {Factory.Item.GetNameByID(itemID)} from truck number {Factory.Truck.GetNumberByID(truckID)}.");

        }
    }
}
