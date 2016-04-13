﻿
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
    }
}
