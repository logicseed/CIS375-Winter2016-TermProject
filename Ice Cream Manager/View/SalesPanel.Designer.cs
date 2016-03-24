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
            this.SalesToolStrip = new System.Windows.Forms.ToolStrip();
            this.SalesGridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SalesToolStrip
            // 
            this.SalesToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.SalesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SalesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SalesToolStrip.Name = "SalesToolStrip";
            this.SalesToolStrip.Size = new System.Drawing.Size(32, 454);
            this.SalesToolStrip.TabIndex = 0;
            this.SalesToolStrip.Text = "toolStrip1";
            // 
            // SalesGridPanel
            // 
            this.SalesGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalesGridPanel.Location = new System.Drawing.Point(32, 0);
            this.SalesGridPanel.Name = "SalesGridPanel";
            this.SalesGridPanel.Size = new System.Drawing.Size(711, 454);
            this.SalesGridPanel.TabIndex = 1;
            // 
            // SalesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SalesGridPanel);
            this.Controls.Add(this.SalesToolStrip);
            this.Name = "SalesPanel";
            this.Size = new System.Drawing.Size(743, 454);
            this.Load += new System.EventHandler(this.SalesPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SalesToolStrip;
        private System.Windows.Forms.Panel SalesGridPanel;
    }
}
