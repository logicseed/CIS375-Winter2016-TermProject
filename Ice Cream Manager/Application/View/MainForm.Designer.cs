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
            this.TrucksTab = new System.Windows.Forms.TabPage();
            this.ItemsTab = new System.Windows.Forms.TabPage();
            this.ItemLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.ItemGridView = new System.Windows.Forms.DataGridView();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.ShowDeletedItems = new System.Windows.Forms.CheckBox();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.DriversTab = new System.Windows.Forms.TabPage();
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
            this.BatchTab = new System.Windows.Forms.TabPage();
            this.ButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExtraButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.MainToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.MainFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainTabs.SuspendLayout();
            this.RevenueTab.SuspendLayout();
            this.RevenueTabs.SuspendLayout();
            this.OverallRevenueTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.ItemsTab.SuspendLayout();
            this.ItemLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).BeginInit();
            this.RoutesTab.SuspendLayout();
            this.RoutesLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RouteGridView)).BeginInit();
            this.CitiesTab.SuspendLayout();
            this.CityLayoutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CityGridView)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.ExtraButtonsLayout.SuspendLayout();
            this.MainFormLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabs
            // 
            this.MainTabs.Controls.Add(this.RevenueTab);
            this.MainTabs.Controls.Add(this.TrucksTab);
            this.MainTabs.Controls.Add(this.ItemsTab);
            this.MainTabs.Controls.Add(this.DriversTab);
            this.MainTabs.Controls.Add(this.RoutesTab);
            this.MainTabs.Controls.Add(this.CitiesTab);
            this.MainTabs.Controls.Add(this.BatchTab);
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
            // RevenueTab
            // 
            this.RevenueTab.Controls.Add(this.RevenueTabs);
            this.RevenueTab.ImageIndex = 3;
            this.RevenueTab.Location = new System.Drawing.Point(4, 33);
            this.RevenueTab.Name = "RevenueTab";
            this.RevenueTab.Padding = new System.Windows.Forms.Padding(3);
            this.RevenueTab.Size = new System.Drawing.Size(776, 449);
            this.RevenueTab.TabIndex = 0;
            this.RevenueTab.Text = "!Revenue";
            this.RevenueTab.UseVisualStyleBackColor = true;
            // 
            // RevenueTabs
            // 
            this.RevenueTabs.Controls.Add(this.OverallRevenueTab);
            this.RevenueTabs.Controls.Add(this.SalesTab);
            this.RevenueTabs.Controls.Add(this.ItemWasteTab);
            this.RevenueTabs.Controls.Add(this.SalaryCostTab);
            this.RevenueTabs.Controls.Add(this.FuelUsageTab);
            this.RevenueTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RevenueTabs.Location = new System.Drawing.Point(3, 3);
            this.RevenueTabs.Name = "RevenueTabs";
            this.RevenueTabs.SelectedIndex = 0;
            this.RevenueTabs.Size = new System.Drawing.Size(770, 443);
            this.RevenueTabs.TabIndex = 0;
            // 
            // OverallRevenueTab
            // 
            this.OverallRevenueTab.Controls.Add(this.chart1);
            this.OverallRevenueTab.Location = new System.Drawing.Point(4, 22);
            this.OverallRevenueTab.Name = "OverallRevenueTab";
            this.OverallRevenueTab.Padding = new System.Windows.Forms.Padding(3);
            this.OverallRevenueTab.Size = new System.Drawing.Size(762, 417);
            this.OverallRevenueTab.TabIndex = 0;
            this.OverallRevenueTab.Text = "!Overall";
            this.OverallRevenueTab.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
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
            // SalesTab
            // 
            this.SalesTab.Location = new System.Drawing.Point(4, 22);
            this.SalesTab.Name = "SalesTab";
            this.SalesTab.Padding = new System.Windows.Forms.Padding(3);
            this.SalesTab.Size = new System.Drawing.Size(762, 417);
            this.SalesTab.TabIndex = 1;
            this.SalesTab.Text = "!Sales";
            this.SalesTab.UseVisualStyleBackColor = true;
            // 
            // ItemWasteTab
            // 
            this.ItemWasteTab.Location = new System.Drawing.Point(4, 22);
            this.ItemWasteTab.Name = "ItemWasteTab";
            this.ItemWasteTab.Padding = new System.Windows.Forms.Padding(3);
            this.ItemWasteTab.Size = new System.Drawing.Size(762, 417);
            this.ItemWasteTab.TabIndex = 2;
            this.ItemWasteTab.Text = "!Item Waste";
            this.ItemWasteTab.UseVisualStyleBackColor = true;
            // 
            // SalaryCostTab
            // 
            this.SalaryCostTab.Location = new System.Drawing.Point(4, 22);
            this.SalaryCostTab.Name = "SalaryCostTab";
            this.SalaryCostTab.Padding = new System.Windows.Forms.Padding(3);
            this.SalaryCostTab.Size = new System.Drawing.Size(762, 417);
            this.SalaryCostTab.TabIndex = 3;
            this.SalaryCostTab.Text = "!Salary Cost";
            this.SalaryCostTab.UseVisualStyleBackColor = true;
            // 
            // FuelUsageTab
            // 
            this.FuelUsageTab.Location = new System.Drawing.Point(4, 22);
            this.FuelUsageTab.Name = "FuelUsageTab";
            this.FuelUsageTab.Padding = new System.Windows.Forms.Padding(3);
            this.FuelUsageTab.Size = new System.Drawing.Size(762, 417);
            this.FuelUsageTab.TabIndex = 4;
            this.FuelUsageTab.Text = "!Fuel Usage";
            this.FuelUsageTab.UseVisualStyleBackColor = true;
            // 
            // TrucksTab
            // 
            this.TrucksTab.ImageIndex = 5;
            this.TrucksTab.Location = new System.Drawing.Point(4, 33);
            this.TrucksTab.Name = "TrucksTab";
            this.TrucksTab.Padding = new System.Windows.Forms.Padding(3);
            this.TrucksTab.Size = new System.Drawing.Size(776, 449);
            this.TrucksTab.TabIndex = 1;
            this.TrucksTab.Text = "!Trucks";
            this.TrucksTab.UseVisualStyleBackColor = true;
            // 
            // ItemsTab
            // 
            this.ItemsTab.Controls.Add(this.ItemLayoutTable);
            this.ItemsTab.ImageIndex = 2;
            this.ItemsTab.Location = new System.Drawing.Point(4, 33);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ItemsTab.Size = new System.Drawing.Size(776, 449);
            this.ItemsTab.TabIndex = 2;
            this.ItemsTab.Text = "!Items";
            this.ItemsTab.UseVisualStyleBackColor = true;
            // 
            // ItemLayoutTable
            // 
            this.ItemLayoutTable.ColumnCount = 4;
            this.ItemLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ItemLayoutTable.Controls.Add(this.ItemGridView, 0, 1);
            this.ItemLayoutTable.Controls.Add(this.RemoveItemButton, 2, 0);
            this.ItemLayoutTable.Controls.Add(this.ShowDeletedItems, 3, 0);
            this.ItemLayoutTable.Controls.Add(this.AddItemButton, 0, 0);
            this.ItemLayoutTable.Controls.Add(this.EditItemButton, 1, 0);
            this.ItemLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemLayoutTable.Location = new System.Drawing.Point(3, 3);
            this.ItemLayoutTable.Name = "ItemLayoutTable";
            this.ItemLayoutTable.RowCount = 2;
            this.ItemLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ItemLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemLayoutTable.Size = new System.Drawing.Size(770, 443);
            this.ItemLayoutTable.TabIndex = 1;
            // 
            // ItemGridView
            // 
            this.ItemGridView.AllowUserToAddRows = false;
            this.ItemGridView.AllowUserToDeleteRows = false;
            this.ItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemLayoutTable.SetColumnSpan(this.ItemGridView, 4);
            this.ItemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemGridView.Location = new System.Drawing.Point(3, 38);
            this.ItemGridView.MultiSelect = false;
            this.ItemGridView.Name = "ItemGridView";
            this.ItemGridView.ReadOnly = true;
            this.ItemGridView.RowHeadersVisible = false;
            this.ItemGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemGridView.Size = new System.Drawing.Size(764, 402);
            this.ItemGridView.TabIndex = 5;
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RemoveItemButton.AutoSize = true;
            this.RemoveItemButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveItemButton.Location = new System.Drawing.Point(165, 3);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.RemoveItemButton.Size = new System.Drawing.Size(75, 29);
            this.RemoveItemButton.TabIndex = 2;
            this.RemoveItemButton.Text = "!Remove";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // ShowDeletedItems
            // 
            this.ShowDeletedItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ShowDeletedItems.AutoSize = true;
            this.ShowDeletedItems.Location = new System.Drawing.Point(246, 9);
            this.ShowDeletedItems.Name = "ShowDeletedItems";
            this.ShowDeletedItems.Size = new System.Drawing.Size(96, 17);
            this.ShowDeletedItems.TabIndex = 3;
            this.ShowDeletedItems.Text = "!Show Deleted";
            this.ShowDeletedItems.UseVisualStyleBackColor = true;
            this.ShowDeletedItems.CheckedChanged += new System.EventHandler(this.RefreshItemTable);
            // 
            // AddItemButton
            // 
            this.AddItemButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddItemButton.AutoSize = true;
            this.AddItemButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddItemButton.Location = new System.Drawing.Point(3, 3);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.AddItemButton.Size = new System.Drawing.Size(75, 29);
            this.AddItemButton.TabIndex = 1;
            this.AddItemButton.Text = "!Add";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // EditItemButton
            // 
            this.EditItemButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditItemButton.AutoSize = true;
            this.EditItemButton.Location = new System.Drawing.Point(84, 3);
            this.EditItemButton.Name = "EditItemButton";
            this.EditItemButton.Padding = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.EditItemButton.Size = new System.Drawing.Size(75, 29);
            this.EditItemButton.TabIndex = 0;
            this.EditItemButton.Text = "!Edit";
            this.EditItemButton.UseVisualStyleBackColor = true;
            this.EditItemButton.Click += new System.EventHandler(this.EditItemButton_Click);
            // 
            // DriversTab
            // 
            this.DriversTab.ImageIndex = 1;
            this.DriversTab.Location = new System.Drawing.Point(4, 33);
            this.DriversTab.Name = "DriversTab";
            this.DriversTab.Padding = new System.Windows.Forms.Padding(3);
            this.DriversTab.Size = new System.Drawing.Size(776, 449);
            this.DriversTab.TabIndex = 3;
            this.DriversTab.Text = "!Drivers";
            this.DriversTab.UseVisualStyleBackColor = true;
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
            // BatchTab
            // 
            this.BatchTab.Location = new System.Drawing.Point(4, 33);
            this.BatchTab.Name = "BatchTab";
            this.BatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.BatchTab.Size = new System.Drawing.Size(776, 449);
            this.BatchTab.TabIndex = 6;
            this.BatchTab.Text = "!Batch";
            this.BatchTab.UseVisualStyleBackColor = true;
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
            // StatusLabel
            // 
            this.StatusLabel.Image = global::IceCreamManager.Properties.Resources.Progress;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.StatusLabel.Size = new System.Drawing.Size(114, 20);
            this.StatusLabel.Text = "!Processing...";
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
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AboutButton.FlatAppearance.BorderSize = 0;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.Location = new System.Drawing.Point(64, 0);
            this.AboutButton.Margin = new System.Windows.Forms.Padding(0);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(22, 22);
            this.AboutButton.TabIndex = 9;
            this.MainToolTips.SetToolTip(this.AboutButton, "!About");
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.ExtraButtonsLayout);
            this.Controls.Add(this.MainFormLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "!Ice Cream Manager";
            this.MainTabs.ResumeLayout(false);
            this.RevenueTab.ResumeLayout(false);
            this.RevenueTabs.ResumeLayout(false);
            this.OverallRevenueTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ItemsTab.ResumeLayout(false);
            this.ItemLayoutTable.ResumeLayout(false);
            this.ItemLayoutTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).EndInit();
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
    }
}