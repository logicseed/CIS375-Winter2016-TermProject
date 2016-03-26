

using System.Windows.Forms;

namespace IceCreamManager.View
{
    public partial class ToolbarPanel : UserControl
    {
        public ToolbarPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resizes Panel1 of the SplitContainer to fit the toolbar. This occurs whenever
        /// the SplitContainer is painted.
        /// </summary>
        /// <param name="sender">The object that sent the paint event request.</param>
        /// <param name="e">Arguments to modify the paint event.</param>
        private void toolbarPanelSplitContainer_Paint(object sender, PaintEventArgs e)
        {
            int toolbarWidth = 0;

            // Find the largest control in the toolbar
            foreach (Control control in toolbarPanelSplitContainer.Panel1.Controls)
            {
                if (control.Right > toolbarWidth) toolbarWidth = control.Right;
            }

            // Add the splitContainer margin
            toolbarWidth += toolbarPanelSplitContainer.Margin.Right;

            // Set the splitter distance to a width that fits the toolbar
            toolbarPanelSplitContainer.SplitterDistance = toolbarWidth;
        }

        /// <summary>
        /// Adds a Control to the specified Panel in the ToolbarPanel SplitContainer.
        /// </summary>
        /// <param name="control">Control to add.</param>
        /// <param name="panel">Panel number of SplitContainer to add the Control to</param>
        public void Add(Control control, int panel)
        {
            if (panel == 1)
            {
                foreach (Control oldControl in this.toolbarPanelSplitContainer.Panel1.Controls)
                {
                    this.toolbarPanelSplitContainer.Panel1.Controls.Remove(oldControl);
                }
                this.toolbarPanelSplitContainer.Panel1.Controls.Add(control);
            }
            else if (panel == 2)
            {
                foreach (Control oldControl in this.toolbarPanelSplitContainer.Panel2.Controls)
                {
                    this.toolbarPanelSplitContainer.Panel2.Controls.Remove(oldControl);
                }
                this.toolbarPanelSplitContainer.Panel2.Controls.Add(control);
            }
        }
    }
}
