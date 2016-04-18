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
        #region Singleton
        private static readonly MainForm SingletonInstance = new MainForm();
        public static MainForm Reference { get { return SingletonInstance; } }
        //private MainForm() { }
        #endregion Singleton



        LanguageManager Language = LanguageManager.Reference;

        private MainForm()
        {
            InitializeComponent();

            
            LocalizeForm(null, null);
            Language.OnChangedLanguage += LocalizeForm;
            Manage.Events.OnChangedItemList += new EventHandler(RefreshItemTable);

            RefreshItemTable(null, null);
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
            ItemGridView.Refresh();
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
    }
}
