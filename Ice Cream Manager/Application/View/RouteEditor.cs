/// <project> IceCreamManager </project>
/// <module> RouteEditor </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-18 </date_created>

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
    
    public partial class RouteEditor : Form
    {
        Route route;

        LanguageManager Language = LanguageManager.Reference;

        public RouteEditor()
        {

            InitializeComponent();

            route = Factory.Route.New();

            SetupRouteEditor();
            NumberBox.Value = Factory.Route.NextNumber();
        }



        public RouteEditor(int id)
        {
            InitializeComponent();

            route = Factory.Route.Load(id);
            NumberBox.Value = route.Number;
            SetupRouteEditor();
        }

        private void SetupRouteEditor()
        {
            RefreshCities();
            SetRequirements();
            LocalizeControl();
        }
        private void LocalizeControl()
        {
            Text = Language["RouteEditor"];
            NumberLabel.Text = Language["Number"];
            CitiesLabel.Text = Language["Cities"];
            SaveButton.Text = Language["Save"];
            DiscardButton.Text = Language["Discard"];
            RouteEditorToolTips.SetToolTip(AddCityButton, Language["AddCity"]);
            RouteEditorToolTips.SetToolTip(RemoveCityButton, Language["RemoveCity"]);
        }

        private void RefreshCities()
        {
            RefreshCityGrid();
            RefreshCityList();
            AddCityButton.Enabled = (route.Cities.Count < Requirement.MaxRouteCities);
            RemoveCityButton.Enabled = (route.Cities.Count > 0);
        }

        private void RefreshCityList()
        {
            var CityListBoxContents = new Dictionary<int, string>();
            var AvailableCityList = Factory.City.GetAvailableCityList();
            var CurrentRouteCityList = Factory.Route.LoadCityList(route.ID);

            AvailableCityList.AddRange(CurrentRouteCityList);

            if (AvailableCityList.Count == 0) CityListBoxContents.Add(0, " ");

            foreach (City city in AvailableCityList)
            {
                bool inUse = false;

                foreach (City usedCity in route.Cities)
                {
                    if (usedCity.ID == city.ID) inUse = true;
                }

                if (!inUse) CityListBoxContents.Add(city.ID, city.Label);
            }

            if (CityListBoxContents.Count == 0) CityListBoxContents.Add(0, " ");

            CitiesBox.DataSource = new BindingSource(CityListBoxContents, null);
            CitiesBox.ValueMember = "Key";
            CitiesBox.DisplayMember = "Value";
        }

        private void RefreshCityGrid()
        {
            var CityTable = Factory.City.GetRouteCityDataTable(route.Cities);
            CityGridView.DataSource = CityTable;
            CityGridView.Columns["ID"].Visible = false;
            CityGridView.Columns["Label"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StyleGridView(ref CityGridView);
            CityGridView.Refresh();
        }

        public void StyleGridView(ref DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridView.BackgroundColor = Color.WhiteSmoke;
            dataGridView.GridColor = Color.Gainsboro;
            dataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void SetRequirements()
        {
            NumberBox.Minimum = Requirement.MinRouteNumber;
            NumberBox.Maximum = Requirement.MaxRouteNumber;
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            if (((KeyValuePair<int, string>)CitiesBox.SelectedItem).Key == 0) return;
            int cityID = ((KeyValuePair<int, string>)CitiesBox.SelectedItem).Key;
            route.AddCity(Factory.City.Load(cityID));
            RefreshCities();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (route.Number != (int)NumberBox.Value)
            {
                if (Factory.Route.NumberInUse((int)NumberBox.Value))
                {
                    MessageBox.Show(Language["NumberInUseMsg"], Language["NumberInUse"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                route.Number = (int)NumberBox.Value;
            }

            if (route.Cities.Count == 0)
            {
                MessageBox.Show(Language["RouteCityBlankMsg"], Language["RouteCityBlank"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            route.Save();
            Manage.Events.ChangedRouteList();
            this.Close();
        }

        private void RemoveCityButton_Click(object sender, EventArgs e)
        {
            int cityID = (int)CityGridView.SelectedRows[0].Cells["ID"].Value;

            route.RemoveCity(cityID);
            RefreshCities();
        }
    }
}
