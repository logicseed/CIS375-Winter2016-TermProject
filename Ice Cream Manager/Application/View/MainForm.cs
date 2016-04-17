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

        public MainForm()
        {
            InitializeComponent();

            LocalizeForm(null, null);
            Language.OnChangedLanguage += LocalizeForm;
        }

        private void LocalizeForm(object sender, EventArgs e)
        {
            Text = "Ice Cream Manager"; // not localized
            RevenueTab.Text = Language["Revenue"];
            TrucksTab.Text = Language["Trucks"];
            ItemsTab.Text = Language["Items"];
            DriversTab.Text = Language["Drivers"];
            RoutesTab.Text = Language["Routes"];
            CitiesTab.Text = Language["Cities"];
            StatusLabel.Text = Language["Processing"] + "...";
            MainToolTips.SetToolTip(SettingsButton, Language["Settings"]);
            MainToolTips.SetToolTip(LogButton, Language["View Log"]);
            MainToolTips.SetToolTip(AboutButton, Language["About"]);
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
    }
}
