using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DeletedRowStyle.SelectionBackColor = Color.Gainsboro;
            DeletedRowStyle.SelectionForeColor = Color.Gray;
            DeletedRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DeletedRowStyle.WrapMode = DataGridViewTriState.False;
            DeletedRowStyle.Font = new Font(this.Font, FontStyle.Italic);
        }

        private void InitializeDefaultHeaderStyle()
        {
            DefaultHeaderStyle.BackColor = Color.WhiteSmoke;
            DefaultHeaderStyle.ForeColor = Color.Black;
            DefaultHeaderStyle.SelectionBackColor = Color.Gainsboro;
            DefaultHeaderStyle.SelectionForeColor = Color.Black;
            DefaultHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DefaultHeaderStyle.WrapMode = DataGridViewTriState.False;
        }

        private void InitializeDefaultRowStyle()
        {
            DefaultRowStyle.BackColor = Color.WhiteSmoke;
            DefaultRowStyle.ForeColor = Color.Black;
            DefaultRowStyle.SelectionBackColor = Color.Gainsboro;
            DefaultRowStyle.SelectionForeColor = Color.Black;
            DefaultRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DefaultRowStyle.WrapMode = DataGridViewTriState.False;
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
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
