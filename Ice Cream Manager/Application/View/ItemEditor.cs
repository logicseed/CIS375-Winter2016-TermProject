/// <project> IceCreamManager </project>
/// <module> ItemEditor </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-25 </date_created>

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
        LanguageManager Language = LanguageManager.Reference;
        Item item;

        public ItemEditor()
        {
            InitializeComponent();
            item = Factory.Item.New();
            InitializeControls();
            LocalizeForm();
        }

        public ItemEditor(int itemID)
        {
            InitializeComponent();
            item = Factory.Item.Load(itemID);
            InitializeControls();
            LocalizeForm();
        }

        private void InitializeControls()
        {
            if (item.Number == 0) NumberBox.Value = Factory.Item.NextNumber();
            else NumberBox.Value = item.Number;

            DescriptionBox.Text = item.Description;
            PriceBox.Value = (decimal)item.Price;
            QuantityBox.Value = item.Quantity;
            LifetimeBox.Value = item.Lifetime;

            NumberBox.Minimum = Requirement.MinItemNumber;
            NumberBox.Maximum = Requirement.MaxItemNumber;
            DescriptionBox.MaxLength = Requirement.MaxItemDescriptionLength;
            PriceBox.Minimum = (decimal)Requirement.MinItemPrice;
            PriceBox.Maximum = (decimal)Requirement.MaxItemPrice;
            QuantityBox.Minimum = Requirement.MinItemQuantity;
            QuantityBox.Maximum = Requirement.MaxItemQuantity;
            LifetimeBox.Minimum = Requirement.MinItemLifetime;
            LifetimeBox.Maximum = Requirement.MaxItemLifetime;
        }


        private void LocalizeForm()
        {
            Text = Language["ItemEditor"];
            NumberLabel.Text = Language["Number"];
            DescriptionLabel.Text = Language["Description"];
            PriceLabel.Text = Language["Price"];
            QuantityLabel.Text = Language["Quantity"];
            LifetimeLabel.Text = Language["Lifetime"];
            SaveButton.Text = Language["Save"];
            DiscardButton.Text = Language["Discard"];
        }

        private void SaveItem(object sender, EventArgs e)
        {
            if (item.Number != NumberBox.Value)
            {
                if(Factory.Item.NumberInUse((int)NumberBox.Value))
                {
                    MessageBox.Show(Language["NumberInUseMsg"], Language["NumberInUse"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                item.Number = (int)NumberBox.Value;
            }

            if (item.Description != DescriptionBox.Text || DescriptionBox.Text == "")
            {
                if (DescriptionBox.Text == "")
                {
                    MessageBox.Show(Language["DescriptionBlankMsg"], Language["DescriptionBlank"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                item.Description = DescriptionBox.Text;
            }

            if (item.Price != (double)PriceBox.Value) item.Price = (double)PriceBox.Value;
            if (item.Quantity != QuantityBox.Value) item.Quantity = (int)QuantityBox.Value;
            if (item.Lifetime != LifetimeBox.Value) item.Lifetime = (int)LifetimeBox.Value;

            item.Save();
            Manage.Events.ChangedItemList();
            this.Close();
        }
    }
}