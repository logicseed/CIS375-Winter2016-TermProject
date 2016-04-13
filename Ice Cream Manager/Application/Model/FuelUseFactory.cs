/// <project> IceCreamManager </project>
/// <module> FuelUseFactory </module>
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
    public class FuelUseFactory : DatabaseEntityFactory<FuelUse>
    {
        #region Singleton
        private static readonly FuelUseFactory SingletonInstance = new FuelUseFactory();
        public static FuelUseFactory Reference { get { return SingletonInstance; } }
        private FuelUseFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "RouteID,TruckID,DateUsed";

        protected override string DatabaseQueryColumnValuePairs(FuelUse entity)
            => $"RouteID = {entity.RouteID},TruckID = {entity.TruckID},DateUsed = '{entity.DateUsed.ToDatabase()}'";

        protected override string DatabaseQueryValues(FuelUse entity)
            => $"{entity.RouteID},{entity.TruckID},'{entity.DateUsed.ToDatabase()}'";

        protected override FuelUse MapDataRowToProperties(DataRow row)
        {
            FuelUse fuelUse = new FuelUse();

            fuelUse.ID = row.Col("ID");
            fuelUse.RouteID = row.Col("RouteID");
            fuelUse.TruckID = row.Col("TruckID");
            fuelUse.DateUsed = row.Col<DateTime>("DateUsed");
            fuelUse.InDatabase = true;
            fuelUse.IsSaved = true;

            return fuelUse;
        }
    }
}
