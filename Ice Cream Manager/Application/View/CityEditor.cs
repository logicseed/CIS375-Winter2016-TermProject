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
    public partial class CityEditor: Form
    {
        City CityToEdit = new City();
        ActionType actionType;

        public CityEditor()
        {
            InitializeComponent();
            LoadEmptyCity();
            LocalizeControl();
            SetRequirements();
            actionType = ActionType.AddNewCity;
        }

        private void LoadEmptyCity()
        {
            CityToEdit = Factory.City.New();
        }

        public CityEditor(int cityID)
        {
            InitializeComponent();
            LoadCity(cityID);
            LocalizeControl();
            SetRequirements();
            actionType = ActionType.EditCity;
        }

        private void LocalizeControl()
        {
            var Language = LanguageManager.Reference;
            Text = Language["CityEditor"];
            LabelLabel.Text = Language["Label"];
            NameLabel.Text = Language["Name"];
            StateLabel.Text = Language["State"];
            MilesLabel.Text = Language["Miles"];
            HoursLabel.Text = Language["Hours"];

            SaveButton.Text = Language["Save"];
            DiscardButton.Text = Language["Discard"];
        }

        private void LoadCity(int cityID)
        {
            CityToEdit = Factory.City.Load(cityID);

            LabelBox.Text = CityToEdit.Label;
            NameBox.Text = CityToEdit.Name;
            StateBox.Text = CityToEdit.State;
            MilesBox.Value = (decimal)CityToEdit.Miles;
            HoursBox.Value = (decimal)CityToEdit.Hours;

        }

        private void SaveCity()
        {
            SaveCity(null, null);
        }

        private void SaveCity(object sender, EventArgs e)
        {
            CityToEdit.Label = LabelBox.Text;
            CityToEdit.Name = NameBox.Text;
            CityToEdit.State = StateBox.Text;
            CityToEdit.Miles = (double)MilesBox.Value;
            CityToEdit.Hours = (double)HoursBox.Value;

            CityToEdit.Save();

            Manage.Events.ChangedCityList();
        }

        private void SetRequirements()
        { 
            LabelBox.MaxLength = Requirement.MaxCityLabelLength;
            NameBox.MaxLength = Requirement.MaxCityNameLength;
            StateBox.MaxLength = Requirement.MaxCityStateLength;
            MilesBox.Minimum = (decimal)Requirement.MinCityMiles;
            MilesBox.Maximum = (decimal)Requirement.MaxCityMiles;
            HoursBox.Minimum = (decimal)Requirement.MinCityHours;
            HoursBox.Maximum = (decimal)Requirement.MaxCityHours;
        }
    }
}
