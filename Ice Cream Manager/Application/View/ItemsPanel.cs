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
    public partial class ItemsPanel : UserControl
    {
        SaveUndoToolbar itemsToolbar = new SaveUndoToolbar();
        ItemsListPanel itemsListPanel = new ItemsListPanel();

        public ItemsPanel()
        {
            InitializeComponent();

            itemsToolbar.Controls.Find("toolbarGroup", true)[0].Text = "Item Options";
            itemsToolbarPanel.Add(itemsToolbar, 1);
            itemsListPanel.Dock = DockStyle.Fill;
            itemsToolbarPanel.Add(itemsListPanel, 2);
        }
    }
}
