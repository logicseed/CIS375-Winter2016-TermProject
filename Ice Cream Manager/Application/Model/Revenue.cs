using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManager.Model
{
    public static class Revenue
    {
        public static DataTable GetRevenueTable(RevenueCriteria criteria)
        {
            var returnTable = new DataTable();

            returnTable.Columns.Add(new DataColumn("Date", typeof(string)));
            returnTable.Columns.Add(new DataColumn("Revenue", typeof(double)));
            returnTable.Columns.Add(new DataColumn("Sales", typeof(double)));
            returnTable.Columns.Add(new DataColumn("ItemWaste", typeof(double)));
            returnTable.Columns.Add(new DataColumn("FuelUse", typeof(double)));
            returnTable.Columns.Add(new DataColumn("SalaryCost", typeof(double)));

            var span = criteria.EndDate - criteria.StartDate;
            var days = span.Days == 0 ? 1 : span.Days;

            for (int i = 0; i < days; i++)
            {
                var workingDate = criteria.EndDate.AddDays(-i);
                var returnRow = returnTable.NewRow();

                returnRow["Date"] = workingDate.ToShortDateString();

                double sales = Factory.Sale.GetSales(criteria, workingDate);
                double itemWaste = Factory.ItemWaste.GetItemWaste(criteria, workingDate);
                double fuelUse = Factory.FuelUse.GetFuelUse(criteria, workingDate);
                double salaryCost = Factory.SalaryCost.GetSalaryCost(criteria, workingDate);

                returnRow["Sales"] = sales;
                returnRow["ItemWaste"] = itemWaste;
                returnRow["FuelUse"] = fuelUse;
                returnRow["SalaryCost"] = salaryCost;
                returnRow["Revenue"] = sales - itemWaste - fuelUse - salaryCost;

                returnTable.Rows.Add(returnRow);
            }



            return returnTable;
        }
    }
}
