namespace IceCreamManager.View
{
    partial class PresetsPanel
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
            this.presetsToolbarPanel = new IceCreamManager.View.ToolbarPanel();
            this.SuspendLayout();
            // 
            // presetsToolbarPanel
            // 
            this.presetsToolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.presetsToolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.presetsToolbarPanel.Name = "presetsToolbarPanel";
            this.presetsToolbarPanel.Size = new System.Drawing.Size(800, 600);
            this.presetsToolbarPanel.TabIndex = 0;
            // 
            // PresetsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.presetsToolbarPanel);
            this.Name = "PresetsPanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolbarPanel presetsToolbarPanel;
    }
}
