namespace IceCreamManager.View
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.RevenueTab = new System.Windows.Forms.TabPage();
            this.RevenueTabs = new System.Windows.Forms.TabControl();
            this.OverallRevenueTab = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SalesTab = new System.Windows.Forms.TabPage();
            this.ItemWasteTab = new System.Windows.Forms.TabPage();
            this.SalaryCostTab = new System.Windows.Forms.TabPage();
            this.FuelUsageTab = new System.Windows.Forms.TabPage();
            this.BatchTab = new System.Windows.Forms.TabPage();
            this.TrucksTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveTruckButton = new System.Windows.Forms.Button();
            this.ShowDeletedTrucks = new System.Windows.Forms.CheckBox();
            this.TruckGridView = new System.Windows.Forms.DataGridView();
            this.AddTruckButton = new System.Windows.Forms.Button();
            this.EditTruckButton = new System.Windows.Forms.Button();
            this.ItemsTab = new System.Windows.Forms.TabPage();
            this.ItemLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.ItemGridView = new System.Windows.Forms.DataGridView();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.ShowDeletedItems = new System.Windows.Forms.CheckBox();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.DriversTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DriverGridView = new System.Windows.Forms.DataGridView();
            this.RemoveDriverButton = new System.Windows.Forms.Button();
            this.ShowDeletedDrivers = new System.Windows.Forms.CheckBox();
            this.AddDriverButton = new System.Windows.Forms.Button();
            this.EditDriverButton = new System.Windows.Forms.Button();
            this.RoutesTab = new System.Windows.Forms.TabPage();
            this.RoutesLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveRouteButton = new System.Windows.Forms.Button();
            this.ShowDeletedRoutes = new System.Windows.Forms.CheckBox();
            this.RouteGridView = new System.Windows.Forms.DataGridView();
            this.AddRouteButton = new System.Windows.Forms.Button();
            this.EditRouteButton = new System.Windows.Forms.Button();
            this.CitiesTab = new System.Windows.Forms.TabPage();
            this.CityLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveCityButton = new System.Windows.Forms.Button();
            this.ShowDeletedCities = new System.Windows.Forms.CheckBox();
            this.CityGridView = new System.Windows.Forms.DataGridView();
            this.AddCityButton = new System.Windows.Forms.Button();
            this.EditCityButton = new System.Windows.Forms.Button();
            this.ButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ExtraButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.MainFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DefaultInventoryButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainTabs.SuspendLayout();
            this.RevenueTab.SuspendLayout();
            this.RevenueTabs.SuspendLayout();
            this.OverallRevenueTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.TrucksTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TruckGridView)).BeginInit();
            this.ItemsTab.SuspendLayout();
            this.ItemLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).BeginInit();
            this.DriversTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriverGridView)).BeginInit();
            this.RoutesTab.SuspendLayout();
            this.RoutesLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RouteGridView)).BeginInit();
            this.CitiesTab.SuspendLayout();
            this.CityLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CityGridView)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.ExtraButtonsLayout.SuspendLayout();
            this.MainFormLayout.SuspendLayout();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.salesButton = new System.Windows.Forms.ToolStripButton();
            this.batchButton = new System.Windows.Forms.ToolStripButton();
            this.zonesSectionSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.zonesButton = new System.Windows.Forms.ToolStripButton();
            this.routesButton = new System.Windows.Forms.ToolStripButton();
            this.trucksSectionSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.trucksButton = new System.Windows.Forms.ToolStripButton();
            this.driversButton = new System.Windows.Forms.ToolStripButton();
            this.fuelUsageButton = new System.Windows.Forms.ToolStripButton();
            this.itemsSectionSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.itemsButton = new System.Windows.Forms.ToolStripButton();
            this.presetsButton = new System.Windows.Forms.ToolStripButton();
            this.votingButton = new System.Windows.Forms.ToolStripButton();
            this.settingsSectionSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.helpButtonSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainStatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesButton,
            this.batchButton,
            this.zonesSectionSeperator,
            this.zonesButton,
            this.routesButton,
            this.trucksSectionSeperator,
            this.trucksButton,
            this.driversButton,
            this.fuelUsageButton,
            this.itemsSectionSeperator,
            this.itemsButton,
            this.presetsButton,
            this.votingButton,
            this.settingsSectionSeperator,
            this.settingsButton,
            this.aboutButton,
            this.helpButtonSeparator,
            this.helpButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(884, 55);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            this.MainTabs.Controls.Add(this.RevenueTab);
            this.MainTabs.Controls.Add(this.BatchTab);
            this.MainTabs.Controls.Add(this.TrucksTab);
            this.MainTabs.Controls.Add(this.ItemsTab);
            this.MainTabs.Controls.Add(this.DriversTab);
            this.MainTabs.Controls.Add(this.RoutesTab);
            this.MainTabs.Controls.Add(this.CitiesTab);
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabs.ImageList = this.ButtonIcons;
            this.MainTabs.Location = new System.Drawing.Point(0, 0);
            this.MainTabs.Margin = new System.Windows.Forms.Padding(0);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.Padding = new System.Drawing.Point(8, 8);
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(784, 486);
            this.MainTabs.TabIndex = 0;
            // 
            // salesButton
            // 
            this.salesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salesButton.Image = global::IceCreamManager.Properties.Resources.SalesButton;
            this.salesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salesButton.Name = "salesButton";
            this.salesButton.Size = new System.Drawing.Size(52, 52);
            this.salesButton.Text = "Sales";
            this.salesButton.Click += new System.EventHandler(this.salesButton_Click);
            // 
            // batchButton
            // 
            this.batchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.batchButton.Image = global::IceCreamManager.Properties.Resources.BatchButton;
            this.batchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.batchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.batchButton.Name = "batchButton";
            this.batchButton.Size = new System.Drawing.Size(52, 52);
            this.batchButton.Text = "Batch";
            this.batchButton.Click += new System.EventHandler(this.batchButton_Click);
            // 
            // zonesSectionSeperator
            // 
            this.zonesSectionSeperator.Name = "zonesSectionSeperator";
            this.zonesSectionSeperator.Size = new System.Drawing.Size(6, 55);
            // 
            // zonesButton
            // 
            this.zonesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zonesButton.Image = global::IceCreamManager.Properties.Resources.ZonesButton;
            this.zonesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.zonesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zonesButton.Name = "zonesButton";
            this.zonesButton.Size = new System.Drawing.Size(52, 52);
            this.zonesButton.Text = "Zones";
            this.zonesButton.Click += new System.EventHandler(this.zonesButton_Click);
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(756, 411);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // routesButton
            // 
            this.routesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.routesButton.Image = global::IceCreamManager.Properties.Resources.RoutesButton;
            this.routesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.routesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.routesButton.Name = "routesButton";
            this.routesButton.Size = new System.Drawing.Size(52, 52);
            this.routesButton.Text = "Routes";
            this.routesButton.Click += new System.EventHandler(this.routesButton_Click);
            // 
            // trucksSectionSeperator
            // 
            this.trucksSectionSeperator.Name = "trucksSectionSeperator";
            this.trucksSectionSeperator.Size = new System.Drawing.Size(6, 55);
            // 
            // trucksButton
            // 
            this.trucksButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.trucksButton.Image = global::IceCreamManager.Properties.Resources.TruckButton;
            this.trucksButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trucksButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trucksButton.Name = "trucksButton";
            this.trucksButton.Size = new System.Drawing.Size(52, 52);
            this.trucksButton.Text = "Trucks";
            this.trucksButton.Click += new System.EventHandler(this.trucksButton_Click);
            // 
            // driversButton
            // 
            this.driversButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.driversButton.Image = global::IceCreamManager.Properties.Resources.DriversButton;
            this.driversButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.driversButton.Name = "driversButton";
            this.driversButton.Size = new System.Drawing.Size(52, 52);
            this.driversButton.Text = "Drivers";
            this.driversButton.Click += new System.EventHandler(this.driversButton_Click);
            // 
            // BatchTab
            // 
            this.BatchTab.ImageIndex = 7;
            this.BatchTab.Location = new System.Drawing.Point(4, 33);
            this.BatchTab.Name = "BatchTab";
            this.BatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.BatchTab.Size = new System.Drawing.Size(776, 449);
            this.BatchTab.TabIndex = 6;
            this.BatchTab.Text = "!Batch";
            this.BatchTab.UseVisualStyleBackColor = true;
            // 
            // TrucksTab
            // 
            this.fuelUsageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fuelUsageButton.Image = global::IceCreamManager.Properties.Resources.FuelButton;
            this.fuelUsageButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fuelUsageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fuelUsageButton.Name = "fuelUsageButton";
            this.fuelUsageButton.Size = new System.Drawing.Size(52, 52);
            this.fuelUsageButton.Text = "Fuel Usage";
            this.fuelUsageButton.Click += new System.EventHandler(this.fuelUsageButton_Click);
            this.TrucksTab.Controls.Add(this.tableLayoutPanel2);
            this.TrucksTab.ImageIndex = 5;
            this.TrucksTab.Location = new System.Drawing.Point(4, 33);
            this.TrucksTab.Name = "TrucksTab";
            this.TrucksTab.Padding = new System.Windows.Forms.Padding(3);
            this.TrucksTab.Size = new System.Drawing.Size(776, 449);
            this.TrucksTab.TabIndex = 1;
            this.TrucksTab.Text = "!Trucks";
            this.TrucksTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.DefaultInventoryButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.RemoveTruckButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.TruckGridView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.AddTruckButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EditTruckButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ShowDeletedTrucks, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 443);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // RemoveTruckButton
            // 
            this.RemoveTruckButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RemoveTruckButton.AutoSize = true;
            this.RemoveTruckButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveTruckButton.Location = new System.Drawing.Point(165, 3);
            this.RemoveTruckButton.Name = "RemoveTruckButton";
            this.RemoveTruckButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.RemoveTruckButton.Size = new System.Drawing.Size(75, 29);
            this.RemoveTruckButton.TabIndex = 2;
            this.RemoveTruckButton.Text = "!Remove";
            this.RemoveTruckButton.UseVisualStyleBackColor = true;
            this.RemoveTruckButton.Click += new System.EventHandler(this.RemoveTruckButton_Click);
            // 
            // ShowDeletedTrucks
            // 
            this.ShowDeletedTrucks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ShowDeletedTrucks.AutoSize = true;
            this.ShowDeletedTrucks.Location = new System.Drawing.Point(355, 9);
            this.ShowDeletedTrucks.Name = "ShowDeletedTrucks";
            this.ShowDeletedTrucks.Size = new System.Drawing.Size(96, 17);
            this.ShowDeletedTrucks.TabIndex = 3;
            this.ShowDeletedTrucks.Text = "!Show Deleted";
            this.ShowDeletedTrucks.UseVisualStyleBackColor = true;
            this.ShowDeletedTrucks.CheckedChanged += new System.EventHandler(this.RefreshTruckTable);
            // 
            // TruckGridView
            // 
            this.TruckGridView.AllowUserToAddRows = false;
            this.TruckGridView.AllowUserToDeleteRows = false;
            this.TruckGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TruckGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel2.SetColumnSpan(this.TruckGridView, 5);
            this.TruckGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TruckGridView.Location = new System.Drawing.Point(3, 38);
            this.TruckGridView.MultiSelect = false;
            this.TruckGridView.Name = "TruckGridView";
            this.TruckGridView.ReadOnly = true;
            this.TruckGridView.RowHeadersVisible = false;
            this.TruckGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TruckGridView.Size = new System.Drawing.Size(764, 402);
            this.TruckGridView.TabIndex = 4;
            // 
            // AddTruckButton
            // 
            this.AddTruckButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddTruckButton.AutoSize = true;
            this.AddTruckButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddTruckButton.Location = new System.Drawing.Point(3, 3);
            this.AddTruckButton.Name = "AddTruckButton";
            this.AddTruckButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.AddTruckButton.Size = new System.Drawing.Size(75, 29);
            this.AddTruckButton.TabIndex = 1;
            this.AddTruckButton.Text = "!Add";
            this.AddTruckButton.UseVisualStyleBackColor = true;
            this.AddTruckButton.Click += new System.EventHandler(this.AddTruckButton_Click);
            // 
            // EditTruckButton
            // 
            this.EditTruckButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditTruckButton.AutoSize = true;
            this.EditTruckButton.Location = new System.Drawing.Point(84, 3);
            this.EditTruckButton.Name = "EditTruckButton";
            this.EditTruckButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.EditTruckButton.Size = new System.Drawing.Size(75, 29);
            this.EditTruckButton.TabIndex = 0;
            this.EditTruckButton.Text = "!Edit";
            this.EditTruckButton.UseVisualStyleBackColor = true;
            this.EditTruckButton.Click += new System.EventHandler(this.EditTruckButton_Click);
            // 
            // ItemsTab
            // 
            this.itemsSectionSeperator.Name = "itemsSectionSeperator";
            this.itemsSectionSeperator.Size = new System.Drawing.Size(6, 55);
            // 
            // itemsButton
            // 
            this.itemsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.itemsButton.Image = global::IceCreamManager.Properties.Resources.ItemsButton;
            this.itemsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itemsButton.Name = "itemsButton";
            this.itemsButton.Size = new System.Drawing.Size(52, 52);
            this.itemsButton.Text = "Items";
            this.itemsButton.Click += new System.EventHandler(this.itemsButton_Click);
            // 
            // presetsButton
            // 
            this.presetsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.presetsButton.Image = global::IceCreamManager.Properties.Resources.PresetsButton;
            this.presetsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.presetsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.presetsButton.Name = "presetsButton";
            this.presetsButton.Size = new System.Drawing.Size(52, 52);
            this.presetsButton.Text = "Presets";
            this.presetsButton.Click += new System.EventHandler(this.presetsButton_Click);
            // 
            // votingButton
            // 
            this.votingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.votingButton.Image = global::IceCreamManager.Properties.Resources.VotingButton;
            this.votingButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.votingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.votingButton.Name = "votingButton";
            this.votingButton.Size = new System.Drawing.Size(52, 52);
            this.votingButton.Text = "Voting";
            this.votingButton.Click += new System.EventHandler(this.votingButton_Click);
            // 
            // settingsSectionSeperator
            // 
            this.settingsSectionSeperator.Name = "settingsSectionSeperator";
            this.settingsSectionSeperator.Size = new System.Drawing.Size(6, 55);
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Image = global::IceCreamManager.Properties.Resources.SettingsButton;
            this.settingsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(52, 52);
            this.settingsButton.Text = "Settings";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutButton.Image = global::IceCreamManager.Properties.Resources.AboutButton;
            this.aboutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(52, 52);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // helpButtonSeparator
            // 
            this.helpButtonSeparator.Name = "helpButtonSeparator";
            this.helpButtonSeparator.Size = new System.Drawing.Size(6, 55);
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpButton.Image = global::IceCreamManager.Properties.Resources.HelpButton;
            this.helpButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(36, 52);
            this.helpButton.Text = "Help";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel,
            this.mainStatusProgressBar});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 639);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(884, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            this.RemoveDriverButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RemoveDriverButton.AutoSize = true;
            this.RemoveDriverButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveDriverButton.Location = new System.Drawing.Point(165, 3);
            this.RemoveDriverButton.Name = "RemoveDriverButton";
            this.RemoveDriverButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.RemoveDriverButton.Size = new System.Drawing.Size(75, 29);
            this.RemoveDriverButton.TabIndex = 2;
            this.RemoveDriverButton.Text = "!Remove";
            this.RemoveDriverButton.UseVisualStyleBackColor = true;
            this.RemoveDriverButton.Click += new System.EventHandler(this.RemoveDriverButton_Click);
            // 
            // ShowDeletedDrivers
            // 
            this.ShowDeletedDrivers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ShowDeletedDrivers.AutoSize = true;
            this.ShowDeletedDrivers.Location = new System.Drawing.Point(246, 9);
            this.ShowDeletedDrivers.Name = "ShowDeletedDrivers";
            this.ShowDeletedDrivers.Size = new System.Drawing.Size(96, 17);
            this.ShowDeletedDrivers.TabIndex = 3;
            this.ShowDeletedDrivers.Text = "!Show Deleted";
            this.ShowDeletedDrivers.UseVisualStyleBackColor = true;
            this.ShowDeletedDrivers.CheckedChanged += new System.EventHandler(this.RefreshDriverTable);
            // 
            // AddDriverButton
            // 
            this.AddDriverButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddDriverButton.AutoSize = true;
            this.AddDriverButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddDriverButton.Location = new System.Drawing.Point(3, 3);
            this.AddDriverButton.Name = "AddDriverButton";
            this.AddDriverButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.AddDriverButton.Size = new System.Drawing.Size(75, 29);
            this.AddDriverButton.TabIndex = 1;
            this.AddDriverButton.Text = "!Add";
            this.AddDriverButton.UseVisualStyleBackColor = true;
            this.AddDriverButton.Click += new System.EventHandler(this.AddDriverButton_Click);
            // 
            // EditDriverButton
            // 
            this.EditDriverButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditDriverButton.AutoSize = true;
            this.EditDriverButton.Location = new System.Drawing.Point(84, 3);
            this.EditDriverButton.Name = "EditDriverButton";
            this.EditDriverButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.EditDriverButton.Size = new System.Drawing.Size(75, 29);
            this.EditDriverButton.TabIndex = 0;
            this.EditDriverButton.Text = "!Edit";
            this.EditDriverButton.UseVisualStyleBackColor = true;
            this.EditDriverButton.Click += new System.EventHandler(this.EditDriverButton_Click);
            // 
            // RoutesTab
            // 
            this.RoutesTab.Controls.Add(this.RoutesLayoutTable);
            this.RoutesTab.ImageIndex = 4;
            this.RoutesTab.Location = new System.Drawing.Point(4, 33);
            this.RoutesTab.Name = "RoutesTab";
            this.RoutesTab.Padding = new System.Windows.Forms.Padding(3);
            this.RoutesTab.Size = new System.Drawing.Size(776, 449);
            this.RoutesTab.TabIndex = 4;
            this.RoutesTab.Text = "!Routes";
            this.RoutesTab.UseVisualStyleBackColor = true;
            // 
            // RoutesLayoutTable
            // 
            this.RoutesLayoutTable.ColumnCount = 4;
            this.RoutesLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RoutesLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RoutesLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RoutesLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RoutesLayoutTable.Controls.Add(this.RemoveRouteButton, 2, 0);
            this.RoutesLayoutTable.Controls.Add(this.ShowDeletedRoutes, 3, 0);
            this.RoutesLayoutTable.Controls.Add(this.RouteGridView, 0, 1);
            this.RoutesLayoutTable.Controls.Add(this.AddRouteButton, 0, 0);
            this.RoutesLayoutTable.Controls.Add(this.EditRouteButton, 1, 0);
            this.RoutesLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoutesLayoutTable.Location = new System.Drawing.Point(3, 3);
            this.RoutesLayoutTable.Name = "RoutesLayoutTable";
            this.RoutesLayoutTable.RowCount = 2;
            this.RoutesLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RoutesLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RoutesLayoutTable.Size = new System.Drawing.Size(770, 443);
            this.RoutesLayoutTable.TabIndex = 2;
            // 
            // RemoveRouteButton
            // 
            this.RemoveRouteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RemoveRouteButton.AutoSize = true;
            this.RemoveRouteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveRouteButton.Location = new System.Drawing.Point(165, 3);
            this.RemoveRouteButton.Name = "RemoveRouteButton";
            this.RemoveRouteButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.RemoveRouteButton.Size = new System.Drawing.Size(75, 29);
            this.RemoveRouteButton.TabIndex = 2;
            this.RemoveRouteButton.Text = "!Remove";
            this.RemoveRouteButton.UseVisualStyleBackColor = true;
            this.RemoveRouteButton.Click += new System.EventHandler(this.RemoveRouteButton_Click);
            // 
            // ShowDeletedRoutes
            // 
            this.ShowDeletedRoutes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ShowDeletedRoutes.AutoSize = true;
            this.ShowDeletedRoutes.Location = new System.Drawing.Point(246, 9);
            this.ShowDeletedRoutes.Name = "ShowDeletedRoutes";
            this.ShowDeletedRoutes.Size = new System.Drawing.Size(96, 17);
            this.ShowDeletedRoutes.TabIndex = 3;
            this.ShowDeletedRoutes.Text = "!Show Deleted";
            this.ShowDeletedRoutes.UseVisualStyleBackColor = true;
            this.ShowDeletedRoutes.CheckedChanged += new System.EventHandler(this.RefreshRouteTable);
            // 
            // RouteGridView
            // 
            this.RouteGridView.AllowUserToAddRows = false;
            this.RouteGridView.AllowUserToDeleteRows = false;
            this.RouteGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RouteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoutesLayoutTable.SetColumnSpan(this.RouteGridView, 4);
            this.RouteGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteGridView.Location = new System.Drawing.Point(3, 38);
            this.RouteGridView.MultiSelect = false;
            this.RouteGridView.Name = "RouteGridView";
            this.RouteGridView.ReadOnly = true;
            this.RouteGridView.RowHeadersVisible = false;
            this.RouteGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RouteGridView.Size = new System.Drawing.Size(764, 402);
            this.RouteGridView.TabIndex = 4;
            // 
            // AddRouteButton
            // 
            this.AddRouteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddRouteButton.AutoSize = true;
            this.AddRouteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddRouteButton.Location = new System.Drawing.Point(3, 3);
            this.AddRouteButton.Name = "AddRouteButton";
            this.AddRouteButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.AddRouteButton.Size = new System.Drawing.Size(75, 29);
            this.AddRouteButton.TabIndex = 1;
            this.AddRouteButton.Text = "!Add";
            this.AddRouteButton.UseVisualStyleBackColor = true;
            this.AddRouteButton.Click += new System.EventHandler(this.AddRouteButton_Click);
            // 
            // EditRouteButton
            // 
            this.EditRouteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditRouteButton.AutoSize = true;
            this.EditRouteButton.Location = new System.Drawing.Point(84, 3);
            this.EditRouteButton.Name = "EditRouteButton";
            this.EditRouteButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.EditRouteButton.Size = new System.Drawing.Size(75, 29);
            this.EditRouteButton.TabIndex = 0;
            this.EditRouteButton.Text = "!Edit";
            this.EditRouteButton.UseVisualStyleBackColor = true;
            this.EditRouteButton.Click += new System.EventHandler(this.EditRouteButton_Click);
            // 
            // CitiesTab
            // 
            this.CitiesTab.Controls.Add(this.CityLayoutTable);
            this.CitiesTab.ImageIndex = 0;
            this.CitiesTab.Location = new System.Drawing.Point(4, 33);
            this.CitiesTab.Name = "CitiesTab";
            this.CitiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.CitiesTab.Size = new System.Drawing.Size(776, 449);
            this.CitiesTab.TabIndex = 5;
            this.CitiesTab.Text = "!Cities";
            this.CitiesTab.UseVisualStyleBackColor = true;
            // 
            // CityLayoutTable
            // 
            this.CityLayoutTable.ColumnCount = 4;
            this.CityLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CityLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CityLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CityLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CityLayoutTable.Controls.Add(this.RemoveCityButton, 2, 0);
            this.CityLayoutTable.Controls.Add(this.ShowDeletedCities, 3, 0);
            this.CityLayoutTable.Controls.Add(this.CityGridView, 0, 1);
            this.CityLayoutTable.Controls.Add(this.AddCityButton, 0, 0);
            this.CityLayoutTable.Controls.Add(this.EditCityButton, 1, 0);
            this.CityLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CityLayoutTable.Location = new System.Drawing.Point(3, 3);
            this.CityLayoutTable.Name = "CityLayoutTable";
            this.CityLayoutTable.RowCount = 2;
            this.CityLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CityLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CityLayoutTable.Size = new System.Drawing.Size(770, 443);
            this.CityLayoutTable.TabIndex = 2;
            // 
            // RemoveCityButton
            // 
            this.RemoveCityButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RemoveCityButton.AutoSize = true;
            this.RemoveCityButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveCityButton.Location = new System.Drawing.Point(165, 3);
            this.RemoveCityButton.Name = "RemoveCityButton";
            this.RemoveCityButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.RemoveCityButton.Size = new System.Drawing.Size(75, 29);
            this.RemoveCityButton.TabIndex = 2;
            this.RemoveCityButton.Text = "!Remove";
            this.RemoveCityButton.UseVisualStyleBackColor = true;
            this.RemoveCityButton.Click += new System.EventHandler(this.RemoveCityButton_Click);
            // 
            // ShowDeletedCities
            // 
            this.ShowDeletedCities.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ShowDeletedCities.AutoSize = true;
            this.ShowDeletedCities.Location = new System.Drawing.Point(246, 9);
            this.ShowDeletedCities.Name = "ShowDeletedCities";
            this.ShowDeletedCities.Size = new System.Drawing.Size(96, 17);
            this.ShowDeletedCities.TabIndex = 3;
            this.ShowDeletedCities.Text = "!Show Deleted";
            this.ShowDeletedCities.UseVisualStyleBackColor = true;
            this.ShowDeletedCities.CheckedChanged += new System.EventHandler(this.RefreshCityTable);
            // 
            // CityGridView
            // 
            this.CityGridView.AllowUserToAddRows = false;
            this.CityGridView.AllowUserToDeleteRows = false;
            this.CityGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CityLayoutTable.SetColumnSpan(this.CityGridView, 4);
            this.CityGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CityGridView.Location = new System.Drawing.Point(3, 38);
            this.CityGridView.MultiSelect = false;
            this.CityGridView.Name = "CityGridView";
            this.CityGridView.ReadOnly = true;
            this.CityGridView.RowHeadersVisible = false;
            this.CityGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CityGridView.Size = new System.Drawing.Size(764, 402);
            this.CityGridView.TabIndex = 4;
            // 
            // AddCityButton
            // 
            this.AddCityButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddCityButton.AutoSize = true;
            this.AddCityButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddCityButton.Location = new System.Drawing.Point(3, 3);
            this.AddCityButton.Name = "AddCityButton";
            this.AddCityButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.AddCityButton.Size = new System.Drawing.Size(75, 29);
            this.AddCityButton.TabIndex = 1;
            this.AddCityButton.Text = "!Add";
            this.AddCityButton.UseVisualStyleBackColor = true;
            this.AddCityButton.Click += new System.EventHandler(this.AddCityButton_Click);
            // 
            // EditCityButton
            // 
            this.EditCityButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditCityButton.AutoSize = true;
            this.EditCityButton.Location = new System.Drawing.Point(84, 3);
            this.EditCityButton.Name = "EditCityButton";
            this.EditCityButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.EditCityButton.Size = new System.Drawing.Size(75, 29);
            this.EditCityButton.TabIndex = 0;
            this.EditCityButton.Text = "!Edit";
            this.EditCityButton.UseVisualStyleBackColor = true;
            this.EditCityButton.Click += new System.EventHandler(this.EditCityButton_Click);
            // 
            // ButtonIcons
            // 
            this.ButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonIcons.ImageStream")));
            this.ButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonIcons.Images.SetKeyName(0, "Cities.png");
            this.ButtonIcons.Images.SetKeyName(1, "Drivers.png");
            this.ButtonIcons.Images.SetKeyName(2, "Items.png");
            this.ButtonIcons.Images.SetKeyName(3, "Revenue.png");
            this.ButtonIcons.Images.SetKeyName(4, "Routes.png");
            this.ButtonIcons.Images.SetKeyName(5, "Trucks.png");
            this.ButtonIcons.Images.SetKeyName(6, "Inventory.png");
            this.ButtonIcons.Images.SetKeyName(7, "Batch.png");
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 486);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 25);
            this.StatusBar.TabIndex = 3;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(300, 19);
            // 
            // ExtraButtonsLayout
            // 
            this.ExtraButtonsLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtraButtonsLayout.AutoSize = true;
            this.ExtraButtonsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExtraButtonsLayout.ColumnCount = 3;
            this.ExtraButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ExtraButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ExtraButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ExtraButtonsLayout.Controls.Add(this.SettingsButton, 0, 0);
            this.ExtraButtonsLayout.Controls.Add(this.LogButton, 1, 0);
            this.ExtraButtonsLayout.Controls.Add(this.AboutButton, 2, 0);
            this.ExtraButtonsLayout.Location = new System.Drawing.Point(686, -2);
            this.ExtraButtonsLayout.Name = "ExtraButtonsLayout";
            this.ExtraButtonsLayout.RowCount = 1;
            this.ExtraButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExtraButtonsLayout.Size = new System.Drawing.Size(90, 22);
            this.ExtraButtonsLayout.TabIndex = 8;
            // 
            // MainFormLayout
            // 
            this.MainFormLayout.ColumnCount = 1;
            this.MainFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainFormLayout.Controls.Add(this.MainTabs, 0, 0);
            this.MainFormLayout.Controls.Add(this.StatusBar, 0, 1);
            this.MainFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormLayout.Location = new System.Drawing.Point(0, 0);
            this.MainFormLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainFormLayout.Name = "MainFormLayout";
            this.MainFormLayout.RowCount = 2;
            this.MainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainFormLayout.Size = new System.Drawing.Size(784, 511);
            this.MainFormLayout.TabIndex = 10;
            // 
            // DefaultInventoryButton
            // 
            this.DefaultInventoryButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DefaultInventoryButton.AutoSize = true;
            this.DefaultInventoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DefaultInventoryButton.Location = new System.Drawing.Point(246, 3);
            this.DefaultInventoryButton.Name = "DefaultInventoryButton";
            this.DefaultInventoryButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.DefaultInventoryButton.Size = new System.Drawing.Size(103, 29);
            this.DefaultInventoryButton.TabIndex = 5;
            this.DefaultInventoryButton.Text = "!Default Inventory";
            this.DefaultInventoryButton.UseVisualStyleBackColor = true;
            this.DefaultInventoryButton.Click += new System.EventHandler(this.DefaultInventoryButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SettingsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.Location = new System.Drawing.Point(4, 0);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(22, 22);
            this.SettingsButton.TabIndex = 7;
            this.MainToolTips.SetToolTip(this.SettingsButton, "!Settings");
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogButton.FlatAppearance.BorderSize = 0;
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogButton.Image = ((System.Drawing.Image)(resources.GetObject("LogButton.Image")));
            this.LogButton.Location = new System.Drawing.Point(34, 0);
            this.LogButton.Margin = new System.Windows.Forms.Padding(0);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(22, 22);
            this.LogButton.TabIndex = 8;
            this.MainToolTips.SetToolTip(this.LogButton, "!View Log");
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(94, 17);
            this.mainStatusLabel.Text = "mainStatusLabel";
            // 
            // mainStatusProgressBar
            // 
            this.mainStatusProgressBar.Name = "mainStatusProgressBar";
            this.mainStatusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Image = global::IceCreamManager.Properties.Resources.Progress;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.StatusLabel.Size = new System.Drawing.Size(114, 20);
            this.StatusLabel.Text = "!Processing...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "!Ice Cream Manager";
            this.MainTabs.ResumeLayout(false);
            this.RevenueTab.ResumeLayout(false);
            this.RevenueTabs.ResumeLayout(false);
            this.OverallRevenueTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.TrucksTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TruckGridView)).EndInit();
            this.ItemsTab.ResumeLayout(false);
            this.ItemLayoutTable.ResumeLayout(false);
            this.ItemLayoutTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).EndInit();
            this.DriversTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriverGridView)).EndInit();
            this.RoutesTab.ResumeLayout(false);
            this.RoutesLayoutTable.ResumeLayout(false);
            this.RoutesLayoutTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RouteGridView)).EndInit();
            this.CitiesTab.ResumeLayout(false);
            this.CityLayoutTable.ResumeLayout(false);
            this.CityLayoutTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CityGridView)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ExtraButtonsLayout.ResumeLayout(false);
            this.MainFormLayout.ResumeLayout(false);
            this.MainFormLayout.PerformLayout();
            this.Text = "Ice Cream Manager";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.TabPage RevenueTab;
        private System.Windows.Forms.TabPage TrucksTab;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.TabPage ItemsTab;
        private System.Windows.Forms.TabPage DriversTab;
        private System.Windows.Forms.TabPage RoutesTab;
        private System.Windows.Forms.TabPage CitiesTab;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ImageList ButtonIcons;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.TableLayoutPanel ExtraButtonsLayout;
        private System.Windows.Forms.ToolTip MainToolTips;
        private System.Windows.Forms.TabControl RevenueTabs;
        private System.Windows.Forms.TabPage OverallRevenueTab;
        private System.Windows.Forms.TabPage SalesTab;
        private System.Windows.Forms.TabPage ItemWasteTab;
        private System.Windows.Forms.TabPage SalaryCostTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel MainFormLayout;
        private System.Windows.Forms.TableLayoutPanel ItemLayoutTable;
        protected System.Windows.Forms.Button RemoveItemButton;
        protected System.Windows.Forms.CheckBox ShowDeletedItems;
        protected System.Windows.Forms.Button AddItemButton;
        protected System.Windows.Forms.Button EditItemButton;
        private System.Windows.Forms.TableLayoutPanel CityLayoutTable;
        protected System.Windows.Forms.Button RemoveCityButton;
        protected System.Windows.Forms.CheckBox ShowDeletedCities;
        public System.Windows.Forms.DataGridView CityGridView;
        protected System.Windows.Forms.Button AddCityButton;
        protected System.Windows.Forms.Button EditCityButton;
        private System.Windows.Forms.TableLayoutPanel RoutesLayoutTable;
        protected System.Windows.Forms.Button RemoveRouteButton;
        protected System.Windows.Forms.CheckBox ShowDeletedRoutes;
        public System.Windows.Forms.DataGridView RouteGridView;
        protected System.Windows.Forms.Button AddRouteButton;
        protected System.Windows.Forms.Button EditRouteButton;
        public System.Windows.Forms.DataGridView ItemGridView;
        private System.Windows.Forms.TabPage BatchTab;
        private System.Windows.Forms.TabPage FuelUsageTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView DriverGridView;
        protected System.Windows.Forms.Button RemoveDriverButton;
        protected System.Windows.Forms.CheckBox ShowDeletedDrivers;
        protected System.Windows.Forms.Button AddDriverButton;
        protected System.Windows.Forms.Button EditDriverButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        protected System.Windows.Forms.Button RemoveTruckButton;
        protected System.Windows.Forms.CheckBox ShowDeletedTrucks;
        public System.Windows.Forms.DataGridView TruckGridView;
        protected System.Windows.Forms.Button AddTruckButton;
        protected System.Windows.Forms.Button EditTruckButton;
        protected System.Windows.Forms.Button DefaultInventoryButton;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripButton salesButton;
        private System.Windows.Forms.ToolStripButton batchButton;
        private System.Windows.Forms.ToolStripButton zonesButton;
        private System.Windows.Forms.ToolStripButton routesButton;
        private System.Windows.Forms.ToolStripButton trucksButton;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.ToolStripButton driversButton;
        private System.Windows.Forms.ToolStripButton fuelUsageButton;
        private System.Windows.Forms.ToolStripButton itemsButton;
        private System.Windows.Forms.ToolStripButton presetsButton;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStripButton votingButton;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar mainStatusProgressBar;
        private System.Windows.Forms.ToolStripSeparator helpButtonSeparator;
        private System.Windows.Forms.ToolStripSeparator zonesSectionSeperator;
        private System.Windows.Forms.ToolStripSeparator trucksSectionSeperator;
        private System.Windows.Forms.ToolStripSeparator itemsSectionSeperator;
        private System.Windows.Forms.ToolStripSeparator settingsSectionSeperator;
    }
}

