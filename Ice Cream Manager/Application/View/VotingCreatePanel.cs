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
    public partial class VotingCreatePanel : UserControl
    {
        VotingCreateListPanel votingCreateListPanel = new VotingCreateListPanel();
        VotingCreateItemsPanel votingCreateItemsPanel = new VotingCreateItemsPanel();

        public VotingCreatePanel()
        {
            InitializeComponent();

            votingCreateListPanel.Dock = DockStyle.Fill;
            votingCreateDualListPanel.Add(votingCreateListPanel, 1);

            votingCreateItemsPanel.Dock = DockStyle.Fill;
            votingCreateDualListPanel.Add(votingCreateItemsPanel, 2);
        }
    }
}
