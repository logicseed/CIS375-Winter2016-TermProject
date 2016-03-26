namespace IceCreamManager.View
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
            this.components = new System.ComponentModel.Container();
            this.salesToolbarPanel = new IceCreamManager.View.ToolbarPanel();
            this.salesToolbar = new IceCreamManager.View.SalesToolbar();
            this.SuspendLayout();
            // 
            // salesToolbarPanel
            // 
            this.salesToolbarPanel.AutoSize = true;
            this.salesToolbarPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.salesToolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesToolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.salesToolbarPanel.Name = "salesToolbarPanel";
            this.salesToolbarPanel.Size = new System.Drawing.Size(800, 600);
            this.salesToolbarPanel.TabIndex = 0;
            // 
            // salesToolbar
            // 
            this.salesToolbar.AutoSize = true;
            this.salesToolbar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.salesToolbar.Location = new System.Drawing.Point(4, 4);
            this.salesToolbar.Name = "salesToolbar";
            this.salesToolbar.Size = new System.Drawing.Size(133, 322);
            this.salesToolbar.TabIndex = 1;
            // 
            // SalesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.salesToolbarPanel);
            this.Name = "SalesPanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolbarPanel salesToolbarPanel;
        private SalesToolbar salesToolbar;
    }
}
