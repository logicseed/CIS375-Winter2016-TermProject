/// <project> IceCreamManager </project>
/// <module> MainForm.Styles </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-25 </date_created>

using System.Windows.Forms;
using System.Drawing;

namespace IceCreamManager.View
{
    partial class MainForm
    {
        DataGridViewCellStyle DefaultRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle DefaultHeaderStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle DeletedRowStyle = new DataGridViewCellStyle();

        private void InitializeRowStyles()
        {
            InitializeDefaultRowStyle();
            InitializeDefaultHeaderStyle();
            InitializeDeletedRowStyle();
        }

        private void InitializeDeletedRowStyle()
        {
            DeletedRowStyle.BackColor = Color.WhiteSmoke;
            DeletedRowStyle.ForeColor = Color.Gray;
            DeletedRowStyle.Padding = new Padding(6, 3, 6, 3);
            DeletedRowStyle.SelectionBackColor = Color.Silver;
            DeletedRowStyle.SelectionForeColor = Color.Black;
            DeletedRowStyle.WrapMode = DataGridViewTriState.False;
            DeletedRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DeletedRowStyle.Font = this.Font;
            DeletedRowStyle.Font = new Font(this.Font, FontStyle.Italic);
        }

        private void InitializeDefaultHeaderStyle()
        {
            DefaultHeaderStyle.BackColor = Color.Gainsboro;
            DefaultHeaderStyle.ForeColor = Color.Black;
            DefaultHeaderStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultHeaderStyle.SelectionBackColor = Color.Silver;
            DefaultHeaderStyle.SelectionForeColor = Color.Black;
            DefaultHeaderStyle.WrapMode = DataGridViewTriState.False;
            DefaultHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DefaultHeaderStyle.Font = this.Font;
        }

        private void InitializeDefaultRowStyle()
        {
            DefaultRowStyle.BackColor = Color.WhiteSmoke;
            DefaultRowStyle.ForeColor = Color.Black;
            DefaultRowStyle.Padding = new Padding(6, 3, 6, 3);
            DefaultRowStyle.SelectionBackColor = Color.Silver;
            DefaultRowStyle.SelectionForeColor = Color.Black;
            DefaultRowStyle.WrapMode = DataGridViewTriState.False;
            DefaultRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DefaultRowStyle.Font = this.Font;
        }

        private void StyleGridView(ref DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
            dataGridView.DefaultCellStyle = DefaultRowStyle;
            dataGridView.ColumnHeadersDefaultCellStyle = DefaultHeaderStyle;
            dataGridView.GridColor = Color.Gray;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            if (dataGridView.Columns.Contains("ID")) dataGridView.Columns["ID"].Visible = false;
        }

        private void MarkDeletedRows(ref DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if ((bool)dataGridView["IsDeleted", i].Value == true)
                {
                    dataGridView.Rows[i].DefaultCellStyle = DeletedRowStyle;
                }
            }
        }
    }
}
