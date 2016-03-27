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
            // Default view
            salesButton_Click(this, new EventArgs());
        }

        private void highlightToolStripButton(String buttonName)
        {
            // Remove existing highlights
            foreach (ToolStripItem item in mainToolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    item.BackColor = Color.Transparent;
                }
            }

            // Highlight specified button
            mainToolStrip.Items.Find(buttonName, true)[0].BackColor = SystemColors.Highlight;
        }

        private void switchPanel(UserControl panel)
        {
            panel.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(panel);
        }

        private void salesButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("salesButton");
            switchPanel(new SalesPanel());
        }

        private void routesButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("routesButton");
            switchPanel(new RoutesPanel());
        }

        private void zonesButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("zonesButton");
            switchPanel(new ZonesPanel());
        }

        private void trucksButton_Click(object sender, EventArgs e)
        {

        }

        private void driversButton_Click(object sender, EventArgs e)
        {

        }

        private void fuelUsageButton_Click(object sender, EventArgs e)
        {

        }

        private void itemsButton_Click(object sender, EventArgs e)
        {

        }

        private void presetsButton_Click(object sender, EventArgs e)
        {

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }

        private void votingButton_Click(object sender, EventArgs e)
        {

        }

        private void aboutButton_Click(object sender, EventArgs e)
        {

        }

        private void helpButton_Click(object sender, EventArgs e)
        {

        }
    }
}
