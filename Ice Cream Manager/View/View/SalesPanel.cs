using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManager.View
{
    public partial class SalesPanel : UserControl
    {
        SalesReportPanel salesReportPanel = new SalesReportPanel();


        public SalesPanel()
        {
            InitializeComponent();

            salesToolbarPanel.Add(salesToolbar, 1);
            salesToolbarPanel.Add(salesReportPanel, 2);
        }
    }
}
