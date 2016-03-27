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
    public partial class DualListPanel : UserControl
    {
        public DualListPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a Control to the specified Panel in the DualListPanel SplitContainer.
        /// </summary>
        /// <param name="control">Control to add.</param>
        /// <param name="panel">Panel number of SplitContainer to add the Control to</param>
        public void Add(Control control, int panel)
        {
            if (panel == 1)
            {
                foreach (Control oldControl in this.dualListPanelSplitContainer.Panel1.Controls)
                {
                    this.dualListPanelSplitContainer.Panel1.Controls.Remove(oldControl);
                }
                this.dualListPanelSplitContainer.Panel1.Controls.Add(control);
            }
            else if (panel == 2)
            {
                foreach (Control oldControl in this.dualListPanelSplitContainer.Panel2.Controls)
                {
                    this.dualListPanelSplitContainer.Panel2.Controls.Remove(oldControl);
                }
                this.dualListPanelSplitContainer.Panel2.Controls.Add(control);
            }
        }
    }
}
