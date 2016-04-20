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
using IceCreamManager.Controller;

namespace IceCreamManager.View
{
    public partial class MainForm : Form
    {
        LanguageManager Language = LanguageManager.Reference;
        LogViewer LogView;

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

            
        }

        protected override void OnLoad(EventArgs e)
        {
            LogButton_Click(null, null);

            base.OnLoad(e);
        }
        private void InitializeEventHandlers()
        {
            Language.OnChangedLanguage += LocalizeForm;
            Manage.Events.OnChangedItemList += new EventHandler(RefreshItemTable);
            Manage.Events.OnChangedCityList += new EventHandler(RefreshCityTable);
            Manage.Events.OnChangedRouteList += new EventHandler(RefreshRouteTable);
        }

        private void InitializeGridViews()
        {
            StyleGridView(ref ItemGridView);
            StyleGridView(ref CityGridView);
            StyleGridView(ref RouteGridView);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutForm();
            aboutBox.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsEditor = new SettingsEditor();
            settingsEditor.ShowDialog();
        }

        public void RefreshItemTable(object sender, EventArgs e)
        {
            var ItemDataTable = Factory.Item.GetDataTable(ShowDeletedItems.Checked);
            AddSourceAndFillColumnToGridview(ref ItemGridView, ref ItemDataTable);
            SetLocalizedItemStrings();
        }

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

        public void RefreshCityTable(object sender, EventArgs e)
        {
            var CityDataTable = Factory.City.GetDataTable(ShowDeletedCities.Checked);
            AddSourceAndFillColumnToGridview(ref CityGridView, ref CityDataTable);
            SetLocalizedCityStrings();

        }



        private void EditItemButton_Click(object sender, EventArgs e)
        {
            int ItemID = Convert.ToInt32(ItemGridView.SelectedRows[0].Cells["ID"].Value);
            var itemEditor = new ItemEditor(ItemID);
            itemEditor.ShowDialog();
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            var itemEditor = new ItemEditor();
            itemEditor.ShowDialog();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            int ItemID = Convert.ToInt32(ItemGridView.SelectedRows[0].Cells["ID"].Value);
            if (Factory.Item.Delete(ItemID)) RefreshItemTable();
        }

        public void RefreshItemTable() { RefreshItemTable(null, null); }
        public void RefreshCityTable() { RefreshCityTable(null, null); }

        public void RefreshRouteTable() { RefreshRouteTable(null, null); }

        private void RefreshRouteTable(object sender, EventArgs e)
        {
            var RouteDataTable = Factory.Route.GetDataTable(ShowDeletedRoutes.Checked);
            AddSourceAndFillColumnToGridview(ref RouteGridView, ref RouteDataTable);
            SetLocalizedRouteStrings();
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            var cityEditor = new CityEditor();
            cityEditor.ShowDialog();
        }

        private void EditCityButton_Click(object sender, EventArgs e)
        {
            int CityID = Convert.ToInt32(CityGridView.SelectedRows[0].Cells["ID"].Value);
            var cityEditor = new CityEditor(CityID);
            cityEditor.ShowDialog();
        }

        private void RemoveCityButton_Click(object sender, EventArgs e)
        {
            int CityID = Convert.ToInt32(CityGridView.SelectedRows[0].Cells["ID"].Value);
            if (Factory.City.Delete(CityID)) RefreshCityTable();
        }

        private void AddRouteButton_Click(object sender, EventArgs e)
        {
            var routeEditor = new RouteEditor();
            routeEditor.ShowDialog();
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

        private void EditRouteButton_Click(object sender, EventArgs e)
        {
            int routeID = Convert.ToInt32(RouteGridView.SelectedRows[0].Cells["ID"].Value);
            var routeEditor = new RouteEditor(routeID);
            routeEditor.ShowDialog();
        }

        private void RemoveRouteButton_Click(object sender, EventArgs e)
        {
            int routeID = Convert.ToInt32(RouteGridView.SelectedRows[0].Cells["ID"].Value);
            Factory.Route.RemoveRoute(routeID);
            Manage.Events.ChangedRouteList();
        }
    }
}
