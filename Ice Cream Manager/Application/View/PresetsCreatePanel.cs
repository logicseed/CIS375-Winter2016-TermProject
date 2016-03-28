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
    public partial class PresetsCreatePanel : UserControl
    {
        PresetsCreateListPanel presetsCreateListPanel = new PresetsCreateListPanel();
        PresetsCreateItemsPanel presetsCreateItemsPanel = new PresetsCreateItemsPanel();

        public PresetsCreatePanel()
        {
            InitializeComponent();

            presetsCreateListPanel.Dock = DockStyle.Fill;
            presetsCreateDualListPanel.Add(presetsCreateListPanel, 1);

            presetsCreateItemsPanel.Dock = DockStyle.Fill;
            presetsCreateDualListPanel.Add(presetsCreateItemsPanel, 2);
        }
    }
}
