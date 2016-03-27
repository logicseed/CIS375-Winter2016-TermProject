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
    public partial class VotingPanel : UserControl
    {
        VotingToolbar votingToolbar = new VotingToolbar();
        VotingResultsListPanel votingResultsListPanel = new VotingResultsListPanel();
        



        public VotingPanel()
        {
            InitializeComponent();


            votingToolbarPanel.Add(votingToolbar, 1);
            votingResultsListPanel.Dock = DockStyle.Fill;
            votingToolbarPanel.Add(votingResultsListPanel, 2);
        }
    }
}
