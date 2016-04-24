namespace IceCreamManager.View
{
    partial class TruckEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TruckEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.TruckEditorControlsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CityListLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ItemGridView = new System.Windows.Forms.DataGridView();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.ItemRemovalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WasteNumberBox = new System.Windows.Forms.NumericUpDown();
            this.SaleButton = new System.Windows.Forms.Button();
            this.SaleNumberBox = new System.Windows.Forms.NumericUpDown();
            this.WasteButton = new System.Windows.Forms.Button();
            this.StockTruckButton = new System.Windows.Forms.Button();
            this.UnderItemGridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ItemQuantityBox = new System.Windows.Forms.NumericUpDown();
            this.ItemBox = new System.Windows.Forms.ComboBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.FuelRateLabel = new System.Windows.Forms.Label();
            this.FuelRateBox = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RouteBox = new System.Windows.Forms.ComboBox();
            this.RouteLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DriverLabel = new System.Windows.Forms.Label();
            this.DriverBox = new System.Windows.Forms.ComboBox();
            this.TruckNumberLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.NumberBox = new System.Windows.Forms.NumericUpDown();
            this.TruckEditorToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.TruckEditorControlsLayout.SuspendLayout();
            this.CityListLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).BeginInit();
            this.ItemRemovalLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WasteNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleNumberBox)).BeginInit();
            this.UnderItemGridLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantityBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuelRateBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TruckNumberLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormLayout
            // 
            this.FormLayout.AutoSize = true;
            this.FormLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormLayout.ColumnCount = 2;
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FormLayout.Controls.Add(this.ButtonLayout, 1, 1);
            this.FormLayout.Controls.Add(this.TruckEditorControlsLayout, 1, 0);
            this.FormLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 2;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.Size = new System.Drawing.Size(556, 402);
            this.FormLayout.TabIndex = 5;
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonLayout.AutoSize = true;
            this.ButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonLayout.ColumnCount = 2;
            this.FormLayout.SetColumnSpan(this.ButtonLayout, 2);
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.Controls.Add(this.SaveButton, 0, 0);
            this.ButtonLayout.Controls.Add(this.DiscardButton, 1, 0);
            this.ButtonLayout.Location = new System.Drawing.Point(391, 362);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            // TruckEditorControlsLayout
            // 
            this.TruckEditorControlsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TruckEditorControlsLayout.ColumnCount = 1;
            this.TruckEditorControlsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TruckEditorControlsLayout.Controls.Add(this.CityListLayout, 0, 0);
            this.TruckEditorControlsLayout.Controls.Add(this.UnderItemGridLayout, 0, 1);
            this.TruckEditorControlsLayout.Location = new System.Drawing.Point(269, 3);
            this.TruckEditorControlsLayout.Name = "TruckEditorControlsLayout";
            this.TruckEditorControlsLayout.RowCount = 2;
            this.TruckEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TruckEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TruckEditorControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TruckEditorControlsLayout.Size = new System.Drawing.Size(284, 353);
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
            this.CityListLayout.Controls.Add(this.ItemRemovalLayout, 0, 2);
            this.CityListLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CityListLayout.Location = new System.Drawing.Point(3, 3);
            this.CityListLayout.Name = "CityListLayout";
            this.CityListLayout.RowCount = 3;
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityListLayout.Size = new System.Drawing.Size(278, 309);
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
            this.ItemGridView.Size = new System.Drawing.Size(272, 247);
            this.ItemGridView.TabIndex = 1;
            this.ItemGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemGridView_CellClick);
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
            // ItemRemovalLayout
            // 
            this.ItemRemovalLayout.AutoSize = true;
            this.ItemRemovalLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ItemRemovalLayout.ColumnCount = 5;
            this.ItemRemovalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemRemovalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemRemovalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemRemovalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemRemovalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemRemovalLayout.Controls.Add(this.WasteNumberBox, 2, 0);
            this.ItemRemovalLayout.Controls.Add(this.SaleButton, 1, 0);
            this.ItemRemovalLayout.Controls.Add(this.SaleNumberBox, 0, 0);
            this.ItemRemovalLayout.Controls.Add(this.WasteButton, 3, 0);
            this.ItemRemovalLayout.Controls.Add(this.StockTruckButton, 4, 0);
            this.ItemRemovalLayout.Location = new System.Drawing.Point(3, 275);
            this.ItemRemovalLayout.Name = "ItemRemovalLayout";
            this.ItemRemovalLayout.RowCount = 1;
            this.ItemRemovalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ItemRemovalLayout.Size = new System.Drawing.Size(264, 32);
            this.ItemRemovalLayout.TabIndex = 3;
            // 
            // WasteNumberBox
            // 
            this.WasteNumberBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WasteNumberBox.Location = new System.Drawing.Point(93, 6);
            this.WasteNumberBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.WasteNumberBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.WasteNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WasteNumberBox.Name = "WasteNumberBox";
            this.WasteNumberBox.Size = new System.Drawing.Size(56, 20);
            this.WasteNumberBox.TabIndex = 6;
            this.WasteNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.WasteNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SaleButton
            // 
            this.SaleButton.FlatAppearance.BorderSize = 0;
            this.SaleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaleButton.Image = global::IceCreamManager.Properties.Resources.Sell;
            this.SaleButton.Location = new System.Drawing.Point(65, 3);
            this.SaleButton.Name = "SaleButton";
            this.SaleButton.Size = new System.Drawing.Size(22, 22);
            this.SaleButton.TabIndex = 6;
            this.TruckEditorToolTips.SetToolTip(this.SaleButton, "!Sell Item");
            this.SaleButton.UseVisualStyleBackColor = true;
            this.SaleButton.Click += new System.EventHandler(this.SaleButton_Click);
            // 
            // SaleNumberBox
            // 
            this.SaleNumberBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SaleNumberBox.Location = new System.Drawing.Point(3, 6);
            this.SaleNumberBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.SaleNumberBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SaleNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SaleNumberBox.Name = "SaleNumberBox";
            this.SaleNumberBox.Size = new System.Drawing.Size(56, 20);
            this.SaleNumberBox.TabIndex = 6;
            this.SaleNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SaleNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WasteButton
            // 
            this.WasteButton.FlatAppearance.BorderSize = 0;
            this.WasteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WasteButton.Image = global::IceCreamManager.Properties.Resources.Waste;
            this.WasteButton.Location = new System.Drawing.Point(158, 3);
            this.WasteButton.Name = "WasteButton";
            this.WasteButton.Size = new System.Drawing.Size(22, 22);
            this.WasteButton.TabIndex = 7;
            this.TruckEditorToolTips.SetToolTip(this.WasteButton, "!Waste Item");
            this.WasteButton.UseVisualStyleBackColor = true;
            this.WasteButton.Click += new System.EventHandler(this.WasteButton_Click);
            // 
            // StockTruckButton
            // 
            this.StockTruckButton.Location = new System.Drawing.Point(186, 3);
            this.StockTruckButton.Name = "StockTruckButton";
            this.StockTruckButton.Size = new System.Drawing.Size(75, 23);
            this.StockTruckButton.TabIndex = 8;
            this.StockTruckButton.Text = "!Stock";
            this.StockTruckButton.UseVisualStyleBackColor = true;
            this.StockTruckButton.Click += new System.EventHandler(this.StockTruckButton_Click);
            // 
            // UnderItemGridLayout
            // 
            this.UnderItemGridLayout.AutoSize = true;
            this.UnderItemGridLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UnderItemGridLayout.ColumnCount = 3;
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.UnderItemGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.UnderItemGridLayout.Controls.Add(this.ItemQuantityBox, 1, 0);
            this.UnderItemGridLayout.Controls.Add(this.ItemBox, 0, 0);
            this.UnderItemGridLayout.Controls.Add(this.UpdateButton, 2, 0);
            this.UnderItemGridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnderItemGridLayout.Location = new System.Drawing.Point(3, 318);
            this.UnderItemGridLayout.Name = "UnderItemGridLayout";
            this.UnderItemGridLayout.RowCount = 1;
            this.UnderItemGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.UnderItemGridLayout.Size = new System.Drawing.Size(278, 32);
            this.UnderItemGridLayout.TabIndex = 2;
            // 
            // ItemQuantityBox
            // 
            this.ItemQuantityBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemQuantityBox.Location = new System.Drawing.Point(135, 6);
            this.ItemQuantityBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.ItemQuantityBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ItemQuantityBox.Name = "ItemQuantityBox";
            this.ItemQuantityBox.Size = new System.Drawing.Size(56, 20);
            this.ItemQuantityBox.TabIndex = 6;
            this.ItemQuantityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ItemBox
            // 
            this.ItemBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.Location = new System.Drawing.Point(3, 5);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(126, 21);
            this.ItemBox.TabIndex = 0;
            this.ItemBox.SelectionChangeCommitted += new System.EventHandler(this.ItemBox_SelectionChangeCommitted);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(200, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "!Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TruckNumberLayout, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 142);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.FuelRateLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.FuelRateBox, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 107);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(130, 32);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // FuelRateLabel
            // 
            this.FuelRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FuelRateLabel.AutoSize = true;
            this.FuelRateLabel.Location = new System.Drawing.Point(6, 9);
            this.FuelRateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.FuelRateLabel.Name = "FuelRateLabel";
            this.FuelRateLabel.Size = new System.Drawing.Size(56, 13);
            this.FuelRateLabel.TabIndex = 0;
            this.FuelRateLabel.Text = "!Fuel Rate";
            // 
            // FuelRateBox
            // 
            this.FuelRateBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FuelRateBox.DecimalPlaces = 2;
            this.FuelRateBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.FuelRateBox.Location = new System.Drawing.Point(68, 6);
            this.FuelRateBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.FuelRateBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.FuelRateBox.Name = "FuelRateBox";
            this.FuelRateBox.Size = new System.Drawing.Size(56, 20);
            this.FuelRateBox.TabIndex = 1;
            this.FuelRateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FuelRateBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.RouteBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.RouteLabel, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 74);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(254, 27);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // RouteBox
            // 
            this.RouteBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RouteBox.FormattingEnabled = true;
            this.RouteBox.Location = new System.Drawing.Point(51, 3);
            this.RouteBox.Name = "RouteBox";
            this.RouteBox.Size = new System.Drawing.Size(200, 21);
            this.RouteBox.TabIndex = 6;
            // 
            // RouteLabel
            // 
            this.RouteLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RouteLabel.AutoSize = true;
            this.RouteLabel.Location = new System.Drawing.Point(6, 7);
            this.RouteLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.RouteLabel.Name = "RouteLabel";
            this.RouteLabel.Size = new System.Drawing.Size(39, 13);
            this.RouteLabel.TabIndex = 0;
            this.RouteLabel.Text = "!Route";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.DriverLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DriverBox, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(253, 27);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // DriverLabel
            // 
            this.DriverLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DriverLabel.AutoSize = true;
            this.DriverLabel.Location = new System.Drawing.Point(6, 7);
            this.DriverLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.DriverLabel.Name = "DriverLabel";
            this.DriverLabel.Size = new System.Drawing.Size(38, 13);
            this.DriverLabel.TabIndex = 0;
            this.DriverLabel.Text = "!Driver";
            // 
            // DriverBox
            // 
            this.DriverBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriverBox.FormattingEnabled = true;
            this.DriverBox.Location = new System.Drawing.Point(50, 3);
            this.DriverBox.Name = "DriverBox";
            this.DriverBox.Size = new System.Drawing.Size(200, 21);
            this.DriverBox.TabIndex = 1;
            // 
            // TruckNumberLayout
            // 
            this.TruckNumberLayout.AutoSize = true;
            this.TruckNumberLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TruckNumberLayout.ColumnCount = 2;
            this.TruckNumberLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TruckNumberLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TruckNumberLayout.Controls.Add(this.NumberLabel, 0, 0);
            this.TruckNumberLayout.Controls.Add(this.NumberBox, 1, 0);
            this.TruckNumberLayout.Location = new System.Drawing.Point(3, 3);
            this.TruckNumberLayout.Name = "TruckNumberLayout";
            this.TruckNumberLayout.RowCount = 1;
            this.TruckNumberLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TruckNumberLayout.Size = new System.Drawing.Size(121, 32);
            this.TruckNumberLayout.TabIndex = 0;
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
            // TruckEditor
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(580, 418);
            this.Controls.Add(this.FormLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TruckEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!Truck Editor";
            this.Shown += new System.EventHandler(this.TruckEditor_Shown);
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.TruckEditorControlsLayout.ResumeLayout(false);
            this.TruckEditorControlsLayout.PerformLayout();
            this.CityListLayout.ResumeLayout(false);
            this.CityListLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).EndInit();
            this.ItemRemovalLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WasteNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleNumberBox)).EndInit();
            this.UnderItemGridLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantityBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuelRateBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.TruckNumberLayout.ResumeLayout(false);
            this.TruckNumberLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        public System.Windows.Forms.Button SaveButton;
        protected System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.TableLayoutPanel TruckEditorControlsLayout;
        private System.Windows.Forms.TableLayoutPanel TruckNumberLayout;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.NumericUpDown NumberBox;
        private System.Windows.Forms.TableLayoutPanel CityListLayout;
        private System.Windows.Forms.DataGridView ItemGridView;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.TableLayoutPanel UnderItemGridLayout;
        private System.Windows.Forms.ComboBox ItemBox;
        private System.Windows.Forms.TableLayoutPanel ItemRemovalLayout;
        private System.Windows.Forms.Button WasteButton;
        private System.Windows.Forms.Button SaleButton;
        private System.Windows.Forms.NumericUpDown WasteNumberBox;
        private System.Windows.Forms.NumericUpDown SaleNumberBox;
        private System.Windows.Forms.NumericUpDown ItemQuantityBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label FuelRateLabel;
        private System.Windows.Forms.NumericUpDown FuelRateBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox RouteBox;
        private System.Windows.Forms.Label RouteLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label DriverLabel;
        private System.Windows.Forms.ComboBox DriverBox;
        private System.Windows.Forms.ToolTip TruckEditorToolTips;
        private System.Windows.Forms.Button StockTruckButton;
        private System.Windows.Forms.Button UpdateButton;
    }
}