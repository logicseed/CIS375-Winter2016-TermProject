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
    public partial class PresetsPanel : UserControl
    {
        PresetsToolbar presetsToolbar = new PresetsToolbar();
        PresetsCreatePanel presetsCreatePanel = new PresetsCreatePanel();

        public PresetsPanel()
        {
            InitializeComponent();

            presetsToolbarPanel.Add(presetsToolbar, 1);
            presetsCreatePanel.Dock = DockStyle.Fill;
            presetsToolbarPanel.Add(presetsCreatePanel, 2);
        }
    }
}
