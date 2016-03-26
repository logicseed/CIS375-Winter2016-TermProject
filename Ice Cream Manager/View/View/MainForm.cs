using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManager.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            View.SalesPanel salesPanel = new View.SalesPanel();
            salesPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(salesPanel);
        }

    }
}
