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
            highlightToolStripButton("trucksButton");
            switchPanel(new TrucksPanel());
        }

        private void driversButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("driversButton");
            switchPanel(new DriversPanel());
        }

        private void fuelUsageButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("fuelUsageButton");
            switchPanel(new FuelUsagePanel());
        }

        private void itemsButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("itemsButton");
            switchPanel(new ItemsPanel());
        }

        private void presetsButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("presetsButton");
            switchPanel(new PresetsPanel());
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("settingsButton");
            switchPanel(new SettingsPanel());
        }

        private void votingButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("votingButton");
            switchPanel(new VotingPanel());
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {

        }

        private void batchButton_Click(object sender, EventArgs e)
        {
            highlightToolStripButton("batchButton");
            switchPanel(new BatchPanel());
        }
    }
}
