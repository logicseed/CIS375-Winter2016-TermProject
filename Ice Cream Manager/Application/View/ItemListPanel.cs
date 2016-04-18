using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class ItemListPanel : EntityListPanel
    {
        ItemFactory Items = ItemFactory.Reference;

        public ItemListPanel()
        {
            InitializeComponent();
            SetupLocalizedListPanel();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            Manage.Events.OnChangedItemList += new EventHandler(RefreshTable);
            AddButton.Click += new EventHandler(AddButton_Click);
            EditButton.Click += new EventHandler(EditButton_Click);
            RemoveButton.Click += new EventHandler(RemoveButton_Click);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int ItemID = Convert.ToInt32(EntityList.SelectedRows[0].Cells["ID"].Value);
            Manage.Events.EditItem(ItemID);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //
        }

        public override void RefreshTable(object sender, EventArgs e)
        {
            EntityList.DataSource = Items.GetDataTable(ShowDeleted.Checked);
            EntityList.Refresh();
        }

        protected override void SetLocalizedStrings(object sender, EventArgs e)
        {
            base.SetLocalizedStrings(sender, e);

            EntityList.Columns["ID"].Visible = false;
            EntityList.Columns["Number"].HeaderText = Language["Number"];
            EntityList.Columns["Description"].HeaderText = Language["Description"];
            EntityList.Columns["Price"].HeaderText = Language["Price"];
            EntityList.Columns["Quantity"].HeaderText = Language["Quantity"];
            EntityList.Columns["Lifetime"].HeaderText = Language["Lifetime"];
            EntityList.Columns["IsDeleted"].HeaderText = Language["Deleted"];

            Refresh();
        }

        private void OnRowDoubleClock(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
        }


    }
}
