namespace IceCreamManager.View
{
    partial class VotingCreatePanel
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
            this.votingCreateDualListPanel = new IceCreamManager.View.DualListPanel();
            this.SuspendLayout();
            // 
            // votingCreateDualListPanel
            // 
            this.votingCreateDualListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.votingCreateDualListPanel.Location = new System.Drawing.Point(0, 0);
            this.votingCreateDualListPanel.Name = "votingCreateDualListPanel";
            this.votingCreateDualListPanel.Size = new System.Drawing.Size(800, 600);
            this.votingCreateDualListPanel.TabIndex = 0;
            // 
            // VotingCreatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.votingCreateDualListPanel);
            this.Name = "VotingCreatePanel";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private DualListPanel votingCreateDualListPanel;
    }
}
