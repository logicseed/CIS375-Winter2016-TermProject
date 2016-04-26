/// <project> IceCreamManager </project>
/// <module> SettingsEditor </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-25 </date_created>

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class SettingsEditor: Form
    {
        LanguageManager Language = LanguageManager.Reference;

        public SettingsEditor()
        {
            InitializeComponent();
            InitializeControls();
            LocalizeForm();
        }

        private void LocalizeForm()
        {
            Text = Language["SettingsEditor"];
            LanguageLabel.Text = Language["Language"];
            CurrencyLabel.Text = Language["Currency"];
            SaveButton.Text = Language["Save"];
            DiscardButton.Text = Language["Discard"];
        }

        private void InitializeControls()
        {
            Dictionary<string,string> languages = Language.GetAvailableLanguages();
            LanguageBox.DataSource = new BindingSource(languages, null);
            LanguageBox.ValueMember = "Key";
            LanguageBox.DisplayMember = "Value";
            LanguageBox.SelectedItem = Language.GetCurrentLanguagePair();

            CurrencyBox.Text = Language.UserCurrency;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Language.UserLanguage = ((KeyValuePair<string, string>)LanguageBox.SelectedItem).Key;
            Language.UserCurrency = CurrencyBox.Text.Trim('\'');

            Language.Save();
        }
    }
}
