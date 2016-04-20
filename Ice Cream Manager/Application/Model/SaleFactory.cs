/// <project> IceCreamManager </project>
/// <module> SaleFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override string SaveLogString(Sale entity)
        {
            throw new NotImplementedException();
        }
    }
}
