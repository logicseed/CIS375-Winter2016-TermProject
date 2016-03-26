namespace IceCreamManager.View
{
    partial class SalesListPanel
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
            this.salesDataGrid = new System.Windows.Forms.DataGridView();
            this.saleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // salesDataGrid
            // 
            this.salesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.saleDate});
            this.salesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesDataGrid.Location = new System.Drawing.Point(0, 0);
            this.salesDataGrid.Name = "salesDataGrid";
            this.salesDataGrid.Size = new System.Drawing.Size(800, 600);
            this.salesDataGrid.TabIndex = 0;
            // 
            // saleDate
            // 
            this.saleDate.DataPropertyName = "ssd";
            this.saleDate.HeaderText = "Date";
            this.saleDate.Name = "saleDate";
            // 
            // SalesReportPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.salesDataGrid);
            this.Name = "SalesReportPanel";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView salesDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleDate;
    }
}
