/// <project> IceCreamManager </project>
/// <module> Truck </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class TruckProperties : DatabaseEntityProperties
    {
    }

    public class Truck : DatabaseEntity
    {
        protected override string CreateCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string UpdateCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            throw new NotImplementedException();
        }

        public override bool Load(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
