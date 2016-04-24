namespace IceCreamManager.View
{
    partial class DefaultInventoryEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultInventoryEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.OKButton = new System.Windows.Forms.Button();
            this.TruckEditorControlsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CityListLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ItemGridView = new System.Windows.Forms.DataGridView();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.UnderItemGridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ItemQuantityBox = new System.Windows.Forms.NumericUpDown();
            this.ItemsBox = new System.Windows.Forms.ComboBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.TruckEditorControlsLayout.SuspendLayout();
            this.CityListLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).BeginInit();
            this.UnderItemGridLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormLayout
            // 
            this.FormLayout.AutoSize = true;
            this.FormLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormLayout.ColumnCount = 1;
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FormLayout.Controls.Add(this.ButtonLayout, 0, 1);
            this.FormLayout.Controls.Add(this.TruckEditorControlsLayout, 0, 0);
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 2;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.Size = new System.Drawing.Size(290, 340);
            this.FormLayout.TabIndex = 6;
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonLayout.AutoSize = true;
            this.ButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonLayout.ColumnCount = 1;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ButtonLayout.Controls.Add(this.OKButton, 0, 0);
            this.ButtonLayout.Location = new System.Drawing.Point(206, 300);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(81, 37);
            this.ButtonLayout.TabIndex = 2;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKButton.AutoSize = true;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKButton.Location = new System.Drawing.Point(3, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.OKButton.Size = new System.Drawing.Size(75, 31);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "!OK";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // TruckEditorControlsLayout
            // 
            this.TruckEditorControlsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TruckEditorControlsLayout.ColumnCount = 1;
            this.TruckEditorControlsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TruckEditorControlsLayout.Controls.Add(this.CityListLayout, 0, 0);
            this.TruckEditorControlsLayout.Controls.Add(this.UnderItemGridLayout, 0, 1);
            this.TruckEditorControlsLayout.Location = new System.Drawing.Point(3, 3);
            this.TruckEditorControlsLayout.Name = "TruckEditorControlsLayout";
            this.TruckEditorControlsLayout.RowCount = 2;
            this.TruckEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TruckEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TruckEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TruckEditorControlsLayout.Size = new System.Drawing.Size(284, 291);
            this.TruckEditorControlsLayout.TabIndex = 3;
            // 
            // CityListLayout
            // 
            this.CityListLayout.AutoSize = true;
            this.CityListLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CityListLayout.ColumnCount = 1;
            this.CityListLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CityListLayout.Controls.Add(this.ItemGridView, 0, 1);
            this.CityListLayout.Controls.Add(this.ItemsLabel, 0, 0);
            this.CityListLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CityListLayout.Location = new System.Drawing.Point(3, 3);
            this.CityListLayout.Name = "CityListLayout";
            this.CityListLayout.RowCount = 2;
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityListLayout.Size = new System.Drawing.Size(278, 247);
            this.CityListLayout.TabIndex = 1;
            // 
            // ItemGridView
            // 
            this.ItemGridView.AllowUserToAddRows = false;
            this.ItemGridView.AllowUserToDeleteRows = false;
            this.ItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemGridView.Location = new System.Drawing.Point(3, 22);
            this.ItemGridView.Name = "ItemGridView";
            this.ItemGridView.ReadOnly = true;
            this.ItemGridView.Size = new System.Drawing.Size(272, 225);
            this.ItemGridView.TabIndex = 1;
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Location = new System.Drawing.Point(6, 6);
            this.ItemsLabel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(35, 13);
            this.ItemsLabel.TabIndex = 2;
            this.ItemsLabel.Text = "!Items";
            // 
            // UnderItemGridLayout
            // 
            this.UnderItemGridLayout.AutoSize = true;
            this.UnderItemGridLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UnderItemGridLayout.ColumnCount = 4;
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.UnderItemGridLayout.Controls.Add(this.ItemQuantityBox, 1, 0);
            this.UnderItemGridLayout.Controls.Add(this.ItemsBox, 0, 0);
            this.UnderItemGridLayout.Controls.Add(this.UpdateButton, 2, 0);
            this.UnderItemGridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnderItemGridLayout.Location = new System.Drawing.Point(3, 256);
            this.UnderItemGridLayout.Name = "UnderItemGridLayout";
            this.UnderItemGridLayout.RowCount = 1;
            this.UnderItemGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.UnderItemGridLayout.Size = new System.Drawing.Size(278, 32);
            this.UnderItemGridLayout.TabIndex = 2;
            // 
            // ItemQuantityBox
            // 
            this.ItemQuantityBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemQuantityBox.Location = new System.Drawing.Point(155, 6);
            this.ItemQuantityBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.ItemQuantityBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ItemQuantityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemQuantityBox.Name = "ItemQuantityBox";
            this.ItemQuantityBox.Size = new System.Drawing.Size(56, 20);
            this.ItemQuantityBox.TabIndex = 6;
            this.ItemQuantityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ItemQuantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ItemsBox
            // 
            this.ItemsBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemsBox.FormattingEnabled = true;
            this.ItemsBox.Location = new System.Drawing.Point(3, 5);
            this.ItemsBox.Name = "ItemsBox";
            this.ItemsBox.Size = new System.Drawing.Size(146, 21);
            this.ItemsBox.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UpdateButton.AutoSize = true;
            this.UpdateButton.FlatAppearance.BorderSize = 0;
            this.UpdateButton.Location = new System.Drawing.Point(220, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(55, 23);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "!Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateItemButton_Click);
            // 
            // DefaultInventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.OKButton;
            this.ClientSize = new System.Drawing.Size(312, 358);
            this.Controls.Add(this.FormLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefaultInventoryEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!Default Inventory Editor";
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.TruckEditorControlsLayout.ResumeLayout(false);
            this.TruckEditorControlsLayout.PerformLayout();
            this.CityListLayout.ResumeLayout(false);
            this.CityListLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).EndInit();
            this.UnderItemGridLayout.ResumeLayout(false);
            this.UnderItemGridLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        protected System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TableLayoutPanel TruckEditorControlsLayout;
        private System.Windows.Forms.TableLayoutPanel CityListLayout;
        private System.Windows.Forms.DataGridView ItemGridView;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.TableLayoutPanel UnderItemGridLayout;
        private System.Windows.Forms.NumericUpDown ItemQuantityBox;
        private System.Windows.Forms.ComboBox ItemsBox;
        private System.Windows.Forms.Button UpdateButton;
    }
}