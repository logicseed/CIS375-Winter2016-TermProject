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
    public partial class FuelUsagePanel : UserControl
    {
        FuelUsageToolbar fuelUsageToolbar = new FuelUsageToolbar();
        FuelUsageListPanel fuelUsageListPanel = new FuelUsageListPanel();
        FuelUsageChartPanel fuelUsageChartPanel = new FuelUsageChartPanel();

        public FuelUsagePanel()
        {
            InitializeComponent();

            fuelUsageChartPanel.Dock = DockStyle.Fill;
            fuelUsageListPanel.Dock = DockStyle.Fill;

            fuelUsageToolbarPanel.Add(fuelUsageToolbar, 1);
            fuelUsageToolbarPanel.Add(fuelUsageListPanel, 2);
        }
    }
}
