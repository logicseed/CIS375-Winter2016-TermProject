using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            RefreshItemTable();
            RefreshCityTable();
            RefreshRouteTable();
            RefreshDriverTable();
            RefreshTruckTable();
            // Default view
            salesButton_Click(this, new EventArgs());
        }

        private void highlightToolStripButton(String buttonName)
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
            Language.OnChangedLanguage += LocalizeForm;
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
    }
}
