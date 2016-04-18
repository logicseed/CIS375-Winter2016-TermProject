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
            this.LogGridView = new System.Windows.Forms.DataGridView();
            this.LogViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ClearLogButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).BeginInit();
            this.LogViewLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogGridView
            // 
            this.LogGridView.AllowUserToAddRows = false;
            this.LogGridView.AllowUserToDeleteRows = false;
            this.LogGridView.AllowUserToResizeRows = false;
            this.LogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogGridView.Location = new System.Drawing.Point(3, 3);
            this.LogGridView.MultiSelect = false;
            this.LogGridView.Name = "LogGridView";
            this.LogGridView.ReadOnly = true;
            this.LogGridView.RowHeadersVisible = false;
            this.LogGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogGridView.Size = new System.Drawing.Size(471, 288);
            this.LogGridView.TabIndex = 0;
            // 
            // LogViewLayout
            // 
            this.LogViewLayout.ColumnCount = 1;
            this.LogViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LogViewLayout.Controls.Add(this.LogGridView, 0, 0);
            this.LogViewLayout.Controls.Add(this.ClearLogButton, 0, 1);
            this.LogViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewLayout.Location = new System.Drawing.Point(0, 0);
            this.LogViewLayout.Name = "LogViewLayout";
            this.LogViewLayout.RowCount = 2;
            this.LogViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LogViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LogViewLayout.Size = new System.Drawing.Size(477, 323);
            this.LogViewLayout.TabIndex = 1;
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClearLogButton.Location = new System.Drawing.Point(3, 297);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(75, 23);
            this.ClearLogButton.TabIndex = 1;
            this.ClearLogButton.Text = "!Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 323);
            this.Controls.Add(this.LogViewLayout);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!LogViewer";
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).EndInit();
            this.LogViewLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LogGridView;
        private System.Windows.Forms.TableLayoutPanel LogViewLayout;
        private System.Windows.Forms.Button ClearLogButton;
    }
}