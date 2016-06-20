namespace SQMCleaner
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.SimpleDeleteLabel = new System.Windows.Forms.Label();
            this.SimpleDeleteTextBox = new System.Windows.Forms.TextBox();
            this.CleanButton = new System.Windows.Forms.Button();
            this.DeleteAllCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(13, 22);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(32, 13);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "Path:";
            // 
            // PathTextBox
            // 
            this.PathTextBox.BackColor = System.Drawing.Color.White;
            this.PathTextBox.Location = new System.Drawing.Point(51, 19);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(309, 20);
            this.PathTextBox.TabIndex = 1;
            // 
            // PathButton
            // 
            this.PathButton.Location = new System.Drawing.Point(366, 17);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(75, 23);
            this.PathButton.TabIndex = 2;
            this.PathButton.Text = "Search";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // SimpleDeleteLabel
            // 
            this.SimpleDeleteLabel.AutoSize = true;
            this.SimpleDeleteLabel.Location = new System.Drawing.Point(16, 64);
            this.SimpleDeleteLabel.Name = "SimpleDeleteLabel";
            this.SimpleDeleteLabel.Size = new System.Drawing.Size(200, 13);
            this.SimpleDeleteLabel.TabIndex = 3;
            this.SimpleDeleteLabel.Text = "Delete CustomAttributes, which contains:";
            // 
            // SimpleDeleteTextBox
            // 
            this.SimpleDeleteTextBox.Location = new System.Drawing.Point(19, 80);
            this.SimpleDeleteTextBox.Name = "SimpleDeleteTextBox";
            this.SimpleDeleteTextBox.Size = new System.Drawing.Size(341, 20);
            this.SimpleDeleteTextBox.TabIndex = 4;
            // 
            // CleanButton
            // 
            this.CleanButton.Enabled = false;
            this.CleanButton.Location = new System.Drawing.Point(366, 78);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(75, 23);
            this.CleanButton.TabIndex = 7;
            this.CleanButton.Text = "Clean";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // DeleteAllCheckBox
            // 
            this.DeleteAllCheckBox.AutoSize = true;
            this.DeleteAllCheckBox.Location = new System.Drawing.Point(290, 63);
            this.DeleteAllCheckBox.Name = "DeleteAllCheckBox";
            this.DeleteAllCheckBox.Size = new System.Drawing.Size(70, 17);
            this.DeleteAllCheckBox.TabIndex = 8;
            this.DeleteAllCheckBox.Text = "Delete all";
            this.DeleteAllCheckBox.UseVisualStyleBackColor = true;
            this.DeleteAllCheckBox.CheckedChanged += new System.EventHandler(this.DeleteAllCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 117);
            this.Controls.Add(this.DeleteAllCheckBox);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.SimpleDeleteTextBox);
            this.Controls.Add(this.SimpleDeleteLabel);
            this.Controls.Add(this.PathButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.PathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "SQM Cleaner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.Label SimpleDeleteLabel;
        private System.Windows.Forms.TextBox SimpleDeleteTextBox;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.CheckBox DeleteAllCheckBox;
    }
}

