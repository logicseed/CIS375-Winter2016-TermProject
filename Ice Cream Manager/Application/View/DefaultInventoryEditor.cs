/// <project> IceCreamManager </project>
/// <module> DefaultInventoryEditor </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-25 </date_created>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class DefaultInventoryEditor : Form
    {
        LanguageManager Language = LanguageManager.Reference;


        public DefaultInventoryEditor()
        {
            InitializeComponent();
            LocalizeForm();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // build list
            var availableItems = Factory.Item.GetAvailableItemList();
            var itemList = new Dictionary<int, string>();

            foreach (var item in availableItems)
            {
                itemList.Add(item.ID, item.Description);
            }

            ItemBox.DataSource = new BindingSource(itemList, null);
            ItemBox.ValueMember = "Key";
            ItemBox.DisplayMember = "Value";

            // build grid

            var table = Factory.Truck.GetDefaultInventoryTable();
            ItemGridView.DataSource = table;
            StyleGridView();
            ItemGridView.ClearSelection();
        }

        private void LocalizeForm()
        {
            Text = Language["DefaultInventoryEditor"];
            ItemsLabel.Text = Language["Items"];
            UpdateButton.Text = Language["Update"];
            OKButton.Text = Language["OK"];
        }

        public void StyleGridView()
        {
            ItemGridView.AllowUserToAddRows = false;
            ItemGridView.AllowUserToDeleteRows = false;
            ItemGridView.MultiSelect = false;
            ItemGridView.ReadOnly = true;
            ItemGridView.RowHeadersVisible = false;
            ItemGridView.ColumnHeadersVisible = false;
            ItemGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            ItemGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ItemGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ItemGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            var DefaultRowStyle = new DataGridViewCellStyle();

            DefaultRowStyle.BackColor = Color.WhiteSmoke;
            DefaultRowStyle.ForeColor = Color.Black;
            DefaultRowStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultRowStyle.SelectionBackColor = Color.Silver;
            DefaultRowStyle.SelectionForeColor = Color.Black;
            DefaultRowStyle.WrapMode = DataGridViewTriState.False;

            ItemGridView.BackgroundColor = Color.WhiteSmoke;
            ItemGridView.GridColor = Color.Gainsboro;
            ItemGridView.DefaultCellStyle = DefaultRowStyle;
            ItemGridView.RowsDefaultCellStyle = DefaultRowStyle;

            ItemGridView.Columns["ID"].Visible = false;
            ItemGridView.Columns["ItemID"].Visible = false;
            ItemGridView.Sort(ItemGridView.Columns["ItemDescription"], ListSortDirection.Ascending);
            ItemGridView.Columns["ItemDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void UpdateItemButton_Click(object sender, EventArgs e)
        {
            var itemID = ((KeyValuePair<int, string>)ItemBox.SelectedItem).Key;

            // equal to max items and item not in grid
            if (ItemGridView.Rows.Count >= Requirement.MaxInventoryDefaultItems && !Factory.Truck.GetDefaultInventoryList().Contains(itemID))
            {
                MessageBox.Show(Language["DefaultItemMaxMsg"], Language["DefaultItemMax"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var quantity = (int)ItemQuantityBox.Value;
            Factory.Truck.ChangeDefaultInventoryItem(itemID, quantity);
            InitializeControls();
        }

        private void ItemGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var itemID = (int)ItemGridView["ItemID", e.RowIndex].Value;
            foreach (KeyValuePair<int, string> pair in ItemBox.Items)
            {
                if (pair.Key == itemID) ItemBox.SelectedItem = pair;
            }
        }

        private void ItemBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var itemID = ((KeyValuePair<int, string>)ItemBox.SelectedItem).Key;

            ItemGridView.ClearSelection();

            foreach (DataGridViewRow row in ItemGridView.Rows)
            {
                if ((int)row.Cells["ItemID"].Value == itemID)
                {

                    row.Selected = true;
                    return;
                }
            }

        }
    }
}