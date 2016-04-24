/// <project> IceCreamManager </project>
/// <module> FuelUseFactory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class FuelUse : DatabaseEntity
    {
        FuelUseFactory fuelUseFactory = FuelUseFactory.Reference;

        private int truckID = 0;
        private DateTime dateUsed;

        private Truck truck = null;

        public int TruckID
        {
            get
            {
                return truckID;
            }
            set
            {
                if (value != truckID) truck = null;
                truckID = value;
                IsSaved = false;
            }
        }

        public DateTime DateUsed
        {
            get
            {
                return dateUsed;
            }
            set
            {
                dateUsed = value;
                IsSaved = false;
            }
        }

        public Truck Truck
        {
            get
            {
                if (truck == null) truck = Factory.Truck.Load(truckID);
                return truck;
            }
        }

        public override bool Save()
        {
            return FuelUseFactory.Reference.Save(this);
        }
    }
}
