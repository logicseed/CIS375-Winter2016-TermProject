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
    public partial class DriversPanel : UserControl
    {
        SaveUndoToolbar driversToolbar = new SaveUndoToolbar();
        DriversListPanel driversListPanel = new DriversListPanel();

        public DriversPanel()
        {
            InitializeComponent();

            driversToolbar.Controls.Find("toolbarGroup", true)[0].Text = "Driver Options";
            driversToolbarPanel.Add(driversToolbar, 1);
            driversListPanel.Dock = DockStyle.Fill;
            driversToolbarPanel.Add(driversListPanel, 2);
        }
    }
}
