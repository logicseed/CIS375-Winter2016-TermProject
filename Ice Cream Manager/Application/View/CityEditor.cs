/// <project> IceCreamManager </project>
/// <module> CityEditor </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-17 </date_created>

using System;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class CityEditor: Form
    {
        City CityToEdit = new City();
        LanguageManager Language = LanguageManager.Reference;

        public CityEditor()
        {
            InitializeComponent();
            LoadEmptyCity();
            LocalizeControl();
            SetRequirements();
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
        }

        private void LocalizeControl()
        {
            
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
            if (LabelBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(Language["LabelBlankMsg"], Language["LabelBlank"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CityToEdit.Label != LabelBox.Text) CityToEdit.Label = LabelBox.Text;
            if (CityToEdit.Label != LabelBox.Text && Factory.City.LabelInUse(CityToEdit))
            {
                MessageBox.Show(Language["LabelInUseMsg"], Language["LabelInUse"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (NameBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(Language["NameBlankMsg"], Language["NameBlank"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CityToEdit.Name = NameBox.Text;

            if (StateBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(Language["StateBlankMsg"], Language["StateBlank"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CityToEdit.State = StateBox.Text;

            CityToEdit.Miles = (double)MilesBox.Value;
            CityToEdit.Hours = (double)HoursBox.Value;

            CityToEdit.Save();

            Manage.Events.ChangedCityList();
            this.Close();
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
