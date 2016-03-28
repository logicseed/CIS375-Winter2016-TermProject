namespace IceCreamManager.View
{
    partial class VotingToolbar
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
            this.votingToolbarGroupBox = new System.Windows.Forms.GroupBox();
            this.votingToolbarToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.createPollButton = new System.Windows.Forms.Button();
            this.votingResultsButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.votingToolbarGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // votingToolbarGroupBox
            // 
            this.votingToolbarGroupBox.AutoSize = true;
            this.votingToolbarGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.votingToolbarGroupBox.Controls.Add(this.button2);
            this.votingToolbarGroupBox.Controls.Add(this.button1);
            this.votingToolbarGroupBox.Controls.Add(this.createPollButton);
            this.votingToolbarGroupBox.Controls.Add(this.votingResultsButton);
            this.votingToolbarGroupBox.Location = new System.Drawing.Point(4, 4);
            this.votingToolbarGroupBox.Name = "votingToolbarGroupBox";
            this.votingToolbarGroupBox.Size = new System.Drawing.Size(94, 120);
            this.votingToolbarGroupBox.TabIndex = 0;
            this.votingToolbarGroupBox.TabStop = false;
            this.votingToolbarGroupBox.Text = "Voting Options";
            // 
            // createPollButton
            // 
            this.createPollButton.AutoSize = true;
            this.createPollButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createPollButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.createPollButton.FlatAppearance.BorderSize = 0;
            this.createPollButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.createPollButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPollButton.Image = global::IceCreamManager.Properties.Resources.AddButton;
            this.createPollButton.Location = new System.Drawing.Point(50, 19);
            this.createPollButton.Name = "createPollButton";
            this.createPollButton.Size = new System.Drawing.Size(38, 38);
            this.createPollButton.TabIndex = 2;
            this.votingToolbarToolTips.SetToolTip(this.createPollButton, "Add Poll");
            this.createPollButton.UseVisualStyleBackColor = true;
            // 
            // votingResultsButton
            // 
            this.votingResultsButton.AutoSize = true;
            this.votingResultsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.votingResultsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.votingResultsButton.FlatAppearance.BorderSize = 0;
            this.votingResultsButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.votingResultsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.votingResultsButton.Image = global::IceCreamManager.Properties.Resources.ListButton;
            this.votingResultsButton.Location = new System.Drawing.Point(6, 19);
            this.votingResultsButton.Name = "votingResultsButton";
            this.votingResultsButton.Size = new System.Drawing.Size(38, 38);
            this.votingResultsButton.TabIndex = 1;
            this.votingToolbarToolTips.SetToolTip(this.votingResultsButton, "Voting Results");
            this.votingResultsButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::IceCreamManager.Properties.Resources.UndoChangesButton;
            this.button2.Location = new System.Drawing.Point(50, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 38);
            this.button2.TabIndex = 15;
            this.votingToolbarToolTips.SetToolTip(this.button2, "Undo Changes");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::IceCreamManager.Properties.Resources.SaveChangesButton;
            this.button1.Location = new System.Drawing.Point(6, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 14;
            this.votingToolbarToolTips.SetToolTip(this.button1, "Save Changes");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // VotingToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.votingToolbarGroupBox);
            this.Name = "VotingToolbar";
            this.Size = new System.Drawing.Size(101, 127);
            this.votingToolbarGroupBox.ResumeLayout(false);
            this.votingToolbarGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox votingToolbarGroupBox;
        private System.Windows.Forms.Button createPollButton;
        private System.Windows.Forms.ToolTip votingToolbarToolTips;
        private System.Windows.Forms.Button votingResultsButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
