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
using IceCreamManager.Controller;

namespace IceCreamManager.View
{
    public partial class AbstractEditor : Form
    {
        // BUG: Uncomment LanguageParser when done with design view
        // protected LanguageParser Language = LanguageParser.Reference;
        protected DatabaseEntity EditingEntity;

        public AbstractEditor()
        {
            InitializeComponent();

            // BUG: Comment for designer mode
            //SetLanguageStrings();
        }

        //protected void SetLanguageStrings()
        //{
        //    this.Text = "AbstractEditor";
        //    this.CancelButton.Text = Language["Cancel"];
        //    this.SaveButton.Text = Language["Save"];
        //}
    }
}
