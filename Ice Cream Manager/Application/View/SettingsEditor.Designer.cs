namespace IceCreamManager.View
{
    partial class SettingsEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsEditor));
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.CurrencyBox = new System.Windows.Forms.TextBox();
            this.FormLayout.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormLayout
            // 
            this.FormLayout.AutoSize = true;
            this.FormLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormLayout.ColumnCount = 1;
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FormLayout.Controls.Add(this.ButtonLayout, 0, 1);
            this.FormLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 2;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormLayout.Size = new System.Drawing.Size(203, 114);
            this.FormLayout.TabIndex = 4;
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ButtonLayout.AutoSize = true;
            this.ButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonLayout.ColumnCount = 2;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.Controls.Add(this.SaveButton, 0, 0);
            this.ButtonLayout.Controls.Add(this.DiscardButton, 1, 0);
            this.ButtonLayout.Location = new System.Drawing.Point(38, 74);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonLayout.Size = new System.Drawing.Size(162, 37);
            this.ButtonLayout.TabIndex = 2;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveButton.AutoSize = true;
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Image = global::IceCreamManager.Properties.Resources.Save;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(3, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.SaveButton.Size = new System.Drawing.Size(75, 31);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "!Save";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DiscardButton
            // 
            this.DiscardButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DiscardButton.AutoSize = true;
            this.DiscardButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardButton.Image = global::IceCreamManager.Properties.Resources.Cancel;
            this.DiscardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DiscardButton.Location = new System.Drawing.Point(84, 3);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.DiscardButton.Size = new System.Drawing.Size(75, 31);
            this.DiscardButton.TabIndex = 4;
            this.DiscardButton.Text = "!Discard";
            this.DiscardButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DiscardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DiscardButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.LanguageLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CurrencyLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LanguageBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CurrencyBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(197, 65);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(6, 10);
            this.LanguageLabel.Margin = new System.Windows.Forms.Padding(6, 6, 3, 6);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(58, 13);
            this.LanguageLabel.TabIndex = 0;
            this.LanguageLabel.Text = "!Language";
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CurrencyLabel.AutoSize = true;
            this.CurrencyLabel.Location = new System.Drawing.Point(12, 42);
            this.CurrencyLabel.Margin = new System.Windows.Forms.Padding(6, 6, 3, 6);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(52, 13);
            this.CurrencyLabel.TabIndex = 1;
            this.CurrencyLabel.Text = "!Currency";
            // 
            // LanguageBox
            // 
            this.LanguageBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LanguageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(70, 6);
            this.LanguageBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(121, 21);
            this.LanguageBox.TabIndex = 2;
            // 
            // CurrencyBox
            // 
            this.CurrencyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CurrencyBox.Location = new System.Drawing.Point(70, 39);
            this.CurrencyBox.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.CurrencyBox.MaxLength = 3;
            this.CurrencyBox.Name = "CurrencyBox";
            this.CurrencyBox.Size = new System.Drawing.Size(31, 20);
            this.CurrencyBox.TabIndex = 3;
            this.CurrencyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SettingsEditor
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(229, 139);
            this.Controls.Add(this.FormLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!Settings Editor";
            this.FormLayout.ResumeLayout(false);
            this.FormLayout.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel FormLayout;
        protected System.Windows.Forms.TableLayoutPanel ButtonLayout;
        public System.Windows.Forms.Button SaveButton;
        protected System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.Label CurrencyLabel;
        private System.Windows.Forms.ComboBox LanguageBox;
        private System.Windows.Forms.TextBox CurrencyBox;
    }
}