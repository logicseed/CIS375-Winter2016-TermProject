namespace IceCreamManager.View
{
    partial class CityEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CityEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HoursBox = new System.Windows.Forms.NumericUpDown();
            this.HoursLabel = new System.Windows.Forms.Label();
            this.MilesLabel = new System.Windows.Forms.Label();
            this.StateBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.LabelLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.LabelBox = new System.Windows.Forms.TextBox();
            this.MilesBox = new System.Windows.Forms.NumericUpDown();
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoursBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilesBox)).BeginInit();
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
            this.FormLayout.Size = new System.Drawing.Size(188, 209);
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
            this.ButtonLayout.Location = new System.Drawing.Point(23, 169);
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
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "!Save";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveCity);
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
            this.DiscardButton.TabIndex = 7;
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
            this.tableLayoutPanel1.Controls.Add(this.HoursBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.HoursLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.MilesLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.StateBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NameBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StateLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LabelBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.MilesBox, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(182, 160);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // HoursBox
            // 
            this.HoursBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HoursBox.DecimalPlaces = 2;
            this.HoursBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.HoursBox.Location = new System.Drawing.Point(47, 134);
            this.HoursBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.HoursBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.HoursBox.Name = "HoursBox";
            this.HoursBox.Size = new System.Drawing.Size(58, 20);
            this.HoursBox.TabIndex = 5;
            this.HoursBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // HoursLabel
            // 
            this.HoursLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.HoursLabel.AutoSize = true;
            this.HoursLabel.Location = new System.Drawing.Point(3, 137);
            this.HoursLabel.Name = "HoursLabel";
            this.HoursLabel.Size = new System.Drawing.Size(38, 13);
            this.HoursLabel.TabIndex = 5;
            this.HoursLabel.Text = "!Hours";
            // 
            // MilesLabel
            // 
            this.MilesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MilesLabel.AutoSize = true;
            this.MilesLabel.Location = new System.Drawing.Point(7, 105);
            this.MilesLabel.Name = "MilesLabel";
            this.MilesLabel.Size = new System.Drawing.Size(34, 13);
            this.MilesLabel.TabIndex = 5;
            this.MilesLabel.Text = "!Miles";
            // 
            // StateBox
            // 
            this.StateBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StateBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.StateBox.Location = new System.Drawing.Point(47, 70);
            this.StateBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.StateBox.MaxLength = 2;
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(37, 20);
            this.StateBox.TabIndex = 3;
            this.StateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameBox
            // 
            this.NameBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NameBox.Location = new System.Drawing.Point(47, 38);
            this.NameBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.NameBox.MaxLength = 20;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(129, 20);
            this.NameBox.TabIndex = 2;
            // 
            // LabelLabel
            // 
            this.LabelLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelLabel.AutoSize = true;
            this.LabelLabel.Location = new System.Drawing.Point(5, 9);
            this.LabelLabel.Name = "LabelLabel";
            this.LabelLabel.Size = new System.Drawing.Size(36, 13);
            this.LabelLabel.TabIndex = 0;
            this.LabelLabel.Text = "!Label";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 41);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "!Name";
            // 
            // StateLabel
            // 
            this.StateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(6, 73);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(35, 13);
            this.StateLabel.TabIndex = 2;
            this.StateLabel.Text = "!State";
            // 
            // LabelBox
            // 
            this.LabelBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelBox.Location = new System.Drawing.Point(47, 6);
            this.LabelBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.LabelBox.MaxLength = 20;
            this.LabelBox.Name = "LabelBox";
            this.LabelBox.Size = new System.Drawing.Size(129, 20);
            this.LabelBox.TabIndex = 1;
            // 
            // MilesBox
            // 
            this.MilesBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MilesBox.DecimalPlaces = 2;
            this.MilesBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.MilesBox.Location = new System.Drawing.Point(47, 102);
            this.MilesBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.MilesBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.MilesBox.Name = "MilesBox";
            this.MilesBox.Size = new System.Drawing.Size(58, 20);
            this.MilesBox.TabIndex = 4;
            this.MilesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CityEditor
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(483, 380);
            this.Controls.Add(this.FormLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CityEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!City Editor";
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoursBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        public System.Windows.Forms.Button SaveButton;
        protected System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label LabelLabel;
        private System.Windows.Forms.Label NameLabel;
        protected System.Windows.Forms.TextBox LabelBox;
        private System.Windows.Forms.Label HoursLabel;
        private System.Windows.Forms.Label MilesLabel;
        protected System.Windows.Forms.TextBox StateBox;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.NumericUpDown HoursBox;
        private System.Windows.Forms.NumericUpDown MilesBox;
    }
}