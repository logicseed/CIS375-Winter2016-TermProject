using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManager.View
{
    public partial class MainForm : Form
    {
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
            // Remove existing highlights
            foreach (ToolStripItem item in mainToolStrip.Items)
        {
            var DriverDataTable = Factory.Driver.GetDataTable(ShowDeletedDrivers.Checked);
            AddSourceAndFillColumnToGridview(ref DriverGridView, ref DriverDataTable);
            SetLocalizedDriverStrings();
        }

        

        public void RefreshDriverTable() => RefreshDriverTable(null, null);

        public void RefreshItemTable(object sender, EventArgs e)
                if (item is ToolStripButton)
        {
                    item.BackColor = Color.Transparent;
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
            // Highlight specified button
            mainToolStrip.Items.Find(buttonName, true)[0].BackColor = SystemColors.Highlight;
        }

        private void switchPanel(UserControl panel)
        {
            panel.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(panel);
        }

        private void salesButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("salesButton");
            switchPanel(new SalesPanel());
        }

        private void routesButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("routesButton");
            switchPanel(new RoutesPanel());
        }

        private void zonesButton_Click(object sender, EventArgs e)
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
            highlightToolStripButton("zonesButton");
            switchPanel(new ZonesPanel());
        }

        private void trucksButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("trucksButton");
            switchPanel(new TrucksPanel());
            if (ItemGridView.SelectedRows.Count == 0) return;
            int itemID = Convert.ToInt32(ItemGridView.SelectedRows[0].Cells["ID"].Value);
            var itemEditor = new ItemEditor(itemID);
            itemEditor.ShowDialog();
        }

        private void driversButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("driversButton");
            switchPanel(new DriversPanel());
            if (RouteGridView.SelectedRows.Count == 0) return;
            int routeID = Convert.ToInt32(RouteGridView.SelectedRows[0].Cells["ID"].Value);
            var routeEditor = new RouteEditor(routeID);
            routeEditor.ShowDialog();
        }

        private void fuelUsageButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("fuelUsageButton");
            switchPanel(new FuelUsagePanel());
        }

        private void itemsButton_Click(object sender, EventArgs e)
        private void EditTruckButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("itemsButton");
            switchPanel(new ItemsPanel());
            if (TruckGridView.SelectedRows.Count == 0) return;
            int truckID = Convert.ToInt32(TruckGridView.SelectedRows[0].Cells["ID"].Value);
            var truckEditor = new TruckEditor(truckID);
            truckEditor.ShowDialog();
        }

        private void presetsButton_Click(object sender, EventArgs e)
            {
            highlightToolStripButton("presetsButton");
            switchPanel(new PresetsPanel());
            }

        private void settingsButton_Click(object sender, EventArgs e)
            {
            highlightToolStripButton("settingsButton");
            switchPanel(new SettingsPanel());
                LogView.WindowState = FormWindowState.Normal;
                LogView.Focus();
            }
        }

        private void votingButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("votingButton");
            switchPanel(new VotingPanel());
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveTruckButton_Click(object sender, EventArgs e)
        {
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("batchButton");
            switchPanel(new BatchPanel());
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
