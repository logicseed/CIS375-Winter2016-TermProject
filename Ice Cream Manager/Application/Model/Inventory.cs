/// <project> IceCreamManager </project>
/// <module> Inventory </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-07 </date_created>

using System;
using System.Data;

namespace IceCreamManager.Model
{
    public class Inventory : DatabaseEntity
    {
        public Inventory(int ID, bool LoadNow)
        {
            this.ID = ID;
            Load(ID);
        }

        protected override string TableName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string CreateCommand
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

        public void AddItem(int ItemID)
        {
            throw new NotImplementedException();
        }

        public override bool Load(int ID)
        {
            string DatabaseCommand = String.Format("SELECT id, item_id, date_created FROM inventory_item WHERE inventory_id = {0}", ID);
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            return InDatabase;
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            throw new NotImplementedException();
        }
    }
}
