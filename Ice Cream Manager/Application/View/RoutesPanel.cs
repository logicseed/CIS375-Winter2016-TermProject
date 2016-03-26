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
    public partial class RoutesPanel : UserControl
    {
        SaveUndoToolbar routesToolbar = new SaveUndoToolbar();
        RoutesListPanel routesListPanel = new RoutesListPanel();


        public RoutesPanel()
        {
            InitializeComponent();

            routesToolbar.Controls.Find("toolbarGroup", true)[0].Text = "Route Options";
            routesToolbarPanel.Add(routesToolbar, 1);
            routesListPanel.Dock = DockStyle.Fill;
            routesToolbarPanel.Add(routesListPanel, 2);
        }
    }
}
