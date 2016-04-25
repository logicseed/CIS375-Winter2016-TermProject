using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class MainForm : Form
    {
        #region Public Constructors

        public MainForm()
        {
            InitializeComponent();
            InitializeRowStyles();
            InitializeEventHandlers();
            InitializeGridViews();
            LocalizeForm(null, null);

            InitializeCriteriaControls();

        }

        



        #endregion Public Constructors

        #region Public Methods

        public void RefreshCityTable(object sender, EventArgs e)
        {
            var CityDataTable = Factory.City.GetDataTable(ShowDeletedCities.Checked);
            AddSourceAndFillColumnToGridview(ref CityGridView, ref CityDataTable);
            SetLocalizedCityStrings();
        }

        

        public void RefreshCityTable() => RefreshCityTable(null, null);

        public void RefreshDriverTable(object sender, EventArgs e)
        {
            var DriverDataTable = Factory.Driver.GetDataTable(ShowDeletedDrivers.Checked);
            AddSourceAndFillColumnToGridview(ref DriverGridView, ref DriverDataTable);
            SetLocalizedDriverStrings();
        }

        

        public void RefreshDriverTable() => RefreshDriverTable(null, null);

        public void RefreshItemTable(object sender, EventArgs e)
        {
            var ItemDataTable = Factory.Item.GetDataTable(ShowDeletedItems.Checked);
            AddSourceAndFillColumnToGridview(ref ItemGridView, ref ItemDataTable);
            SetLocalizedItemStrings();
        }

        

        public void RefreshItemTable() => RefreshItemTable(null, null);

        public void RefreshRouteTable(object sender, EventArgs e)
        {
            var RouteDataTable = Factory.Route.GetDataTable(ShowDeletedRoutes.Checked);
            AddSourceAndFillColumnToGridview(ref RouteGridView, ref RouteDataTable);
            SetLocalizedRouteStrings();
        }

        

        public void RefreshRouteTable() => RefreshRouteTable(null, null);

        public void RefreshTruckTable(object sender, EventArgs e)
        {
            var TruckDataTable = Factory.Truck.GetDataTable(ShowDeletedTrucks.Checked);
            AddSourceAndFillColumnToGridview(ref TruckGridView, ref TruckDataTable);
            TruckGridView.Columns["FuelRate"].DefaultCellStyle.Format = $"{Language.UserCurrency}#.0#";
            SetLocalizedTruckStrings();
        }

        

        public void RefreshTruckTable() => RefreshTruckTable(null, null);

        #endregion Public Methods

        #region Protected Methods

        protected void AddSourceAndFillColumnToGridview(ref DataGridView dataGridView, ref DataTable dataTable)
        {
            dataTable.Columns.Add(" ");
            dataGridView.DataSource = dataTable;
            StyleGridView(ref dataGridView);
            dataGridView.Columns[" "].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[" "].Resizable = DataGridViewTriState.False;
            MarkDeletedRows(ref dataGridView);
            dataGridView.Columns["IsDeleted"].Visible = false;
            dataGridView.ClearSelection();
        }

        

        protected void InitializeEventHandlers()
        {
            Manage.Events.OnChangedLanguage += new EventHandler(LocalizeForm);
            Manage.Events.OnChangedItemList += new EventHandler(RefreshItemTable);
            Manage.Events.OnChangedCityList += new EventHandler(RefreshCityTable);
            Manage.Events.OnChangedRouteList += new EventHandler(RefreshRouteTable);
            Manage.Events.OnChangedDriverList += new EventHandler(RefreshDriverTable);
            Manage.Events.OnChangedTruckList += new EventHandler(RefreshTruckTable);
        }

        protected void InitializeGridViews()
        {
            StyleGridView(ref ItemGridView);
            StyleGridView(ref CityGridView);
            StyleGridView(ref RouteGridView);
            StyleGridView(ref DriverGridView);
            StyleGridView(ref TruckGridView);
        }

        protected override void OnLoad(EventArgs e)
        {
            LogButton_Click(null, null);
            RefreshRevenueTab();

            base.OnLoad(e);
        }

        #endregion Protected Methods

        #region Private Fields

        private LanguageManager Language = LanguageManager.Reference;
        private LogViewer LogView;

        #endregion Private Fields

        #region Private Methods

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutForm();
            aboutBox.ShowDialog();
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            var cityEditor = new CityEditor();
            cityEditor.ShowDialog();
        }

        private void AddDriverButton_Click(object sender, EventArgs e)
        {
            var driverEditor = new DriverEditor();
            driverEditor.ShowDialog();
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            var itemEditor = new ItemEditor();
            itemEditor.ShowDialog();
        }

        private void AddRouteButton_Click(object sender, EventArgs e)
        {
            var routeEditor = new RouteEditor();
            routeEditor.ShowDialog();
        }

        private void AddTruckButton_Click(object sender, EventArgs e)
        {
            var truckEditor = new TruckEditor();
            truckEditor.ShowDialog();
        }

        private void EditCityButton_Click(object sender, EventArgs e)
        {
            if (CityGridView.SelectedRows.Count == 0) return;
            int cityID = Convert.ToInt32(CityGridView.SelectedRows[0].Cells["ID"].Value);
            var cityEditor = new CityEditor(cityID);
            cityEditor.ShowDialog();
        }

        private void EditDriverButton_Click(object sender, EventArgs e)
        {
            if (DriverGridView.SelectedRows.Count == 0) return;
            int driverID = Convert.ToInt32(DriverGridView.SelectedRows[0].Cells["ID"].Value);
            var driverEditor = new DriverEditor(driverID);
            driverEditor.ShowDialog();
        }

        private void EditItemButton_Click(object sender, EventArgs e)
        {
            if (ItemGridView.SelectedRows.Count == 0) return;
            int itemID = Convert.ToInt32(ItemGridView.SelectedRows[0].Cells["ID"].Value);
            var itemEditor = new ItemEditor(itemID);
            itemEditor.ShowDialog();
        }

        private void EditRouteButton_Click(object sender, EventArgs e)
        {
            if (RouteGridView.SelectedRows.Count == 0) return;
            int routeID = Convert.ToInt32(RouteGridView.SelectedRows[0].Cells["ID"].Value);
            var routeEditor = new RouteEditor(routeID);
            routeEditor.ShowDialog();
        }

        private void EditTruckButton_Click(object sender, EventArgs e)
        {
            if (TruckGridView.SelectedRows.Count == 0) return;
            int truckID = Convert.ToInt32(TruckGridView.SelectedRows[0].Cells["ID"].Value);
            var truckEditor = new TruckEditor(truckID);
            truckEditor.ShowDialog();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            if (LogView == null)
            {
                LogView = new LogViewer();
                LogView.FormClosed += (o, ea) => LogView = null;
                LogView.StartPosition = FormStartPosition.Manual;
                LogView.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                LogView.Size = new Size(500, this.Size.Height);
                LogView.Show();
                LogView.RefreshDataSource();
            }
            else
            {
                LogView.WindowState = FormWindowState.Normal;
                LogView.Focus();
            }
        }

        private void RemoveCityButton_Click(object sender, EventArgs e)
        {
            int CityID = Convert.ToInt32(CityGridView.SelectedRows[0].Cells["ID"].Value);
            Factory.City.Delete(CityID);
            Manage.Events.ChangedCityList();
        }

        private void RemoveDriverButton_Click(object sender, EventArgs e)
        {
            int driverID = Convert.ToInt32(DriverGridView.SelectedRows[0].Cells["ID"].Value);
            Factory.Driver.Delete(driverID);
            Manage.Events.ChangedDriverList();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            int ItemID = Convert.ToInt32(ItemGridView.SelectedRows[0].Cells["ID"].Value);
            Factory.Item.Delete(ItemID);
            Manage.Events.ChangedItemList();
        }

        private void RemoveRouteButton_Click(object sender, EventArgs e)
        {
            int routeID = Convert.ToInt32(RouteGridView.SelectedRows[0].Cells["ID"].Value);
            Factory.Route.RemoveRoute(routeID);
            Manage.Events.ChangedRouteList();
        }

        private void RemoveTruckButton_Click(object sender, EventArgs e)
        {
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsEditor = new SettingsEditor();
            settingsEditor.ShowDialog();
        }

        #endregion Private Methods

        private void DefaultInventoryButton_Click(object sender, EventArgs e)
        {
            var defaultInventoryEditor = new DefaultInventoryEditor();
            defaultInventoryEditor.ShowDialog();
        }

        private void MainTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "RevenueTab":
                    RefreshRevenueTab();
                    break;
                case "BatchTab":
                     
                    break;
                case "TrucksTab":
                    RefreshTruckTable();
                    break;
                case "ItemsTab":
                    RefreshItemTable();
                    break;
                case "DriversTab":
                    RefreshDriverTable();
                    break;
                case "RoutesTab":
                    RefreshRouteTable();
                    break;
                case "CitiesTab":
                    RefreshCityTable();
                    break;
            }
        }

        private void RefreshRevenueTab()
        {
            // get criteria
            var criteria = GetRevenueCriteria();

            // fill grid with data
            var gridTable = Revenue.GetRevenueTable(criteria);
            gridTable.Columns.Add(" ");
            RevenueGrid.DataSource = gridTable;
            // localize grid
            StyleGridView(ref RevenueGrid);
            RevenueGrid.Columns[" "].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RevenueGrid.Columns[" "].Resizable = DataGridViewTriState.False;

            // fill chart with data
        }

        private RevenueCriteria GetRevenueCriteria()
        {
            var criteria = new RevenueCriteria();
            criteria.StartDate = StartDateBox.Value.Date;
            criteria.EndDate = EndDateBox.Value.Date;

            if (RouteRevenueBox.SelectedItem == null) criteria.RouteNumber = 0;
            else criteria.RouteNumber = ((KeyValuePair<int, string>)RouteRevenueBox.SelectedItem).Key;

            if (CityRevenueBox.SelectedItem == null) criteria.CityLabel = "All";
            else criteria.CityLabel = ((KeyValuePair<string, string>)CityRevenueBox.SelectedItem).Key;

            if (TruckRevenueBox.SelectedItem == null) criteria.TruckNumber = 0;
            else criteria.TruckNumber = ((KeyValuePair<int, string>)TruckRevenueBox.SelectedItem).Key;

            if (DriverRevenueBox.SelectedItem == null) criteria.DriverNumber = 0;
            else criteria.DriverNumber = ((KeyValuePair<int, string>)DriverRevenueBox.SelectedItem).Key;

            if (ItemRevenueBox.SelectedItem == null) criteria.ItemNumber = 0;
            else criteria.ItemNumber = ((KeyValuePair<int, string>)ItemRevenueBox.SelectedItem).Key;

            return criteria;
        }

        private void InitializeCriteriaControls()
        {
            EndDateBox.Value = DateTime.Now.Date;
            StartDateBox.Value = EndDateBox.Value.AddDays(-7).Date;

            // fill route list
            var routeList = new Dictionary<int, string>();
            routeList.Add(0, Language["All"]);
            Factory.Route.GetRouteNumberList(ref routeList);
            RouteRevenueBox.DataSource = new BindingSource(routeList, null);
            RouteRevenueBox.ValueMember = "Key";
            RouteRevenueBox.DisplayMember = "Value";
            RouteRevenueBox.SelectedIndex = 0;

            //fill city list
            var cityList = new Dictionary<string, string>();
            cityList.Add("All", Language["All"]);
            Factory.City.GetCityLabelList(ref cityList);
            CityRevenueBox.DataSource = new BindingSource(cityList, null);
            CityRevenueBox.ValueMember = "Key";
            CityRevenueBox.DisplayMember = "Value";
            CityRevenueBox.SelectedIndex = 0;

            // fill truck list
            var truckList = new Dictionary<int, string>();
            truckList.Add(0, Language["All"]);
            Factory.Truck.GetTruckNumberList(ref truckList);
            TruckRevenueBox.DataSource = new BindingSource(truckList, null);
            TruckRevenueBox.ValueMember = "Key";
            TruckRevenueBox.DisplayMember = "Value";
            TruckRevenueBox.SelectedIndex = 0;

            // fill driver list
            var driverList = new Dictionary<int, string>();
            driverList.Add(0, Language["All"]);
            Factory.Driver.GetDriverNumberList(ref driverList);
            DriverRevenueBox.DataSource = new BindingSource(driverList, null);
            DriverRevenueBox.ValueMember = "Key";
            DriverRevenueBox.DisplayMember = "Value";
            DriverRevenueBox.SelectedIndex = 0;

            // fill item list
            var itemList = new Dictionary<int, string>();
            itemList.Add(0, Language["All"]);
            Factory.Item.GetItemNumberList(ref itemList);
            ItemRevenueBox.DataSource = new BindingSource(itemList, null);
            ItemRevenueBox.ValueMember = "Key";
            ItemRevenueBox.DisplayMember = "Value";
            ItemRevenueBox.SelectedIndex = 0;
        }

        private void StartDateBox_ValueChanged(object sender, EventArgs e)
        {
            // Cannot start later than the end date
            if (StartDateBox.Value.Date.CompareTo(EndDateBox.Value.Date) == 1)
            {
                EndDateBox.Value = StartDateBox.Value.Date;
            }

            RefreshRevenueTab();
        }

        private void EndDateBox_ValueChanged(object sender, EventArgs e)
        {
            // Cannot be earlier than the start date
            if (EndDateBox.Value.Date.CompareTo(StartDateBox.Value.Date) == -1)
            {
                StartDateBox.Value = EndDateBox.Value.Date;
            }

            RefreshRevenueTab();
        }

        private void RouteRevenueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshRevenueTab();
        }
    }
}
