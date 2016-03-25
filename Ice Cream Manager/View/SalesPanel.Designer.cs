namespace View
{
    partial class SalesPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.salesPanelSplitContainer = new System.Windows.Forms.SplitContainer();
            this.salesLedgerButton = new System.Windows.Forms.Button();
            this.salesChartsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.salesPanelSplitContainer)).BeginInit();
            this.salesPanelSplitContainer.Panel1.SuspendLayout();
            this.salesPanelSplitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // salesPanelSplitContainer
            // 
            this.salesPanelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesPanelSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.salesPanelSplitContainer.IsSplitterFixed = true;
            this.salesPanelSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.salesPanelSplitContainer.Name = "salesPanelSplitContainer";
            // 
            // salesPanelSplitContainer.Panel1
            // 
            this.salesPanelSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.salesPanelSplitContainer.Panel1.Controls.Add(this.button2);
            this.salesPanelSplitContainer.Panel1.Controls.Add(this.button1);
            this.salesPanelSplitContainer.Panel1.Controls.Add(this.groupBox1);
            this.salesPanelSplitContainer.Panel1.Controls.Add(this.salesChartsButton);
            this.salesPanelSplitContainer.Panel1.Controls.Add(this.salesLedgerButton);
            // 
            // salesPanelSplitContainer.Panel2
            // 
            this.salesPanelSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.salesPanelSplitContainer.Size = new System.Drawing.Size(949, 561);
            this.salesPanelSplitContainer.SplitterDistance = 316;
            this.salesPanelSplitContainer.SplitterWidth = 1;
            this.salesPanelSplitContainer.TabIndex = 0;
            this.salesPanelSplitContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.salesPanelSplitContainer_Paint);
            // 
            // salesLedgerButton
            // 
            this.salesLedgerButton.AutoSize = true;
            this.salesLedgerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.salesLedgerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.salesLedgerButton.FlatAppearance.BorderSize = 0;
            this.salesLedgerButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.salesLedgerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesLedgerButton.Image = global::View.Properties.Resources.SalesLedgerButton;
            this.salesLedgerButton.Location = new System.Drawing.Point(4, 4);
            this.salesLedgerButton.Name = "salesLedgerButton";
            this.salesLedgerButton.Size = new System.Drawing.Size(38, 38);
            this.salesLedgerButton.TabIndex = 0;
            this.salesLedgerButton.UseVisualStyleBackColor = true;
            // 
            // salesChartsButton
            // 
            this.salesChartsButton.AutoSize = true;
            this.salesChartsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.salesChartsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.salesChartsButton.FlatAppearance.BorderSize = 0;
            this.salesChartsButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.salesChartsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesChartsButton.Image = global::View.Properties.Resources.SalesChartsButton;
            this.salesChartsButton.Location = new System.Drawing.Point(48, 4);
            this.salesChartsButton.Name = "salesChartsButton";
            this.salesChartsButton.Size = new System.Drawing.Size(38, 38);
            this.salesChartsButton.TabIndex = 1;
            this.salesChartsButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(9, 71);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Route";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Driver";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(9, 150);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 190);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::View.Properties.Resources.SaveChangesButton;
            this.button1.Location = new System.Drawing.Point(4, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::View.Properties.Resources.UndoChangesButton;
            this.button2.Location = new System.Drawing.Point(48, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 38);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SalesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.salesPanelSplitContainer);
            this.Name = "SalesPanel";
            this.Size = new System.Drawing.Size(949, 561);
            this.salesPanelSplitContainer.Panel1.ResumeLayout(false);
            this.salesPanelSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesPanelSplitContainer)).EndInit();
            this.salesPanelSplitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer salesPanelSplitContainer;
        private System.Windows.Forms.Button salesLedgerButton;
        private System.Windows.Forms.Button salesChartsButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
    }
}
