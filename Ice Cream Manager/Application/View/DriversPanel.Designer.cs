namespace IceCreamManager.View
{
    partial class DriversPanel
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
            this.driversToolbarPanel = new IceCreamManager.View.ToolbarPanel();
            this.SuspendLayout();
            // 
            // driversToolbarPanel
            // 
            this.driversToolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driversToolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.driversToolbarPanel.Name = "driversToolbarPanel";
            this.driversToolbarPanel.Size = new System.Drawing.Size(800, 600);
            this.driversToolbarPanel.TabIndex = 0;
            // 
            // DriversPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.driversToolbarPanel);
            this.Name = "DriversPanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolbarPanel driversToolbarPanel;
    }
}
