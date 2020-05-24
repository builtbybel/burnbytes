namespace Comet.UI
{
    partial class DriveSelection
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
            this.LblSelect = new System.Windows.Forms.Label();
            this.LblDrives = new System.Windows.Forms.Label();
            this.CbbDrives = new System.Windows.Forms.ComboBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblSelect
            // 
            this.LblSelect.AutoSize = true;
            this.LblSelect.Location = new System.Drawing.Point(18, 13);
            this.LblSelect.Name = "LblSelect";
            this.LblSelect.Size = new System.Drawing.Size(186, 13);
            this.LblSelect.TabIndex = 3;
            this.LblSelect.Text = "Select the drive you want to clean up.";
            // 
            // LblDrives
            // 
            this.LblDrives.AutoSize = true;
            this.LblDrives.Location = new System.Drawing.Point(18, 34);
            this.LblDrives.Name = "LblDrives";
            this.LblDrives.Size = new System.Drawing.Size(40, 13);
            this.LblDrives.TabIndex = 4;
            this.LblDrives.Text = "&Drives:";
            // 
            // CbbDrives
            // 
            this.CbbDrives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbbDrives.DisplayMember = "Name";
            this.CbbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbDrives.FormattingEnabled = true;
            this.CbbDrives.Location = new System.Drawing.Point(20, 52);
            this.CbbDrives.Name = "CbbDrives";
            this.CbbDrives.Size = new System.Drawing.Size(261, 21);
            this.CbbDrives.TabIndex = 0;
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnOk.Location = new System.Drawing.Point(68, 89);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnExit.Location = new System.Drawing.Point(162, 89);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // DriveSelection
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.BtnExit;
            this.ClientSize = new System.Drawing.Size(306, 133);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.CbbDrives);
            this.Controls.Add(this.LblDrives);
            this.Controls.Add(this.LblSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriveSelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drive Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSelect;
        private System.Windows.Forms.Label LblDrives;
        private System.Windows.Forms.ComboBox CbbDrives;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnExit;
    }
}