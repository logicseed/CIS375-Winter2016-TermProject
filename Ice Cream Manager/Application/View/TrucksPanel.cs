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
        TrucksListPanel trucksListPanel = new TrucksListPanel();

        public TrucksPanel()
        {
            InitializeComponent();

            trucksToolbar.Controls.Find("toolbarGroup", true)[0].Text = "Truck Options";
            trucksToolbarPanel.Add(trucksToolbar, 1);
            trucksListPanel.Dock = DockStyle.Fill;
            trucksToolbarPanel.Add(trucksListPanel, 2);
        }
    }
}
