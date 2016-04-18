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
        LogViewer LogView = new LogViewer();

        public MainForm()
        {
            InitializeComponent();

            
            LocalizeForm(null, null);
            Language.OnChangedLanguage += LocalizeForm;
            Manage.Events.OnChangedItemList += new EventHandler(RefreshItemTable);
            Manage.Events.OnChangedCityList += new EventHandler(RefreshCityTable);

            RefreshItemTable();
            RefreshCityTable();
            RefreshRouteTable();
            //ViewItems(null,null);
            //SetupItemList();
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
            ItemGridView.DataSource = Factory.Item.GetDataTable(ShowDeletedItems.Checked);
            SetLocalizedItemStrings();
        }

        public void RefreshCityTable(object sender, EventArgs e)
        {
            CityGridView.DataSource = Factory.City.GetDataTable(ShowDeletedCities.Checked);
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
            RouteGridView.DataSource = Factory.Route.GetDataTable(ShowDeletedRoutes.Checked);
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
            LogView.Show();
            LogView.Select();
        }
    }
}
