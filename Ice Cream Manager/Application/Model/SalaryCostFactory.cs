/// <project> IceCreamManager </project>
/// <module> SalaryCostFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class SalaryCostFactory : DatabaseEntityFactory<SalaryCost>
    {
        #region Singleton
        private static readonly SalaryCostFactory SingletonInstance = new SalaryCostFactory();
        public static SalaryCostFactory Reference { get { return SingletonInstance; } }
        private SalaryCostFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "TruckID,DateWorked";

        protected override string DatabaseQueryColumnValuePairs(SalaryCost salaryCost)
            => $"TruckID = {salaryCost.TruckID},DateWorked = '{salaryCost.DateWorked.ToDatabase()}'";

        protected override string DatabaseQueryValues(SalaryCost salaryCost)
            => $"{salaryCost.TruckID},'{salaryCost.DateWorked.ToDatabase()}'";

        protected override SalaryCost MapDataRowToProperties(DataRow row)
        {
            SalaryCost salaryCost = new SalaryCost();

            salaryCost.ID = row.Col("ID");
            salaryCost.TruckID = row.Col("TruckID");
            salaryCost.DateWorked = row.Col<DateTime>("DateWorked");
            salaryCost.InDatabase = true;
            salaryCost.IsSaved = true;

            return salaryCost;
        }

        internal double GetSalaryCost(RevenueCriteria criteria, DateTime workingDate)
        {
            var sql = "SELECT Sum(Driver.HourlyRate * City.Hours) FROM SalaryCost ";
            sql += "INNER JOIN Truck ON Truck.ID = SalaryCost.TruckID ";
            sql += "INNER JOIN Route ON Route.ID = Truck.RouteID ";
            sql += "INNER JOIN RouteCity ON RouteCity.RouteID = Route.ID ";
            sql += "INNER JOIN City ON City.ID = RouteCity.CityID ";
            sql += "INNER JOIN Driver ON Driver.ID = Truck.DriverID ";
            sql += $"WHERE SalaryCost.DateWorked < '{workingDate.AddDays(1).Date.ToDatabase()}' AND SalaryCost.DateWorked >= '{workingDate.Date.ToDatabase()}' ";

            if (criteria.TruckNumber != 0) sql += $"AND SalaryCost.TruckID IN (SELECT ID FROM Truck WHERE Number = {criteria.TruckNumber}) ";
            if (criteria.DriverNumber != 0) sql += $"AND SalaryCost.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Driver ON Driver.ID = Truck.DriverID WHERE Driver.Number = {criteria.DriverNumber}) ";
            if (criteria.RouteNumber != 0) sql += $"AND SalaryCost.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID WHERE Route.Number = {criteria.RouteNumber}) ";
            if (criteria.CityLabel != "All") sql += $"AND SalaryCost.TruckID IN (SELECT Truck.ID FROM Truck INNER JOIN Route ON Route.ID = Truck.RouteID INNER JOIN RouteCity ON RouteCity.RouteID = Route.ID INNER JOIN City ON City.ID = RouteCity.CityID WHERE City.Label = '{criteria.CityLabel}') ";

            var table = Database.Query(sql);
            if (table.Rows.Count == 0) return 0.0;
            return table.Row().Col<double>();
        }

        protected override string SaveLogString(SalaryCost entity)
        {
            return "Salary Cost";
        }
    }
}
