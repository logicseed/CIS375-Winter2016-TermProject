using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class TruckEditor : Form
    {
        Truck truck;
        DataTable inventory;
        DataGridViewCellStyle DefaultRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle DefaultItemRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle DefaultBoldRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle DefaultBoldItemRowStyle = new DataGridViewCellStyle();

        LanguageManager Language = LanguageManager.Reference;

        public TruckEditor()
        {
            InitializeComponent();

            truck = Factory.Truck.New();

            SetupTruckEditor();
            NumberBox.Value = Factory.Truck.NextNumber();
        }

        public TruckEditor(int id)
        {
            InitializeComponent();

            truck = Factory.Truck.Load(id);
            
            SetupTruckEditor();
            NumberBox.Value = truck.Number;
            FuelRateBox.Value = (decimal)truck.FuelRate;
        }

        private void SetupTruckEditor()
        {
            SetupDefaultCellStyle();
            SetupDefaultItemCellStyle();
            SetupDefaultBoldCellStyle();
            SetupDefaultBoldItemCellStyle();
            RefreshItems();
            RefreshDrivers();
            RefreshRoutes();
            SetRequirements();
            LocalizeControl();
        }

        private void RefreshRoutes()
        {
            var RouteListBoxContents = new Dictionary<int, string>();
            var AvailableRouteList = Factory.Route.GetAvailableRouteList(truck.ID);

            RouteListBoxContents.Add(0, " ");

            foreach (Route route in AvailableRouteList)
            {
                var name = route.Number + " - ";
                foreach (City city in route.Cities)
                {
                    name += city.Label + ", ";
                }
                if (name.Length > 50)
                {
                    name = name.Substring(0, 46);
                    name += "...";
                }
                if (AvailableRouteList.Count > 1) name = name.Substring(0, name.Length - 2);

                RouteListBoxContents.Add(route.ID, name);
            }

            //if (RouteListBoxContents.Count == 0) RouteListBoxContents.Add(0, " ");

            RouteBox.DataSource = new BindingSource(RouteListBoxContents, null);
            RouteBox.ValueMember = "Key";
            RouteBox.DisplayMember = "Value";

            if (truck.RouteID != 0) 
            RouteBox.SelectedIndex = RouteBox.FindStringExact("test1");
        }

        private void RefreshDrivers()
        {
            var DriverListBoxContents = new Dictionary<int, string>();
            var AvailableDriverList = Factory.Driver.GetAvailableDriverList(truck.ID);

            DriverListBoxContents.Add(0, " ");

            foreach (Driver driver in AvailableDriverList)
            {
                DriverListBoxContents.Add(driver.ID, driver.Name);
            }

            //if (DriverListBoxContents.Count == 0) DriverListBoxContents.Add(0, " ");

            DriverBox.DataSource = new BindingSource(DriverListBoxContents, null);
            DriverBox.ValueMember = "Key";
            DriverBox.DisplayMember = "Value";
        }

        private void LocalizeControl()
        {
            Text = Language["TruckEditor"];
            NumberLabel.Text = Language["Number"];
            DriverLabel.Text = Language["Driver"];
            RouteLabel.Text = Language["Route"];
            FuelRateLabel.Text = Language["FuelRate"];
            ItemsLabel.Text = Language["Items"];
            
            SaveButton.Text = Language["Save"];
            DiscardButton.Text = Language["Discard"];
            StockTruckButton.Text = Language["Stock"];
            UpdateButton.Text = Language["Update"];
            TruckEditorToolTips.SetToolTip(SaleButton, Language["SellItem"]);
            TruckEditorToolTips.SetToolTip(WasteButton, Language["WasteItem"]);
        }

        private void RefreshItems()
        {
            RefreshItemGrid();
            RefreshItemList();
        }

        private void RefreshItemList()
        {
            var ItemListBoxContents = new Dictionary<int, string>();
            var AvailableItemList = Factory.Item.GetAvailableItemList();

            foreach (Item item in AvailableItemList)
            {
                ItemListBoxContents.Add(item.ID, item.Description);
            }

            if (ItemListBoxContents.Count == 0) ItemListBoxContents.Add(0, " ");

            ItemBox.DataSource = new BindingSource(ItemListBoxContents, null);
            ItemBox.ValueMember = "Key";
            ItemBox.DisplayMember = "Value";
        }


        private void RefreshItemGrid()
        {
            if (inventory == null)
            {
                SetupItemGrid();
            }
            CalculateTotalColumns();
            StyleGridView();
            StyleItemGridRows();
        }

        private void CalculateTotalColumns()
        {
            foreach (DataGridViewRow Row in ItemGridView.Rows)
            {
                Row.Cells["TotalQuantity"].Value = (int)Row.Cells["Quantity"].Value + (int)Row.Cells["Change"].Value - (int)Row.Cells["Sale"].Value - (int)Row.Cells["Waste"].Value;
            }
        }

        private void SetupItemGrid()
        {
            inventory = Factory.InventoryItem.GetItemDataTable(truck.ID);

            var defaultItems = Factory.Truck.GetDefaultInventoryList();

            foreach (DataRow row in inventory.Rows)
            {
                if (defaultItems.Contains(row.Col("ItemID"))) row["IsDefault"] = true;
            }

            ItemGridView.DataSource = inventory;
            ItemGridView.Columns["ItemID"].Visible = false;
            ItemGridView.Columns["ItemDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ItemGridView.Columns["Quantity"].Visible = false;
            ItemGridView.Columns["Change"].Visible = false;
            ItemGridView.Columns["Sale"].Visible = false;
            ItemGridView.Columns["Waste"].Visible = false;
            ItemGridView.Columns["IsDefault"].Visible = false;
            ItemGridView.Columns["TotalQuantity"].Visible = true;
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

            ItemGridView.BackgroundColor = Color.WhiteSmoke;
            ItemGridView.GridColor = Color.Gainsboro;
            ItemGridView.DefaultCellStyle = DefaultRowStyle;
            ItemGridView.RowsDefaultCellStyle = DefaultRowStyle;
            

            ItemGridView.Sort(ItemGridView.Columns["ItemDescription"], ListSortDirection.Ascending);
            ItemGridView.Sort(ItemGridView.Columns["IsDefault"], ListSortDirection.Descending);
        }

        private void StyleItemGridRows()
        {
            foreach (DataGridViewRow Row in ItemGridView.Rows)
            {
                var total = (int)Row.Cells["TotalQuantity"].Value;
                var quantity = (int)Row.Cells["Quantity"].Value;
                var change = (int)Row.Cells["Change"].Value;
                var sale = (int)Row.Cells["Sale"].Value;
                var waste = (int)Row.Cells["Waste"].Value;
                var isDefault = (bool)Row.Cells["IsDefault"].Value;

                if (total == 0 && quantity == 0 && !isDefault)
                {
                    ChangeGridRowVisibility(ref ItemGridView, Row.Index, false);
                }
                ChangeGridRowVisibility(ref ItemGridView, Row.Index, true);

                if (isDefault)
                {
                    Row.DefaultCellStyle = DefaultItemRowStyle;
                }

                if (change != 0 || sale != 0 || waste != 0)
                {
                    if (isDefault) Row.DefaultCellStyle = DefaultBoldItemRowStyle;
                    else Row.DefaultCellStyle = DefaultBoldRowStyle;
                }
                
            }
        }

        private void ChangeGridRowVisibility(ref DataGridView gridView, int index, bool visible)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[gridView.DataSource];
            currencyManager.SuspendBinding();
            gridView.Rows[index].Visible = visible;
            currencyManager.ResumeBinding();
        }

        private void SetupDefaultCellStyle()
        {
            DefaultRowStyle.BackColor = Color.WhiteSmoke;
            DefaultRowStyle.ForeColor = Color.Black;
            DefaultRowStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultRowStyle.SelectionBackColor = Color.Silver;
            DefaultRowStyle.SelectionForeColor = Color.Black;
            DefaultRowStyle.WrapMode = DataGridViewTriState.False;
        }

        private void SetupDefaultItemCellStyle()
        {
            DefaultItemRowStyle.BackColor = Color.WhiteSmoke;
            DefaultItemRowStyle.ForeColor = Color.DarkBlue;
            DefaultItemRowStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultItemRowStyle.SelectionBackColor = Color.Silver;
            DefaultItemRowStyle.SelectionForeColor = Color.DarkBlue;
            DefaultItemRowStyle.WrapMode = DataGridViewTriState.False;
        }

        private void SetupDefaultBoldCellStyle()
        {
            DefaultBoldRowStyle.BackColor = Color.WhiteSmoke;
            DefaultBoldRowStyle.ForeColor = Color.Black;
            DefaultBoldRowStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultBoldRowStyle.SelectionBackColor = Color.Silver;
            DefaultBoldRowStyle.SelectionForeColor = Color.Black;
            DefaultBoldRowStyle.WrapMode = DataGridViewTriState.False;
            DefaultBoldRowStyle.Font = new Font(ItemGridView.Font, FontStyle.Bold);
        }

        private void SetupDefaultBoldItemCellStyle()
        {
            DefaultBoldItemRowStyle.BackColor = Color.WhiteSmoke;
            DefaultBoldItemRowStyle.ForeColor = Color.DarkBlue;
            DefaultBoldItemRowStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultBoldItemRowStyle.SelectionBackColor = Color.Silver;
            DefaultBoldItemRowStyle.SelectionForeColor = Color.DarkBlue;
            DefaultBoldItemRowStyle.WrapMode = DataGridViewTriState.False;
            DefaultBoldItemRowStyle.Font = new Font(ItemGridView.Font, FontStyle.Bold);
        }

        private void SetRequirements()
        {
            NumberBox.Minimum = Requirement.MinRouteNumber;
            NumberBox.Maximum = Requirement.MaxRouteNumber;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var itemID = ((KeyValuePair<int, string>)ItemBox.SelectedItem).Key;
            var change = ItemQuantityBox.Value;

            if ((!ItemInTable(itemID) || ItemGridView.Rows[GetItemTableRowIndex(itemID)].Visible == false) && NumberNonDefaultItems() + NumberDefaultItems() >= Requirement.MaxInventoryItems)
            {
                MessageBox.Show(Language["TooManyItemsMsg"], Language["TooManyItems"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ItemInTable(itemID))
            {
                var index = GetItemTableRowIndex(itemID);
                var quantity = (int)inventory.Rows[index]["Quantity"];
                var sale = (int)inventory.Rows[index]["Sale"];
                var waste = (int)inventory.Rows[index]["Waste"];
                inventory.Rows[index]["Change"] = change + sale + waste - quantity;
                ItemGridView.Rows[GetItemTableRowIndex(itemID)].Visible = true;
            }
            else
            {
                DataRow row = inventory.NewRow();
                row["ItemID"] = itemID;
                row["ItemDescription"] = Factory.Item.GetNameByID(itemID);
                row["Change"] = change;
                inventory.Rows.Add(row);
            }
            RefreshItemGrid();
        }

        private int NumberDefaultItems()
        {
            int number = 0;
            foreach (DataRow row in inventory.Rows)
            {
                if (row.Col<bool>("IsDefault")) number++;
            }
            return number;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check number
            if (truck.Number != NumberBox.Value && Factory.Truck.NumberInUse((int)NumberBox.Value))
            {
                MessageBox.Show(Language["NumberInUseMsg"], Language["NumberInUse"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (truck.Number != (int)NumberBox.Value) truck.Number = (int)NumberBox.Value;

            if (DriverBox.SelectedItem == null && truck.DriverID != 0) truck.DriverID = 0;
            else if(truck.DriverID != ((KeyValuePair<int,string>)DriverBox.SelectedItem).Key) truck.DriverID = ((KeyValuePair<int, string>)DriverBox.SelectedItem).Key;

            if (RouteBox.SelectedItem == null && truck.RouteID != 0) truck.RouteID = 0;
            else if(truck.RouteID != ((KeyValuePair<int, string>)RouteBox.SelectedItem).Key) truck.RouteID = ((KeyValuePair<int, string>)RouteBox.SelectedItem).Key;

            if (truck.FuelRate != (double)FuelRateBox.Value) truck.FuelRate = (double)FuelRateBox.Value;
            truck.Save();

            //loop through changes,sales,waste
            foreach (DataRow row in inventory.Rows)
            {
                Factory.InventoryItem.ChangeMany(row.Col("ItemID"), truck.ID, row.Col("Change"));
                Factory.InventoryItem.SellMany(row.Col("ItemID"), truck.ID, row.Col("Sale"));
                Factory.InventoryItem.WasteMany(row.Col("ItemID"), truck.ID, row.Col("Waste"));
            }

            Manage.Events.ChangedTruckList();
            this.Close();
        }

        private void StockTruckButton_Click(object sender, EventArgs e)
        {
            var stock = Factory.Truck.StockTruck(truck.ID);

            foreach (KeyValuePair<int, int> pair in stock)
            {
                var alreadyAdded = false;
                foreach (DataRow row in inventory.Rows)
                {
                    if (row.Col("ItemID") == pair.Key)
                    {
                        if (row.Col("Quantity") != pair.Value) row["Change"] = pair.Value - row.Col("Quantity");
                        else row["Change"] = 0;
                        row["IsDefault"] = true;
                        alreadyAdded = true;
                    }
                }
                if(!alreadyAdded)
                {
                    var row = inventory.NewRow();
                    row["ItemID"] = pair.Key;
                    row["ItemDescription"] = Factory.Item.GetNameByID(pair.Key);
                    row["Change"] = pair.Value;
                    row["IsDefault"] = true;

                    inventory.Rows.Add(row);
                }
            }

            StockTruckButton.Enabled = false;
            RefreshItemGrid();  
        }

        private void TruckEditor_Shown(object sender, EventArgs e)
        {
            StyleItemGridRows();
        }

        private bool ItemInTable(int itemID)
        {
            foreach (DataRow row in inventory.Rows)
            {
                if (row.Col("ItemID") == itemID) return true;
            }
            return false;
        }

        private int NumberNonDefaultItems()
        {
            int number = 0;
            foreach (DataRow row in inventory.Rows)
            {
                if (!row.Col<bool>("IsDefault") && row.Col("TotalQuantity") != 0) number++;
            }
            return number;
        }

        private int GetItemTableRowIndex(int itemID)
        {
            for (int i = 0; i < inventory.Rows.Count; i++)
            {
                DataRow row = (DataRow)inventory.Rows[i];
                if (row.Col("ItemID") == itemID) return i;
            }
            return -1;
        }

        private void SaleButton_Click(object sender, EventArgs e)
        {
            if (ItemGridView.SelectedRows.Count == 0) return;

            var itemID = (int)ItemGridView["ItemID", ItemGridView.SelectedRows[0].Index].Value;
            var index = GetItemTableRowIndex(itemID);
            var sale = (int)SaleNumberBox.Value;
           // var quantity = (int)inventory.Rows[index]["Quantity"]; Goes in save
           // var change = (int)inventory.Rows[index]["Change"];

            var total = inventory.Row(index).Col("TotalQuantity");
            if (sale > total) sale = total;
           // if (sale > quantity) inventory.Rows[index]["Change"] = change - sale;

            inventory.Rows[index]["Sale"] = (int)inventory.Rows[index]["Sale"] + sale;

            RefreshItemGrid();
        }

        private void WasteButton_Click(object sender, EventArgs e)
        {
            if (ItemGridView.SelectedRows.Count == 0) return;

            var itemID = (int)ItemGridView["ItemID", ItemGridView.SelectedRows[0].Index].Value;
            var index = GetItemTableRowIndex(itemID);
            var waste = (int)WasteNumberBox.Value;

            var total = inventory.Row(index).Col("TotalQuantity");
            if (waste > total) waste = total;

            inventory.Rows[index]["Waste"] = (int)inventory.Rows[index]["Waste"] + waste;

            RefreshItemGrid();
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
