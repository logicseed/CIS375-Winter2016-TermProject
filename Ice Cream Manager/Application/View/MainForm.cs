using System;
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

            RefreshItemTable();
            RefreshCityTable();
            RefreshRouteTable();
            RefreshDriverTable();
            RefreshTruckTable();
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
            truckEditor.Show();
        }

        private void EditCityButton_Click(object sender, EventArgs e)
        {
            int CityID = Convert.ToInt32(CityGridView.SelectedRows[0].Cells["ID"].Value);
            var cityEditor = new CityEditor(CityID);
            cityEditor.ShowDialog();
        }

        private void EditDriverButton_Click(object sender, EventArgs e)
        {
            int driverID = Convert.ToInt32(DriverGridView.SelectedRows[0].Cells["ID"].Value);
            var driverEditor = new DriverEditor(driverID);
            driverEditor.ShowDialog();
        }

        private void EditItemButton_Click(object sender, EventArgs e)
        {
            int ItemID = Convert.ToInt32(ItemGridView.SelectedRows[0].Cells["ID"].Value);
            var itemEditor = new ItemEditor(ItemID);
            itemEditor.ShowDialog();
        }

        private void EditRouteButton_Click(object sender, EventArgs e)
        {
            int routeID = Convert.ToInt32(RouteGridView.SelectedRows[0].Cells["ID"].Value);
            var routeEditor = new RouteEditor(routeID);
            routeEditor.ShowDialog();
        }

        private void EditTruckButton_Click(object sender, EventArgs e)
        {
            var truckEditor = new TruckEditor();
            truckEditor.Show();
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
    }
}
