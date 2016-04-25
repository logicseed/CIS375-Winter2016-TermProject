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
            => "TruckID,DateUsed";

        protected override string DatabaseQueryColumnValuePairs(FuelUse fuelUse)
            => $"TruckID = {fuelUse.TruckID},DateUsed = '{fuelUse.DateUsed.ToDatabase()}'";

        protected override string DatabaseQueryValues(FuelUse fuelUse)
            => $"{fuelUse.TruckID},'{fuelUse.DateUsed.ToDatabase()}'";

        protected override FuelUse MapDataRowToProperties(DataRow row)
        {
            FuelUse fuelUse = new FuelUse();

            fuelUse.ID = row.Col("ID");
            fuelUse.TruckID = row.Col("TruckID");
            fuelUse.DateUsed = row.Col<DateTime>("DateUsed");
            fuelUse.InDatabase = true;
            fuelUse.IsSaved = true;

            return fuelUse;
        }

        internal double GetFuelUse(RevenueCriteria criteria, DateTime workingDate)
        {
            var sql = "SELECT Sum(Truck.FuelRate * City.Miles) FROM FuelUse ";
            sql += "INNER JOIN Truck ON Truck.ID = FuelUse.TruckID ";
            sql += "INNER JOIN Route ON Route.ID = Truck.RouteID ";
            sql += "INNER JOIN RouteCity ON RouteCity.RouteID = Route.ID ";
            sql += "INNER JOIN City ON City.ID = RouteCity.CityID ";
            sql += $"WHERE FuelUse.DateUsed < '{workingDate.AddDays(1).Date.ToDatabase()}' AND FuelUse.DateUsed >= '{workingDate.Date.ToDatabase()}' ";

            if (criteria.TruckNumber != 0) sql += $"AND FuelUse.TruckID IN (SELECT ID FROM Truck WHERE Number = {criteria.TruckNumber}) ";
            if (criteria.DriverNumber != 0) sql += $"AND FuelUse.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Driver ON Driver.ID = Truck.DriverID WHERE Driver.Number = {criteria.DriverNumber}) ";
            if (criteria.RouteNumber != 0) sql += $"AND FuelUse.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID WHERE Route.Number = {criteria.RouteNumber}) ";
            if (criteria.CityLabel != "All") sql += $"AND FuelUse.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID INNER JOIN RouteCity ON RouteCity.RouteID = Route.ID INNER JOIN City ON City.ID = RouteCity.CityID WHERE City.Label = '{criteria.CityLabel}') ";

            var table = Database.Query(sql);
            if (table.Rows.Count == 0) return 0.0;
            return table.Row().Col<double>();
        }

        protected override string SaveLogString(FuelUse entity)
        {
            return "Fuel Use";
        }
    }
}
