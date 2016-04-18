using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public abstract partial class EntityListPanel : UserControl
    {
        protected LanguageManager Language = LanguageManager.Reference;

        public EntityListPanel()
        {
            InitializeComponent();
            SetupLocalizedListPanel();
        }

        protected void SetupLocalizedListPanel()
        {
            RefreshTable(null, null);
            SetLocalizedStrings(null, null);
            Language.OnChangedLanguage += SetLocalizedStrings;
        }

        public abstract void RefreshTable(object sender, EventArgs e);

        protected virtual void SetLocalizedStrings(object sender, EventArgs e)
        {
            RemoveButton.Text = Language?["Remove"];
            ShowDeleted.Text = Language?["ShowDeleted"];
            AddButton.Text = Language?["Add"];
            EditButton.Text = Language?["Edit"];
        }

        protected void DisplayDataTable(DataTable dataTable)
        {
            EntityList.DataSource = dataTable;
            EntityList.Refresh();
        }

    }
}
