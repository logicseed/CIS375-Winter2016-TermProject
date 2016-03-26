namespace IceCreamManager.View
{
    partial class ToolbarPanel
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
            this.toolbarPanelSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarPanelSplitContainer)).BeginInit();
            this.toolbarPanelSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarPanelSplitContainer
            // 
            this.toolbarPanelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarPanelSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.toolbarPanelSplitContainer.IsSplitterFixed = true;
            this.toolbarPanelSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.toolbarPanelSplitContainer.Name = "toolbarPanelSplitContainer";
            // 
            // toolbarPanelSplitContainer.Panel1
            // 
            this.toolbarPanelSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // toolbarPanelSplitContainer.Panel2
            // 
            this.toolbarPanelSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolbarPanelSplitContainer.Size = new System.Drawing.Size(800, 600);
            this.toolbarPanelSplitContainer.SplitterDistance = 250;
            this.toolbarPanelSplitContainer.SplitterWidth = 1;
            this.toolbarPanelSplitContainer.TabIndex = 0;
            this.toolbarPanelSplitContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.toolbarPanelSplitContainer_Paint);
            // 
            // ToolbarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolbarPanelSplitContainer);
            this.Name = "ToolbarPanel";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.toolbarPanelSplitContainer)).EndInit();
            this.toolbarPanelSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer toolbarPanelSplitContainer;
    }
}
