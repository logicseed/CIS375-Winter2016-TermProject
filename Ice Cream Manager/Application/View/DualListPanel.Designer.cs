namespace IceCreamManager.View
{
    partial class DualListPanel
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
            this.dualListPanelSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dualListPanelSplitContainer)).BeginInit();
            this.dualListPanelSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dualListPanelSplitContainer
            // 
            this.dualListPanelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dualListPanelSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.dualListPanelSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.dualListPanelSplitContainer.Name = "dualListPanelSplitContainer";
            this.dualListPanelSplitContainer.Size = new System.Drawing.Size(800, 600);
            this.dualListPanelSplitContainer.SplitterDistance = 500;
            this.dualListPanelSplitContainer.SplitterWidth = 2;
            this.dualListPanelSplitContainer.TabIndex = 0;
            // 
            // DualListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dualListPanelSplitContainer);
            this.Name = "DualListPanel";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dualListPanelSplitContainer)).EndInit();
            this.dualListPanelSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer dualListPanelSplitContainer;
    }
}
