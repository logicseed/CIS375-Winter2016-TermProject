using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    public partial class ItemEditor : Form
    {
        Item item;

        public ItemEditor()
        {
            InitializeComponent();
        }

        public ItemEditor(int itemID)
        {
            InitializeComponent();
        }

        private void SaveItem(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}