namespace IceCreamManager.View
{
    partial class ItemEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LifetimeBox = new System.Windows.Forms.NumericUpDown();
            this.QuantityBox = new System.Windows.Forms.NumericUpDown();
            this.PriceBox = new System.Windows.Forms.NumericUpDown();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.LifetimeLabel = new System.Windows.Forms.Label();
            this.NumberBox = new System.Windows.Forms.NumericUpDown();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifetimeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormLayout
            // 
            this.FormLayout.AutoSize = true;
            this.FormLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormLayout.ColumnCount = 1;
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FormLayout.Controls.Add(this.ButtonLayout, 0, 1);
            this.FormLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 2;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.Size = new System.Drawing.Size(213, 209);
            this.FormLayout.TabIndex = 3;
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonLayout.AutoSize = true;
            this.ButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonLayout.ColumnCount = 2;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.Controls.Add(this.SaveButton, 0, 0);
            this.ButtonLayout.Controls.Add(this.DiscardButton, 1, 0);
            this.ButtonLayout.Location = new System.Drawing.Point(48, 169);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.Size = new System.Drawing.Size(162, 37);
            this.ButtonLayout.TabIndex = 2;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveButton.AutoSize = true;
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Image = global::IceCreamManager.Properties.Resources.Save;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(3, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.SaveButton.Size = new System.Drawing.Size(75, 31);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "!Save";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveItem);
            // 
            // DiscardButton
            // 
            this.DiscardButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DiscardButton.AutoSize = true;
            this.DiscardButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardButton.Image = global::IceCreamManager.Properties.Resources.Cancel;
            this.DiscardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DiscardButton.Location = new System.Drawing.Point(84, 3);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.DiscardButton.Size = new System.Drawing.Size(75, 31);
            this.DiscardButton.TabIndex = 4;
            this.DiscardButton.Text = "!Discard";
            this.DiscardButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DiscardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DiscardButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.LifetimeBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.QuantityBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.PriceBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NumberLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PriceLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.QuantityLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LifetimeLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.NumberBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(207, 160);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LifetimeBox
            // 
            this.LifetimeBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LifetimeBox.Location = new System.Drawing.Point(72, 134);
            this.LifetimeBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.LifetimeBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.LifetimeBox.Name = "LifetimeBox";
            this.LifetimeBox.Size = new System.Drawing.Size(57, 20);
            this.LifetimeBox.TabIndex = 12;
            this.LifetimeBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // QuantityBox
            // 
            this.QuantityBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.QuantityBox.Location = new System.Drawing.Point(72, 102);
            this.QuantityBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.QuantityBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(57, 20);
            this.QuantityBox.TabIndex = 11;
            this.QuantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PriceBox
            // 
            this.PriceBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PriceBox.DecimalPlaces = 2;
            this.PriceBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PriceBox.Location = new System.Drawing.Point(72, 70);
            this.PriceBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.PriceBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(57, 20);
            this.PriceBox.TabIndex = 10;
            this.PriceBox.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // NumberLabel
            // 
            this.NumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(19, 9);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(47, 13);
            this.NumberLabel.TabIndex = 0;
            this.NumberLabel.Text = "!Number";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 41);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "!Description";
            // 
            // PriceLabel
            // 
            this.PriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(32, 73);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(34, 13);
            this.PriceLabel.TabIndex = 2;
            this.PriceLabel.Text = "!Price";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(17, 105);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.QuantityLabel.TabIndex = 3;
            this.QuantityLabel.Text = "!Quantity";
            // 
            // LifetimeLabel
            // 
            this.LifetimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LifetimeLabel.AutoSize = true;
            this.LifetimeLabel.Location = new System.Drawing.Point(20, 137);
            this.LifetimeLabel.Name = "LifetimeLabel";
            this.LifetimeLabel.Size = new System.Drawing.Size(46, 13);
            this.LifetimeLabel.TabIndex = 4;
            this.LifetimeLabel.Text = "!Lifetime";
            // 
            // NumberBox
            // 
            this.NumberBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumberBox.Location = new System.Drawing.Point(72, 6);
            this.NumberBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.NumberBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Size = new System.Drawing.Size(57, 20);
            this.NumberBox.TabIndex = 5;
            this.NumberBox.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(72, 38);
            this.DescriptionBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(129, 20);
            this.DescriptionBox.TabIndex = 9;
            // 
            // ItemEditor
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(532, 388);
            this.Controls.Add(this.FormLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!Item Editor";
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifetimeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        protected System.Windows.Forms.Button DiscardButton;
        public System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown LifetimeBox;
        private System.Windows.Forms.NumericUpDown QuantityBox;
        private System.Windows.Forms.NumericUpDown PriceBox;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label LifetimeLabel;
        private System.Windows.Forms.NumericUpDown NumberBox;
        protected System.Windows.Forms.TextBox DescriptionBox;
    }
}