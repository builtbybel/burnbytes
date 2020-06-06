namespace Burnbytes.Forms
{
    partial class Cleaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cleaner));
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCleanup = new System.Windows.Forms.Label();
            this.prgCleaning = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCleaning = new System.Windows.Forms.Label();
            this.lblCurrentHandler = new System.Windows.Forms.Label();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(48, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(276, 41);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Burnbytes is cleaning up unnecessary files on your machine.";
            // 
            // lblCleanup
            // 
            this.lblCleanup.AutoSize = true;
            this.lblCleanup.Location = new System.Drawing.Point(8, 62);
            this.lblCleanup.Name = "lblCleanup";
            this.lblCleanup.Size = new System.Drawing.Size(92, 13);
            this.lblCleanup.TabIndex = 2;
            this.lblCleanup.Text = "Cleaning up drive ";
            // 
            // prgCleaning
            // 
            this.prgCleaning.Location = new System.Drawing.Point(11, 78);
            this.prgCleaning.Name = "prgCleaning";
            this.prgCleaning.Size = new System.Drawing.Size(227, 15);
            this.prgCleaning.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(249, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblCleaning
            // 
            this.lblCleaning.AutoSize = true;
            this.lblCleaning.Location = new System.Drawing.Point(8, 96);
            this.lblCleaning.Name = "lblCleaning";
            this.lblCleaning.Size = new System.Drawing.Size(51, 13);
            this.lblCleaning.TabIndex = 4;
            this.lblCleaning.Text = "Cleaning:";
            // 
            // lblCurrentHandler
            // 
            this.lblCurrentHandler.AutoSize = true;
            this.lblCurrentHandler.Location = new System.Drawing.Point(91, 96);
            this.lblCurrentHandler.Name = "lblCurrentHandler";
            this.lblCurrentHandler.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentHandler.TabIndex = 5;
            // 
            // ptbLogo
            // 
            this.ptbLogo.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogo.Image")));
            this.ptbLogo.Location = new System.Drawing.Point(11, 11);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(32, 32);
            this.ptbLogo.TabIndex = 6;
            this.ptbLogo.TabStop = false;
            // 
            // Cleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(335, 126);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.lblCurrentHandler);
            this.Controls.Add(this.lblCleaning);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.prgCleaning);
            this.Controls.Add(this.lblCleanup);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cleaner";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Burnbytes";
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCleanup;
        private System.Windows.Forms.ProgressBar prgCleaning;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCleaning;
        private System.Windows.Forms.Label lblCurrentHandler;
        private System.Windows.Forms.PictureBox ptbLogo;
    }
}