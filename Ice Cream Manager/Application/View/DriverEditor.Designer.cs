namespace IceCreamManager.View
{
    partial class DriverEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.NumberBox = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.HourlyRateLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.HourlyRateBox = new System.Windows.Forms.NumericUpDown();
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HourlyRateBox)).BeginInit();
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
            this.FormLayout.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 2;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.Size = new System.Drawing.Size(187, 145);
            this.FormLayout.TabIndex = 5;
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
            this.ButtonLayout.Location = new System.Drawing.Point(22, 105);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.Size = new System.Drawing.Size(162, 37);
            this.ButtonLayout.TabIndex = 2;
            // 
            // NumberLabel
            // 
            this.NumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(22, 9);
            this.NumberLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(47, 13);
            this.NumberLabel.TabIndex = 0;
            this.NumberLabel.Text = "!Number";
            // 
            // NumberBox
            // 
            this.NumberBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumberBox.Location = new System.Drawing.Point(75, 6);
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
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(31, 41);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "!Name";
            // 
            // HourlyRateLabel
            // 
            this.HourlyRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.HourlyRateLabel.AutoSize = true;
            this.HourlyRateLabel.Location = new System.Drawing.Point(3, 73);
            this.HourlyRateLabel.Name = "HourlyRateLabel";
            this.HourlyRateLabel.Size = new System.Drawing.Size(66, 13);
            this.HourlyRateLabel.TabIndex = 7;
            this.HourlyRateLabel.Text = "!Hourly Rate";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.HourlyRateBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.HourlyRateLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.NumberBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.NameLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.NumberLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.NameBox, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(181, 96);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // NameBox
            // 
            this.NameBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NameBox.Location = new System.Drawing.Point(75, 38);
            this.NameBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 2;
            // 
            // HourlyRateBox
            // 
            this.HourlyRateBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HourlyRateBox.DecimalPlaces = 2;
            this.HourlyRateBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.HourlyRateBox.Location = new System.Drawing.Point(75, 70);
            this.HourlyRateBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.HourlyRateBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.HourlyRateBox.Name = "HourlyRateBox";
            this.HourlyRateBox.Size = new System.Drawing.Size(56, 20);
            this.HourlyRateBox.TabIndex = 6;
            this.HourlyRateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HourlyRateBox.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // DriverEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(394, 271);
            this.Controls.Add(this.FormLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!DriverEditor";
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HourlyRateBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        public System.Windows.Forms.Button SaveButton;
        protected System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.NumericUpDown NumberBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label HourlyRateLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown HourlyRateBox;
        private System.Windows.Forms.TextBox NameBox;
    }
}