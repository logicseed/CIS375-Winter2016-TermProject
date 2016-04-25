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
    public partial class DriverEditor : Form
    {
        LanguageManager Language = LanguageManager.Reference;
        Driver driver;

        public DriverEditor()
        {
            InitializeComponent();
            LoadEmptyDriver();
            LocalizeControl();
            SetRequirements();
        }

        private void LoadEmptyDriver()
        {
            driver = Factory.Driver.New();

            NumberBox.Value = Factory.Driver.NextNumber();
        }

        private void LocalizeControl()
        {
            Text = Language["DriverEditor"];
            NumberLabel.Text = Language["Number"];
            NameLabel.Text = Language["Name"];
            HourlyRateLabel.Text = Language["HourlyRate"];
            SaveButton.Text = Language["Save"];
            DiscardButton.Text = Language["Discard"];
        }

        public DriverEditor(int driverID)
        {
            InitializeComponent();
            LoadDriver(driverID);
            LocalizeControl();
            SetRequirements();
        }

        private void LoadDriver(int driverID)
        {
            driver = Factory.Driver.Load(driverID);

            NumberBox.Value = driver.Number;
            NameBox.Text = driver.Name;
            HourlyRateBox.Value = (decimal)driver.HourlyRate;
        }

        private void SetRequirements()
        {
            NumberBox.Minimum = Requirement.MinDriverNumber;
            NumberBox.Maximum = Requirement.MaxDriverNumber;
            NameBox.MaxLength = Requirement.MaxDriverNameLength;
            HourlyRateBox.Minimum = (decimal)Requirement.MinDriverHourlyRate;
            HourlyRateBox.Maximum = (decimal)Requirement.MaxDriverHourlyRate;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (driver.Number != (int)NumberBox.Value)
            {
                if (Factory.Driver.NumberInUse((int)NumberBox.Value))
                {
                    MessageBox.Show(Language["NumberInUseMsg"], Language["NumberInUse"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                driver.Number = (int)NumberBox.Value;
            }

            if (NameBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(Language["NameBlankMsg"], Language["NameBlank"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            driver.Name = NameBox.Text;

            driver.HourlyRate = (double)HourlyRateBox.Value;

            driver.Save();

            Manage.Events.ChangedDriverList();
            Manage.Events.NewLogEntry();

            this.Close();
        }
    }
}
