namespace IceCreamManager.View
{
    partial class RouteEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.RouteEditorControlsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.RouteNumberLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.NumberBox = new System.Windows.Forms.NumericUpDown();
            this.CityListLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CityGridView = new System.Windows.Forms.DataGridView();
            this.CitiesLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CitiesBox = new System.Windows.Forms.ComboBox();
            this.AddCityButton = new System.Windows.Forms.Button();
            this.RemoveCityButton = new System.Windows.Forms.Button();
            this.RouteEditorToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.RouteEditorControlsLayout.SuspendLayout();
            this.RouteNumberLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).BeginInit();
            this.CityListLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CityGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.FormLayout.Controls.Add(this.RouteEditorControlsLayout, 0, 0);
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 2;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.Size = new System.Drawing.Size(298, 396);
            this.FormLayout.TabIndex = 4;
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
            this.ButtonLayout.Location = new System.Drawing.Point(133, 356);
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
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            // RouteEditorControlsLayout
            // 
            this.RouteEditorControlsLayout.AutoSize = true;
            this.RouteEditorControlsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RouteEditorControlsLayout.ColumnCount = 1;
            this.RouteEditorControlsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RouteEditorControlsLayout.Controls.Add(this.RouteNumberLayout, 0, 0);
            this.RouteEditorControlsLayout.Controls.Add(this.CityListLayout, 0, 1);
            this.RouteEditorControlsLayout.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.RouteEditorControlsLayout.Location = new System.Drawing.Point(3, 3);
            this.RouteEditorControlsLayout.Name = "RouteEditorControlsLayout";
            this.RouteEditorControlsLayout.RowCount = 3;
            this.RouteEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RouteEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RouteEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RouteEditorControlsLayout.Size = new System.Drawing.Size(292, 347);
            this.RouteEditorControlsLayout.TabIndex = 3;
            // 
            // RouteNumberLayout
            // 
            this.RouteNumberLayout.AutoSize = true;
            this.RouteNumberLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RouteNumberLayout.ColumnCount = 2;
            this.RouteNumberLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RouteNumberLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RouteNumberLayout.Controls.Add(this.NumberLabel, 0, 0);
            this.RouteNumberLayout.Controls.Add(this.NumberBox, 1, 0);
            this.RouteNumberLayout.Location = new System.Drawing.Point(3, 3);
            this.RouteNumberLayout.Name = "RouteNumberLayout";
            this.RouteNumberLayout.RowCount = 1;
            this.RouteNumberLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RouteNumberLayout.Size = new System.Drawing.Size(121, 32);
            this.RouteNumberLayout.TabIndex = 0;
            // 
            // NumberLabel
            // 
            this.NumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(6, 9);
            this.NumberLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(47, 13);
            this.NumberLabel.TabIndex = 0;
            this.NumberLabel.Text = "!Number";
            // 
            // NumberBox
            // 
            this.NumberBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumberBox.Location = new System.Drawing.Point(59, 6);
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
            this.NumberBox.Size = new System.Drawing.Size(56, 20);
            this.NumberBox.TabIndex = 1;
            this.NumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CityListLayout
            // 
            this.CityListLayout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CityListLayout.AutoSize = true;
            this.CityListLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CityListLayout.ColumnCount = 1;
            this.CityListLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CityListLayout.Controls.Add(this.CityGridView, 0, 1);
            this.CityListLayout.Controls.Add(this.CitiesLabel, 0, 0);
            this.CityListLayout.Location = new System.Drawing.Point(3, 41);
            this.CityListLayout.Name = "CityListLayout";
            this.CityListLayout.RowCount = 2;
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CityListLayout.Size = new System.Drawing.Size(286, 269);
            this.CityListLayout.TabIndex = 1;
            // 
            // CityGridView
            // 
            this.CityGridView.AllowUserToAddRows = false;
            this.CityGridView.AllowUserToDeleteRows = false;
            this.CityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CityGridView.Location = new System.Drawing.Point(3, 22);
            this.CityGridView.Name = "CityGridView";
            this.CityGridView.ReadOnly = true;
            this.CityGridView.Size = new System.Drawing.Size(280, 244);
            this.CityGridView.TabIndex = 1;
            // 
            // CitiesLabel
            // 
            this.CitiesLabel.AutoSize = true;
            this.CitiesLabel.Location = new System.Drawing.Point(6, 6);
            this.CitiesLabel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.CitiesLabel.Name = "CitiesLabel";
            this.CitiesLabel.Size = new System.Drawing.Size(35, 13);
            this.CitiesLabel.TabIndex = 2;
            this.CitiesLabel.Text = "!Cities";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.CitiesBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddCityButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RemoveCityButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 316);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 28);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // CitiesBox
            // 
            this.CitiesBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CitiesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CitiesBox.FormattingEnabled = true;
            this.CitiesBox.Location = new System.Drawing.Point(3, 3);
            this.CitiesBox.Name = "CitiesBox";
            this.CitiesBox.Size = new System.Drawing.Size(224, 21);
            this.CitiesBox.TabIndex = 0;
            // 
            // AddCityButton
            // 
            this.AddCityButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddCityButton.FlatAppearance.BorderSize = 0;
            this.AddCityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCityButton.Image = global::IceCreamManager.Properties.Resources.Add;
            this.AddCityButton.Location = new System.Drawing.Point(233, 3);
            this.AddCityButton.Name = "AddCityButton";
            this.AddCityButton.Size = new System.Drawing.Size(22, 22);
            this.AddCityButton.TabIndex = 1;
            this.RouteEditorToolTips.SetToolTip(this.AddCityButton, "!Add City");
            this.AddCityButton.UseVisualStyleBackColor = true;
            this.AddCityButton.Click += new System.EventHandler(this.AddCityButton_Click);
            // 
            // RemoveCityButton
            // 
            this.RemoveCityButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RemoveCityButton.FlatAppearance.BorderSize = 0;
            this.RemoveCityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveCityButton.Image = global::IceCreamManager.Properties.Resources.Remove;
            this.RemoveCityButton.Location = new System.Drawing.Point(261, 3);
            this.RemoveCityButton.Name = "RemoveCityButton";
            this.RemoveCityButton.Size = new System.Drawing.Size(22, 22);
            this.RemoveCityButton.TabIndex = 2;
            this.RouteEditorToolTips.SetToolTip(this.RemoveCityButton, "!Remove City");
            this.RemoveCityButton.UseVisualStyleBackColor = true;
            this.RemoveCityButton.Click += new System.EventHandler(this.RemoveCityButton_Click);
            // 
            // RouteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(321, 428);
            this.Controls.Add(this.FormLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RouteEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!RouteEditor";
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.RouteEditorControlsLayout.ResumeLayout(false);
            this.RouteEditorControlsLayout.PerformLayout();
            this.RouteNumberLayout.ResumeLayout(false);
            this.RouteNumberLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).EndInit();
            this.CityListLayout.ResumeLayout(false);
            this.CityListLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CityGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        public System.Windows.Forms.Button SaveButton;
        protected System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.TableLayoutPanel RouteEditorControlsLayout;
        private System.Windows.Forms.TableLayoutPanel RouteNumberLayout;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.NumericUpDown NumberBox;
        private System.Windows.Forms.TableLayoutPanel CityListLayout;
        private System.Windows.Forms.DataGridView CityGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox CitiesBox;
        private System.Windows.Forms.Button AddCityButton;
        private System.Windows.Forms.Button RemoveCityButton;
        private System.Windows.Forms.ToolTip RouteEditorToolTips;
        private System.Windows.Forms.Label CitiesLabel;
    }
}