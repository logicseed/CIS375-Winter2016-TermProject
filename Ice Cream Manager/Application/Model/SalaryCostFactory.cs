/// <project> IceCreamManager </project>
/// <module> SalaryCostFactory </module>
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
    public class SalaryCostFactory : DatabaseEntityFactory<SalaryCost>
    {
        #region Singleton
        private static readonly SalaryCostFactory SingletonInstance = new SalaryCostFactory();
        public static SalaryCostFactory Reference { get { return SingletonInstance; } }
        private SalaryCostFactory() { }
        #endregion Singleton

        protected override string DatabaseQueryColumns()
            => "DriverID,RouteID,DateWorked";

        protected override string DatabaseQueryColumnValuePairs(SalaryCost salaryCost)
            => $"DriverID = {salaryCost.DriverID},RouteID = {salaryCost.RouteID},DateWorked = '{salaryCost.DateWorked.ToDatabase()}'";

        protected override string DatabaseQueryValues(SalaryCost salaryCost)
            => $"{salaryCost.DriverID},{salaryCost.RouteID},'{salaryCost.DateWorked.ToDatabase()}'";

        protected override SalaryCost MapDataRowToProperties(DataRow row)
        {
            SalaryCost salaryCost = new SalaryCost();

            salaryCost.ID = row.Col("ID");
            salaryCost.DriverID = row.Col("DriverID");
            salaryCost.RouteID = row.Col("RouteID");
            salaryCost.DateWorked = row.Col<DateTime>("DateWorked");
            salaryCost.InDatabase = true;
            salaryCost.IsSaved = true;

            return salaryCost;
        }
    }
}
