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
            var Language = LanguageManager.Reference;
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
            var CityList = Factory.City.GetAvailableCityList();
            var CityTable = Factory.City.GetRouteCityDataTable(route.Cities);
            CityTable.PrimaryKey = new DataColumn[] { CityTable.Columns["ID"] };

            foreach (City city in CityList)
            {

                if (CityTable.Rows.Contains(city.ID)) continue;
                CityListBoxContents.Add(city.ID, city.Label);
            }

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
            int cityID = ((KeyValuePair<int, string>)CitiesBox.SelectedItem).Key;
            route.AddCity(Factory.City.Load(cityID));
            RefreshCities();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            route.Number = (int)NumberBox.Value;
            route.Save();
            Manage.Events.ChangedRouteList();
        }
    }
}
