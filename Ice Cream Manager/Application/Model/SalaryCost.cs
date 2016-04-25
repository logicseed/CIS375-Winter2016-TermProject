/// <project> IceCreamManager </project>
/// <module> SalaryCost </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-13 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class SalaryCost : DatabaseEntity
    {
        SalaryCostFactory salaryCostFactory = SalaryCostFactory.Reference;

        private int truckID = 0;
        private DateTime dateWorked;

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

        public DateTime DateWorked
        {
            get
            {
                return dateWorked;
            }
            set
            {
                dateWorked = value;
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
            return SalaryCostFactory.Reference.Save(this);
        }
    }
}
