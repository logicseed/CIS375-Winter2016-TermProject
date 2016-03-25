using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class SalesPanel : UserControl
    {
        public SalesPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resizes the SplitContainer to fit the toolbar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salesPanelSplitContainer_Paint(object sender, PaintEventArgs e)
        {
            int width = 0;
            foreach( Control control in salesPanelSplitContainer.Panel1.Controls)
            {
                if (control.Right > width) width = control.Right;
            }
            width += salesPanelSplitContainer.Margin.Right;
            salesPanelSplitContainer.SplitterDistance = width;
        }
    }
}
