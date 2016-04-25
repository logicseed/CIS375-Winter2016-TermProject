namespace IceCreamManager.View
{
    partial class LogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            this.LogViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxEntriesLabel = new System.Windows.Forms.Label();
            this.MaxEntriesBox = new System.Windows.Forms.NumericUpDown();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.LogGridView = new System.Windows.Forms.DataGridView();
            this.LogViewLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxEntriesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogViewLayout
            // 
            this.LogViewLayout.AutoSize = true;
            this.LogViewLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LogViewLayout.ColumnCount = 1;
            this.LogViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LogViewLayout.Controls.Add(this.LogGridView, 0, 1);
            this.LogViewLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.LogViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewLayout.Location = new System.Drawing.Point(0, 0);
            this.LogViewLayout.Name = "LogViewLayout";
            this.LogViewLayout.RowCount = 2;
            this.LogViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LogViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LogViewLayout.Size = new System.Drawing.Size(334, 211);
            this.LogViewLayout.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.MaxEntriesLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MaxEntriesBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RefreshButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(212, 29);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // MaxEntriesLabel
            // 
            this.MaxEntriesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MaxEntriesLabel.AutoSize = true;
            this.MaxEntriesLabel.Location = new System.Drawing.Point(6, 8);
            this.MaxEntriesLabel.Margin = new System.Windows.Forms.Padding(6, 6, 3, 6);
            this.MaxEntriesLabel.Name = "MaxEntriesLabel";
            this.MaxEntriesLabel.Size = new System.Drawing.Size(62, 13);
            this.MaxEntriesLabel.TabIndex = 0;
            this.MaxEntriesLabel.Text = "!MaxEntries";
            // 
            // MaxEntriesBox
            // 
            this.MaxEntriesBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MaxEntriesBox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.MaxEntriesBox.Location = new System.Drawing.Point(74, 4);
            this.MaxEntriesBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.MaxEntriesBox.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.MaxEntriesBox.Name = "MaxEntriesBox";
            this.MaxEntriesBox.Size = new System.Drawing.Size(54, 20);
            this.MaxEntriesBox.TabIndex = 1;
            this.MaxEntriesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaxEntriesBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RefreshButton.Location = new System.Drawing.Point(134, 3);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "!Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LogGridView
            // 
            this.LogGridView.AllowUserToAddRows = false;
            this.LogGridView.AllowUserToDeleteRows = false;
            this.LogGridView.AllowUserToResizeColumns = false;
            this.LogGridView.AllowUserToResizeRows = false;
            this.LogGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LogGridView.BackgroundColor = System.Drawing.Color.SlateGray;
            this.LogGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.LogGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.LogGridView.ColumnHeadersVisible = false;
            this.LogGridView.Location = new System.Drawing.Point(3, 38);
            this.LogGridView.MultiSelect = false;
            this.LogGridView.Name = "LogGridView";
            this.LogGridView.ReadOnly = true;
            this.LogGridView.RowHeadersVisible = false;
            this.LogGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogGridView.Size = new System.Drawing.Size(328, 170);
            this.LogGridView.TabIndex = 2;
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.LogViewLayout);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 250);
            this.Name = "LogViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!LogViewer";
            this.LogViewLayout.ResumeLayout(false);
            this.LogViewLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxEntriesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel LogViewLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label MaxEntriesLabel;
        private System.Windows.Forms.NumericUpDown MaxEntriesBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.DataGridView LogGridView;
    }
}