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
    public partial class TrucksPanel : UserControl
    {
        SaveUndoToolbar trucksToolbar = new SaveUndoToolbar();
        DualListPanel trucksDualListPanel = new DualListPanel();
        TrucksListPanel trucksListPanel = new TrucksListPanel();
        TrucksInventoryPanel trucksInventoryPanel = new TrucksInventoryPanel();

        public TrucksPanel()
        {
            InitializeComponent();

            trucksToolbar.Controls.Find("toolbarGroup", true)[0].Text = "Truck Options";
            trucksToolbarPanel.Add(trucksToolbar, 1);

            trucksListPanel.Dock = DockStyle.Fill;
            trucksDualListPanel.Add(trucksListPanel, 1);
            trucksInventoryPanel.Dock = DockStyle.Fill;
            trucksDualListPanel.Add(trucksInventoryPanel, 2);

            trucksDualListPanel.Dock = DockStyle.Fill;
            trucksToolbarPanel.Add(trucksDualListPanel, 2);
        }
    }
}
