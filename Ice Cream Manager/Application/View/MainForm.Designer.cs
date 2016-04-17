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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.RevenueTab = new System.Windows.Forms.TabPage();
            this.TrucksTab = new System.Windows.Forms.TabPage();
            this.ItemsTab = new System.Windows.Forms.TabPage();
            this.DriversTab = new System.Windows.Forms.TabPage();
            this.RoutesTab = new System.Windows.Forms.TabPage();
            this.CitiesTab = new System.Windows.Forms.TabPage();
            this.ButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExtraButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.MainToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.MainTabs.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ExtraButtonsLayout.SuspendLayout();
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
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabs.ImageList = this.ButtonIcons;
            this.MainTabs.Location = new System.Drawing.Point(0, 0);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.Padding = new System.Drawing.Point(6, 5);
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(584, 411);
            this.MainTabs.TabIndex = 0;
            // 
            // RevenueTab
            // 
            this.RevenueTab.ImageIndex = 3;
            this.RevenueTab.Location = new System.Drawing.Point(4, 27);
            this.RevenueTab.Name = "RevenueTab";
            this.RevenueTab.Padding = new System.Windows.Forms.Padding(3);
            this.RevenueTab.Size = new System.Drawing.Size(576, 380);
            this.RevenueTab.TabIndex = 0;
            this.RevenueTab.Text = "!Revenue";
            this.RevenueTab.UseVisualStyleBackColor = true;
            // 
            // TrucksTab
            // 
            this.TrucksTab.ImageIndex = 5;
            this.TrucksTab.Location = new System.Drawing.Point(4, 27);
            this.TrucksTab.Name = "TrucksTab";
            this.TrucksTab.Padding = new System.Windows.Forms.Padding(3);
            this.TrucksTab.Size = new System.Drawing.Size(576, 380);
            this.TrucksTab.TabIndex = 1;
            this.TrucksTab.Text = "!Trucks";
            this.TrucksTab.UseVisualStyleBackColor = true;
            // 
            // ItemsTab
            // 
            this.ItemsTab.ImageIndex = 2;
            this.ItemsTab.Location = new System.Drawing.Point(4, 27);
            this.ItemsTab.Name = "ItemsTab";
            this.ItemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ItemsTab.Size = new System.Drawing.Size(576, 380);
            this.ItemsTab.TabIndex = 2;
            this.ItemsTab.Text = "!Items";
            this.ItemsTab.UseVisualStyleBackColor = true;
            // 
            // DriversTab
            // 
            this.DriversTab.ImageIndex = 1;
            this.DriversTab.Location = new System.Drawing.Point(4, 27);
            this.DriversTab.Name = "DriversTab";
            this.DriversTab.Padding = new System.Windows.Forms.Padding(3);
            this.DriversTab.Size = new System.Drawing.Size(576, 380);
            this.DriversTab.TabIndex = 3;
            this.DriversTab.Text = "!Drivers";
            this.DriversTab.UseVisualStyleBackColor = true;
            // 
            // RoutesTab
            // 
            this.RoutesTab.ImageIndex = 4;
            this.RoutesTab.Location = new System.Drawing.Point(4, 27);
            this.RoutesTab.Name = "RoutesTab";
            this.RoutesTab.Padding = new System.Windows.Forms.Padding(3);
            this.RoutesTab.Size = new System.Drawing.Size(576, 380);
            this.RoutesTab.TabIndex = 4;
            this.RoutesTab.Text = "!Routes";
            this.RoutesTab.UseVisualStyleBackColor = true;
            // 
            // CitiesTab
            // 
            this.CitiesTab.ImageIndex = 0;
            this.CitiesTab.Location = new System.Drawing.Point(4, 27);
            this.CitiesTab.Name = "CitiesTab";
            this.CitiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.CitiesTab.Size = new System.Drawing.Size(576, 380);
            this.CitiesTab.TabIndex = 5;
            this.CitiesTab.Text = "!Cities";
            this.CitiesTab.UseVisualStyleBackColor = true;
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
            this.StatusBar.Location = new System.Drawing.Point(0, 386);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(584, 25);
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
            this.ExtraButtonsLayout.Location = new System.Drawing.Point(486, -2);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.ExtraButtonsLayout);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "MainForm";
            this.Text = "!Ice Cream Manager";
            this.MainTabs.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ExtraButtonsLayout.ResumeLayout(false);
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
    }
}