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
    public partial class ZonesPanel : UserControl
    {
        SaveUndoToolbar zonesToolbar = new SaveUndoToolbar();
        ZonesListPanel zonesListPanel = new ZonesListPanel();

        public ZonesPanel()
        {
            InitializeComponent();

            zonesToolbar.Controls.Find("toolbarGroup", true)[0].Text = "Zone Options";
            zonesToolbarPanel.Add(zonesToolbar, 1);
            zonesListPanel.Dock = DockStyle.Fill;
            zonesToolbarPanel.Add(zonesListPanel, 2);
        }
    }
}
