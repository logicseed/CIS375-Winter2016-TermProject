/// <project> IceCreamManager </project>
/// <module> LogViewer </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-18 </date_created>

using System;
using System.Data;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class LogViewer : Form
    {
        LanguageManager Language = LanguageManager.Reference;

        private DataTable LogTable = new DataTable();
        private DateTime LastUpdate = DateTime.Now;

        public LogViewer()
        {
            InitializeComponent();
            
            BuildDataSource();

            SetLogGridViewStyles();

            LocalizeForm(null, null);

            Manage.Events.OnChangedLanguage += new EventHandler(LocalizeForm);
            Manage.Events.OnNewLogEntry += new EventHandler(RefreshButton_Click);
        }

        private void LocalizeForm(object sender, EventArgs e)
        {
            Text = Language["LogViewer"];
            RefreshButton.Text = Language["Refresh"];
            MaxEntriesLabel.Text = Language["MaxEntries"];
        }

        public void RefreshDataSource()
        {
            BuildDataSource();
            LogGridView.Refresh();
            MarkFailureRows();
        }

        /// <summary>
        /// Deletes any excess log entries beyond the user defined maximum.
        /// </summary>
        private void CullLogTable()
        {
            if (LogGridView.Rows.Count > (int)MaxEntriesBox.Value)
            {
                for (int i = 0; i < (LogGridView.Rows.Count - (int)MaxEntriesBox.Value); i++)
                {
                    LogTable.Rows[0].Delete();
                }
            }
        }

        /// <summary>
        /// Gets the initial log entries from the database.
        /// </summary>
        protected void BuildDataSource()
        {
            LogTable = Factory.Log.GetDataTable((int)MaxEntriesBox.Value);
            LogTable.Columns.Add(" ");
            LogGridView.DataSource = LogTable;
            LogGridView.Columns[" "].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LogGridView.Columns[" "].Resizable = DataGridViewTriState.False;
            LogGridView.Columns[" "].Frozen = false;
            LogGridView.ClearSelection();
        }

        private void SetLogGridViewStyles()
        {
            LogGridView.Columns["Success"].Visible = false;
            LogGridView.Columns["Message"].Frozen = false;
            LogGridView.Columns["ID"].Visible = false;
            LogGridView.Columns["DateLogged"].ValueType = typeof(DateTime);
            LogGridView.Columns["DateLogged"].Frozen = false;

            LogGridView.DefaultCellStyle.BackColor = System.Drawing.Color.SlateGray;
            LogGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.MintCream;
            //LogGridView.DefaultCellStyle.

            LogGridView.DefaultCellStyle.SelectionBackColor = LogGridView.DefaultCellStyle.BackColor;
            LogGridView.DefaultCellStyle.SelectionForeColor = LogGridView.DefaultCellStyle.ForeColor;

            LogGridView.Columns["DateLogged"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";


        }



        /// <summary>
        /// Highlights rows that show failure log entries.
        /// </summary>
        private void MarkFailureRows()
        {
            foreach (DataGridViewRow Row in LogGridView.Rows)
            {
                if ((bool)Row.Cells["Success"].Value == false)
                {
                    Row.DefaultCellStyle.BackColor = System.Drawing.Color.Tomato;
                    Row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                    Row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Tomato;
                    Row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DarkRed;
                }
            }
        }

        /// <summary>
        /// Event handler to refresh the data source if the RefreshButton is clicked.
        /// </summary>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshDataSource();
        }
    }
}
