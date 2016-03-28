namespace IceCreamManager.View
{
    partial class SaveUndoToolbar
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
            this.toolbarGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolbarToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolbarGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarGroup
            // 
            this.toolbarGroup.AutoSize = true;
            this.toolbarGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolbarGroup.Controls.Add(this.button2);
            this.toolbarGroup.Controls.Add(this.button1);
            this.toolbarGroup.Location = new System.Drawing.Point(4, 4);
            this.toolbarGroup.Name = "toolbarGroup";
            this.toolbarGroup.Size = new System.Drawing.Size(94, 76);
            this.toolbarGroup.TabIndex = 0;
            this.toolbarGroup.TabStop = false;
            this.toolbarGroup.Text = "Toolbar Name";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::IceCreamManager.Properties.Resources.SaveChangesButton;
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 12;
            this.toolbarToolTip.SetToolTip(this.button1, "Save Changes");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::IceCreamManager.Properties.Resources.UndoChangesButton;
            this.button2.Location = new System.Drawing.Point(50, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 38);
            this.button2.TabIndex = 13;
            this.toolbarToolTip.SetToolTip(this.button2, "Undo Changes");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SaveUndoToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.toolbarGroup);
            this.Name = "SaveUndoToolbar";
            this.Size = new System.Drawing.Size(101, 83);
            this.toolbarGroup.ResumeLayout(false);
            this.toolbarGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox toolbarGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolbarToolTip;
    }
}
